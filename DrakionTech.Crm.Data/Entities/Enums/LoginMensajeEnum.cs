using System.ComponentModel;

namespace DrakionTech.Crm.Data.Entities.Enums;

public enum LoginErrorEnum
{
    Ninguno,
    [Description("Correo o contraseña incorrectos.")]
    Credenciales,
    [Description("Tu cuenta no está activada.")]
    Inactivo,
    [Description("No se pudo iniciar sesión con Google.")]
    Google,
    [Description("Tu cuenta de Google no est� registrada.")]
    NoRegistrado
}

public enum LoginMensajeEnum
{
    Ninguno,
    [Description("�Cuenta creada! Ya puedes iniciar sesi�n.")]
    CuentaCreada
}

public enum RegistroResultadoEnum
{
    Ok,
    Bloqueado,
    [Description("Faltan campos por completar.")]
    CamposFaltantes,
    [Description("Las contrase�as no coinciden.")]
    PasswordsNoCoinciden,
    [Description("La contrase�a es muy corta.")]
    PasswordCorta
}

public enum GoogleCallbackResultadoEnum
{
    Ok,
    [Description("No se pudo obtener el correo de Google.")]
    EmailNulo,
    [Description("Tu cuenta de Google no está registrada.")]
    NoRegistrado,
    [Description("Tu cuenta no está activada.")]
    Inactivo
}