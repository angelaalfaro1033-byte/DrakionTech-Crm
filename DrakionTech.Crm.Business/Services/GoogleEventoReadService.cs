using DrakionTech.Crm.Data.Context;
using Microsoft.EntityFrameworkCore;
public class GoogleEventoReadService
{
    private readonly ApplicationDbContext _context;

    public GoogleEventoReadService(ApplicationDbContext context)
    {
        _context = context;
    }
            
    public async Task<List<GoogleEvento>> ObtenerEventosAsync()
    {
        return await _context.GoogleEventos
            .Include(e => e.Archivos)
            .OrderByDescending(e => e.FechaInicio)
            .ToListAsync();
    }
}