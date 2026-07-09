using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Repositories.Interfaces;
using DrakionTech.Crm.Data.Seed;
using DrakionTech.Crm.Data.Services;
using Microsoft.EntityFrameworkCore;

public class GoogleEventoReadService
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
    private readonly ICurrentUserContext _currentUserContext;
    private readonly IUsuarioRepository _usuarioRepository;

    public GoogleEventoReadService(
        IDbContextFactory<ApplicationDbContext> contextFactory,
        ICurrentUserContext currentUserContext,
        IUsuarioRepository usuarioRepository)
    {
        _contextFactory = contextFactory;
        _currentUserContext = currentUserContext;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<List<GoogleEvento>> ObtenerEventosAsync()
    {
        await using var context = _contextFactory.CreateDbContext();

        var query = context.GoogleEventos
            .AsNoTracking()
            .Include(e => e.Archivos)
            .OrderByDescending(e => e.FechaInicio)
            .AsQueryable();

        var usuarioId = _currentUserContext.UserId;
        if (!usuarioId.HasValue)
        {
            return await query.ToListAsync();
        }

        var usuario = await _usuarioRepository.GetByIdAsync(usuarioId.Value);
        if (usuario?.RolId == SeedIds.RolUsuarioAdministrador)
        {
            return await query.ToListAsync();
        }

        return await query
            .Where(e => e.CreatedByUserId == usuarioId.Value)
            .ToListAsync();
    }
}
