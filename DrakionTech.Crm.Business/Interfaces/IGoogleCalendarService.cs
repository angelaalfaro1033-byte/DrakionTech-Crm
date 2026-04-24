using DrakionTech.Crm.Business.DTOs.Google;

public interface IGoogleCalendarService
{
    Task<List<GoogleEventoDto>> GetEventosAsync();
    Task<string> CrearEventoAsync(CrearGoogleEventoDto dto);
}