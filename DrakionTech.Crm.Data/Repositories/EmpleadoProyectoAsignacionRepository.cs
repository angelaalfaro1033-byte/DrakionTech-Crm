using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Data.Repositories;

public class EmpleadoProyectoAsignacionRepository : IEmpleadoProyectoAsignacionRepository
{
    private readonly ApplicationDbContext _context;

    public EmpleadoProyectoAsignacionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IQueryable<EmpleadoProyectoAsignacion> Query()
    {
        return _context.EmpleadoProyectoAsignaciones
            .Include(a => a.Empleado)
            .Include(a => a.Proyecto)
            .Include(a => a.CreatedByUser)
            .Include(a => a.ModifiedByUser)
            .AsQueryable();
    }

    public async Task<EmpleadoProyectoAsignacion?> ObtenerPorIdAsync(int id)
    {
        return await Query()
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<EmpleadoProyectoAsignacion?> ObtenerActivaAsync(int empleadoId, int proyectoId)
    {
        return await _context.EmpleadoProyectoAsignaciones
            .FirstOrDefaultAsync(a =>
                a.EmpleadoId == empleadoId &&
                a.ProyectoId == proyectoId &&
                a.Activa);
    }

    public async Task AgregarAsync(EmpleadoProyectoAsignacion asignacion)
    {
        await _context.EmpleadoProyectoAsignaciones.AddAsync(asignacion);
        await _context.SaveChangesAsync();
    }

    public async Task ActualizarAsync(EmpleadoProyectoAsignacion asignacion)
    {
        _context.EmpleadoProyectoAsignaciones.Update(asignacion);
        await _context.SaveChangesAsync();
    }
}
