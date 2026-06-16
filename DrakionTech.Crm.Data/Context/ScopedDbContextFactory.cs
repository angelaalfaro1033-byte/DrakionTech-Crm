using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DrakionTech.Crm.Data.Context;

public class ScopedDbContextFactory : IDbContextFactory<ApplicationDbContext>
{
    private readonly IServiceScopeFactory _scopeFactory;

    public ScopedDbContextFactory(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public ApplicationDbContext CreateDbContext()
    {
        var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.ScopeOwner = scope; // el contexto se encarga de cerrar el scope al disponerse
        return context;
    }
}