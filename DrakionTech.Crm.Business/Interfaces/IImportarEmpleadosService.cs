using DrakionTech.Crm.Business.DTOs.Empleado;

namespace DrakionTech.Crm.Business.Interfaces
{
    public interface IImportarEmpleadosService
    {
        Task<ImportarEmpleadosResultDto> ImportarAsync(Stream stream);
    }
}