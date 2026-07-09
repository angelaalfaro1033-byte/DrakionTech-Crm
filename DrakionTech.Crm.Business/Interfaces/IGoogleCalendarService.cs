using DrakionTech.Crm.Business.DTOs.Google;

public interface IGoogleCalendarService
{
    Task<List<GoogleEventoDto>> GetEventosAsync(int? usuarioId = null);
    Task<string> CrearEventoAsync(CrearGoogleEventoDto dto, int? usuarioId = null);
    Task<string> ActualizarEventoAsync(string googleEventId, CrearGoogleEventoDto dto, int? usuarioId = null);
    Task<bool> EliminarEventoAsync(string googleEventId, int? usuarioId = null);
}
