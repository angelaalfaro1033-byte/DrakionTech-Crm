using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Data.Repositories;

public class PublicacionMarketingRepository : IPublicacionMarketingRepository
{
    private readonly ApplicationDbContext _context;

    public PublicacionMarketingRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IQueryable<PublicacionMarketing> Query()
    {
        return _context.PublicacionesMarketing
            .Include(x => x.Responsable)
            .Include(x => x.RedesSociales)
            .Include(x => x.Metricas)
            .Include(x => x.Archivos)
            .AsQueryable();
    }

    public async Task<List<PublicacionMarketing>> ObtenerTodosAsync()
    {
        return await Query()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<PublicacionMarketing?> ObtenerPorIdAsync(int id)
    {
        return await Query()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AgregarAsync(PublicacionMarketing publicacion)
    {
        await _context.PublicacionesMarketing.AddAsync(publicacion);
        await _context.SaveChangesAsync();
    }

    public async Task ActualizarAsync(PublicacionMarketing publicacion)
    {
        _context.PublicacionesMarketing.Update(publicacion);
        await _context.SaveChangesAsync();
    }

    public async Task EliminarAsync(PublicacionMarketing publicacion)
    {
        _context.PublicacionesMarketing.Remove(publicacion);
        await _context.SaveChangesAsync();
    }
}