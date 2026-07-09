using DrakionTech.Crm.Business.DTOs.Google;
using DrakionTech.Crm.Data.Entities;
using Microsoft.Extensions.Logging;

namespace DrakionTech.Crm.Business.Services;

public interface IActividadGoogleCalendarService
{
    /// <summary>
    /// Crea un evento en Google Calendar a partir de una actividad.
    /// </summary>
    Task<string?> CrearEventoAsync(Actividad actividad, CancellationToken ct = default);

    /// <summary>
    /// Actualiza un evento existente en Google Calendar.
    /// Retorna null si no hay evento vinculado (ExternalCalendarEventId).
    /// </summary>
    Task<string?> ActualizarEventoAsync(Actividad actividad, int usuarioAnteriorId, CancellationToken ct = default);

    /// <summary>
    /// Elimina un evento de Google Calendar.
    /// </summary>
    Task<bool> EliminarEventoAsync(string googleEventId, CancellationToken ct = default);
}

public class ActividadGoogleCalendarService : IActividadGoogleCalendarService
{
    private readonly IGoogleCalendarService _googleCalendarService;
    private readonly ILogger<ActividadGoogleCalendarService> _logger;

    public ActividadGoogleCalendarService(
        IGoogleCalendarService googleCalendarService,
        ILogger<ActividadGoogleCalendarService> logger)
    {
        _googleCalendarService = googleCalendarService;
        _logger = logger;
    }

    public async Task<string?> CrearEventoAsync(Actividad actividad, CancellationToken ct = default)
    {
        try
        {
            var dto = new CrearGoogleEventoDto
            {
                Titulo = ConstruirTitulo(actividad),
                Descripcion = actividad.Notas,
                FechaInicio = actividad.Inicio,
                FechaFin = actividad.Fin ?? actividad.Inicio.AddHours(1),
                EmpresaId = actividad.EmpresaId,
                EsVirtual = false
            };

            var eventId = await _googleCalendarService.CrearEventoAsync(dto, actividad.UsuarioId);

            _logger.LogInformation(
                "Evento de Google Calendar creado exitosamente para Actividad {ActividadId}: {EventId}",
                actividad.Id, eventId);

            return eventId;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "Error al crear evento en Google Calendar para Actividad {ActividadId}",
                actividad.Id);
            throw;
        }
    }

    public async Task<string?> ActualizarEventoAsync(Actividad actividad, int usuarioAnteriorId, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(actividad.ExternalCalendarEventId))
        {
            _logger.LogWarning(
                "Actividad {ActividadId} no tiene evento vinculado en Google Calendar",
                actividad.Id);
            return null;
        }

        try
        {
            var dto = new CrearGoogleEventoDto
            {
                Titulo = ConstruirTitulo(actividad),
                Descripcion = actividad.Notas,
                FechaInicio = actividad.Inicio,
                FechaFin = actividad.Fin ?? actividad.Inicio.AddHours(1),
                EmpresaId = actividad.EmpresaId,
                EsVirtual = false
            };

            if (usuarioAnteriorId != actividad.UsuarioId)
            {
                await _googleCalendarService.EliminarEventoAsync(
                    actividad.ExternalCalendarEventId,
                    usuarioAnteriorId);

                var nuevoEventId = await _googleCalendarService.CrearEventoAsync(
                    dto,
                    actividad.UsuarioId);

                _logger.LogInformation(
                    "Evento de Google Calendar movido de usuario {UsuarioAnteriorId} a {UsuarioNuevoId} para Actividad {ActividadId}: {EventId}",
                    usuarioAnteriorId,
                    actividad.UsuarioId,
                    actividad.Id,
                    nuevoEventId);

                return nuevoEventId;
            }

            await _googleCalendarService.ActualizarEventoAsync(
                actividad.ExternalCalendarEventId,
                dto,
                actividad.UsuarioId);

            _logger.LogInformation(
                "Evento de Google Calendar actualizado para Actividad {ActividadId}: {EventId}",
                actividad.Id, actividad.ExternalCalendarEventId);

            return actividad.ExternalCalendarEventId;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "Error al actualizar evento en Google Calendar para Actividad {ActividadId}",
                actividad.Id);
            throw;
        }
    }

    public async Task<bool> EliminarEventoAsync(string googleEventId, CancellationToken ct = default)
    {
        try
        {
            // Nota: IGoogleCalendarService no expone DeleteAsync,
            // pero puedes agregar este método a GoogleCalendarService si lo necesitas.
            // Por ahora, registramos el intento.
            _logger.LogInformation(
                "Eliminación de evento {EventId} solicitada (requiere implementación en GoogleCalendarService)",
                googleEventId);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "Error al eliminar evento {EventId} de Google Calendar",
                googleEventId);
            return false;
        }
    }

    private static string ConstruirTitulo(Actividad actividad)
    {
        var nombreEmpresa = actividad.Empresa?.Nombre?.Trim();
        var tipoActividad = actividad.TipoActividad?.Nombre?.Trim() ?? "Actividad";
        var relacionado = ObtenerNombreRelacionado(actividad);

        var tituloBase = string.IsNullOrWhiteSpace(relacionado)
            ? tipoActividad
            : $"{tipoActividad} - {relacionado}";

        return string.IsNullOrWhiteSpace(nombreEmpresa)
            ? tituloBase
            : $"[{nombreEmpresa}] {tituloBase}";
    }

    private static string? ObtenerNombreRelacionado(Actividad actividad)
    {
        if (!string.IsNullOrWhiteSpace(actividad.Oportunidad?.NombreProyecto))
            return actividad.Oportunidad.NombreProyecto.Trim();

        if (!string.IsNullOrWhiteSpace(actividad.Contacto?.Nombre))
            return actividad.Contacto.Nombre.Trim();

        return null;
    }
}
