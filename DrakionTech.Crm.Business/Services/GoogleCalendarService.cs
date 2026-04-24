using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Business.DTOs.Google;
using System.Text.RegularExpressions;
using Google.Apis.Drive.v3;

namespace DrakionTech.Crm.Business.Services
{
    public class GoogleCalendarService : IGoogleCalendarService
    {
        private readonly GoogleAuthService _authService;
        private readonly GoogleDriveService _driveService;

        public GoogleCalendarService(
            GoogleAuthService authService,
            GoogleDriveService driveService)
        {
            _authService = authService;
            _driveService = driveService;
        }

        public async Task<List<GoogleEventoDto>> GetEventosAsync()
        {
            var service = await GetCalendarServiceAsync();

            var request = service.Events.List("primary");
            request.MaxResults = 20;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
            request.TimeMinDateTimeOffset = DateTimeOffset.Now;

            var events = await request.ExecuteAsync();

            var lista = new List<GoogleEventoDto>();

            foreach (var e in events.Items)
            {
                var archivos = new List<string>();

                if (e.Attachments != null)
                {
                    foreach (var adj in e.Attachments)
                    {
                        if (!string.IsNullOrEmpty(adj.FileUrl))
                        {
                            archivos.Add(adj.FileUrl);
                        }
                    }
                }

                if (!string.IsNullOrEmpty(e.Description))
                {
                    var matches = Regex.Matches(
                        e.Description,
                        @"https?:\/\/[^\s]+"
                    );

                    foreach (Match match in matches)
                    {
                        archivos.Add(match.Value);
                    }
                }

                lista.Add(new GoogleEventoDto
                {
                    GoogleEventId = e.Id,
                    Titulo = e.Summary,
                    FechaInicio = e.Start?.DateTimeDateTimeOffset?.DateTime,
                    FechaFin = e.End?.DateTimeDateTimeOffset?.DateTime,
                    Descripcion = e.Description,
                    Ubicacion = e.Location,
                    Archivos = archivos,
                    LastUpdatedGoogle = e.Updated

                });
            }

            return lista;
        }

        public async Task<string> CrearEventoAsync(CrearGoogleEventoDto dto)
        {
            var service = await GetCalendarServiceAsync();

            var attachments = new List<EventAttachment>();

            var attendees = new List<EventAttendee>();

            if (dto.CorreosEmpleados != null && dto.CorreosEmpleados.Any())
            {
                foreach (var correo in dto.CorreosEmpleados.Where(x => !string.IsNullOrWhiteSpace(x)))
                {
                    attendees.Add(new EventAttendee
                    {
                        Email = correo.Trim()
                    });
                }
            }

            if (dto.Archivos != null && dto.Archivos.Any())
            {
                foreach (var archivo in dto.Archivos)
                {
                    using var stream = new MemoryStream(archivo.Contenido);

                    var (fileId, link) = await _driveService.SubirArchivoAsync(
                        archivo.Nombre,
                        archivo.MimeType,
                        stream
                    );

                    attachments.Add(new EventAttachment
                    {
                        FileUrl = link,
                        Title = archivo.Nombre,
                        MimeType = archivo.MimeType
                    });
                }
            }

            var newEvent = new Event
            {
                Summary = dto.Titulo,
                Description = dto.Descripcion,
                Location = dto.EsVirtual ? null : dto.Ubicacion,

                Start = new EventDateTime
                {
                    DateTime = dto.FechaInicio,
                    TimeZone = "America/Bogota"
                },
                End = new EventDateTime
                {
                    DateTime = dto.FechaFin,
                    TimeZone = "America/Bogota"
                },

                Attendees = attendees,
                Attachments = attachments
            };

            if (dto.EsVirtual)
            {
                newEvent.ConferenceData = new ConferenceData
                {
                    CreateRequest = new CreateConferenceRequest
                    {
                        RequestId = Guid.NewGuid().ToString(),
                        ConferenceSolutionKey = new ConferenceSolutionKey
                        {
                            Type = "hangoutsMeet"
                        }
                    }
                };
            }

            var request = service.Events.Insert(newEvent, "primary");

            request.SupportsAttachments = true;

            if (dto.EsVirtual)
            {
                request.ConferenceDataVersion = 1;
            }

            var createdEvent = await request.ExecuteAsync();

            var meetLink = createdEvent?.ConferenceData?
                .EntryPoints?
                .FirstOrDefault(x => x.EntryPointType == "video")?
                .Uri;

            return meetLink ?? createdEvent.Id;
        }

            private async Task<CalendarService> GetCalendarServiceAsync()
        {
            var credential = await _authService.GetCredentialAsync();

            return new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "CRM Google Integration",
            });
        }
    }
}