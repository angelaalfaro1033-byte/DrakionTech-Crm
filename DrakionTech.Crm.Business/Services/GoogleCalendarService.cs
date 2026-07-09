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

        public async Task<List<GoogleEventoDto>> GetEventosAsync(int? usuarioId = null)
        {
            var service = await GetCalendarServiceAsync(usuarioId);

            var request = service.Events.List("primary");
            request.MaxResults = 20;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
            request.TimeMinDateTimeOffset = DateTimeOffset.Now;

            var events = await request.ExecuteAsync();

            var lista = new List<GoogleEventoDto>();

            foreach (var e in events.Items)
            {
                if (EsEventoCumpleanos(e))
                    continue;

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

        public async Task<string> CrearEventoAsync(CrearGoogleEventoDto dto, int? usuarioId = null)
        {
            var service = await GetCalendarServiceAsync(usuarioId);

            var newEvent = await BuildEventAsync(dto);

            var request = service.Events.Insert(newEvent, "primary");

            request.SupportsAttachments = true;

            if (dto.EsVirtual)
            {
                request.ConferenceDataVersion = 1;
            }

            var createdEvent = await request.ExecuteAsync();

            return createdEvent.Id;
        }

        public async Task<string> ActualizarEventoAsync(string googleEventId, CrearGoogleEventoDto dto, int? usuarioId = null)
        {
            var service = await GetCalendarServiceAsync(usuarioId);

            var eventoActualizado = await BuildEventAsync(dto);

            var request = service.Events.Update(eventoActualizado, "primary", googleEventId);

            request.SupportsAttachments = true;

            if (dto.EsVirtual)
            {
                request.ConferenceDataVersion = 1;
            }

            var updatedEvent = await request.ExecuteAsync();

            return updatedEvent.Id;
        }

        public async Task<bool> EliminarEventoAsync(string googleEventId, int? usuarioId = null)
        {
            var service = await GetCalendarServiceAsync(usuarioId);

            var request = service.Events.Delete("primary", googleEventId);
            await request.ExecuteAsync();

            return true;
        }

        private async Task<Event> BuildEventAsync(CrearGoogleEventoDto dto)
        {
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

            var evento = new Event
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
                evento.ConferenceData = new ConferenceData
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

            return evento;
        }

        private static bool EsEventoCumpleanos(Event e)
        {
            return string.Equals(e.EventType, "birthday", StringComparison.OrdinalIgnoreCase)
                || string.Equals(e.Summary, "Happy birthday!", StringComparison.OrdinalIgnoreCase);
        }

        private async Task<CalendarService> GetCalendarServiceAsync(int? usuarioId = null)
        {
            var credential = await _authService.GetCredentialAsync(usuarioId);

            return new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "CRM Google Integration",
            });
        }
    }
}
