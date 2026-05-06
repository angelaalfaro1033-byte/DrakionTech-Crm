namespace DrakionTech.Crm.Business.Interfaces;

public interface IMensajesService
{
    string? ObtenerMensajeError(string? codigoError);
    string? ObtenerMensajeExito(string? codigoMensaje);
}