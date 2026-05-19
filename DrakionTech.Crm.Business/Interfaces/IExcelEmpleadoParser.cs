using DrakionTech.Crm.Business.DTOs.Empleado;

namespace DrakionTech.Crm.Business.Interfaces
{
    public interface IExcelEmpleadoParser
    {
        List<EmpleadoExcelRowDto> Parse(Stream stream);
    }
}