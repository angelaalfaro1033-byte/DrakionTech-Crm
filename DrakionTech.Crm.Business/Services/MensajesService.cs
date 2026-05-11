using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Business.Services;

public class MensajesService : IMensajesService
{
    public string? ObtenerMensajeError(string? codigoError)
    {
        if (!Enum.TryParse<LoginErrorEnum>(codigoError, out var error))
            return null;

        return error.ObtenerDescripcion();
    }

    public string? ObtenerMensajeExito(string? codigoMensaje)
    {
        if (!Enum.TryParse<LoginMensajeEnum>(codigoMensaje, out var mensaje))
            return null;

        return mensaje.ObtenerDescripcion();
    }
}