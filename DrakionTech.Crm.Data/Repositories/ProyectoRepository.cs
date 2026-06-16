using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Data.Repositories;

public class ProyectoRepository : IProyectoRepository
{
    private readonly ApplicationDbContext _context;

    public ProyectoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IQueryable<Proyecto> Query()
    {
        return _context.Proyectos
            .Include(p => p.Area)
            .Include(p => p.Responsable)
            .Include(p => p.SupervisorInterno)
            .Include(p => p.SupervisorExterno)
            .Include(p => p.CreatedByUser)
            .Include(p => p.ModifiedByUser)
            .Include(p => p.Oportunidad)
                .ThenInclude(o => o!.Empresa)
            .AsQueryable();
    }

    public async Task<List<Proyecto>> ObtenerTodosAsync()
    {
        return await _context.Proyectos
            .Include(p => p.Area)
            .Include(p => p.Responsable)
            .Include(p => p.SupervisorInterno)
            .Include(p => p.SupervisorExterno)
            .Include(p => p.CreatedByUser)
            .Include(p => p.ModifiedByUser)
            .Include(p => p.Oportunidad)
                .ThenInclude(o => o!.Empresa)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Proyecto?> ObtenerPorIdAsync(int id)
    {
        return await _context.Proyectos
            .Include(p => p.Area)
            .Include(p => p.Responsable)
            .Include(p => p.SupervisorInterno)
            .Include(p => p.SupervisorExterno)
            .Include(p => p.CreatedByUser)
            .Include(p => p.ModifiedByUser)
            .Include(p => p.Oportunidad)
                .ThenInclude(o => o!.Empresa)
            .Include(p => p.Pagos.OrderBy(pg => pg.FechaProgramada))
                .ThenInclude(pg => pg.CreatedByUser)
            .Include(p => p.Pagos.OrderBy(pg => pg.FechaProgramada))
                .ThenInclude(pg => pg.ModifiedByUser)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AgregarAsync(Proyecto proyecto)
    {
        await _context.Proyectos.AddAsync(proyecto);
        await _context.SaveChangesAsync();
    }

    public async Task ActualizarAsync(Proyecto proyecto)
    {
        _context.Proyectos.Update(proyecto);
        await _context.SaveChangesAsync();
    }

    public async Task EliminarAsync(Proyecto proyecto)
    {
        _context.Proyectos.Remove(proyecto);
        await _context.SaveChangesAsync();
    }
}
