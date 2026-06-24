using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Repositories;

public interface IEmpleadoProyectoAsignacionRepository
{
    IQueryable<EmpleadoProyectoAsignacion> Query();
    Task<EmpleadoProyectoAsignacion?> ObtenerPorIdAsync(int id);
    Task<EmpleadoProyectoAsignacion?> ObtenerActivaAsync(int empleadoId, int proyectoId);
    Task AgregarAsync(EmpleadoProyectoAsignacion asignacion);
    Task ActualizarAsync(EmpleadoProyectoAsignacion asignacion);
}
