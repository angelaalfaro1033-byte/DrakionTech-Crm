namespace DrakionTech.Crm.Business.Common
{
    public static class MensajesError
    {
        // Generales
        public const string EmailObligatorio = "El email es obligatorio";
        public const string EmailInvalido = "El correo no es válido";
        public const string EmailInvalidoFormato = "El correo no tiene un formato válido.";
        public const string AppBaseUrlNoConfigurado = "App:BaseUrl no está configurado";
        public const string FechaObligatoria = "La fecha es obligatoria";
        public const string PlantinaNoExiste = "Plantilla no existe";

        // Persona
        public const string NombreObligatorio = "El nombre es obligatorio";
        public const string NombreSoloLetras = "El nombre solo puede contener letras";
        public const string ApellidoObligatorio = "El apellido es obligatorio";
        public const string ApellidoSoloLetras = "El apellido solo puede contener letras";
        public const string TelefonoInvalido = "El teléfono no es válido";

        // Documento
        public const string TipoDocumentoObligatorio = "El tipo de documento es obligatorio";
        public const string NumeroDocumentoObligatorio = "El número de documento es obligatorio";
        public const string NumeroDocumentoSoloNumeros = "El número de documento solo puede contener números";
        public const string NumeroDocumentoLongitud = "El número de documento debe tener entre 5 y 20 dígitos";

        // Rol
        public const string RolObligatorio = "El rol es obligatorio";
        public const string RolSeleccionar = "Selecciona un rol";
        public const string RolNoEncontrado = "Rol no encontrado";
        public const string RolContactoNoExiste = "El rol de contacto no existe";

        // Cargo / Especialidad
        public const string CargoObligatorio = "El cargo es obligatorio";
        public const string EspecialidadNoEncontrada = "Especialidad no encontrada";
        public const string EspecialidadNombreObligatorio = "El nombre es obligatorio";
        public const string EspecialidadNombreLongitud = "El nombre debe tener entre 2 y 100 caracteres";
        public const string EspecialidadDescripcionLongitud = "La descripción no puede superar 300 caracteres";
        public const string EspecialidadRolObligatorio = "Debes seleccionar un rol";

        //Actividad
        public const string TipoActividadObligatorio = "El tipo de actividad es obligatorio";
        public const string EstadoActividadObligatorio = "El estado de la actividad es obligatorio";

        //Oportunidad
        public const string NombreProyectoObligatorio = "El nombre del proyecto es obligatorio.";
        public const string ValorEstimadoMayorACero = "El valor estimado debe ser mayor a cero";

        //Empresa
        public const string EmpresaAsociadaNoExiste = "La empresa asociada no existe";
        public const string NombreEmpresaObligatorio = "El nombre de la empresa es obligatorio";
        public const string NitObligatorio = "El NIT es obligatorio";
        public const string DireccionObligatorio = "La dirección es obligatoria";
        public const string PaisObligatorio = "El país es obligatorio";
        public const string CiudadObligatorio = "La ciudad es obligatoria";
        public const string FechaVinculacionObligatoria = "La fecha de vinculación es obligatoria";

        // Empleado
        public const string EmpleadoNoEncontrado = "Empleado no encontrado";
        public const string EmailEmpleadoDuplicado = "Ya existe un empleado registrado con este correo.";
        public const string DocumentoEmpleadoDuplicado = "Ya existe un empleado registrado con este número de documento.";

        //SMTP
        public const string DestinatarioVacio = "ERROR SMTP: destinatario (to) está vacío";
        public const string DesdeVacio = "ERROR SMTP: From está vacío";
        public const string UsuarioVacio = "ERROR SMTP: User está vacío";

        // Usuario
        public const string UsuarioNoEncontrado = "Usuario no encontrado";
        public const string CuentaNoActivada = "Cuenta no activada";

        // Duplicados (con formato, usar string.Format o interpolación)
        public const string EspecialidadDuplicada = "Ya existe una especialidad con el nombre '{0}' para ese rol.";

        // Areas
        public const string AreaNombreObligatorio = "El nombre del área es obligatorio.";
        public const string AreaNombreLongitud = "El nombre debe tener entre 2 y 100 caracteres.";
        public const string AreaDescripcionLongitud = "La descripción no puede superar los 300 caracteres.";
    }
}