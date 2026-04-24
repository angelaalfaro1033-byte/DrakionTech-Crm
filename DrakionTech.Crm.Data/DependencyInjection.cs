using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DrakionTech.Crm.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCrmData(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Drakion_Crm");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Register Repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IOportunidadRepository, OportunidadRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IContactoRepository, ContactoRepository>();
            services.AddScoped<IActividadRepository, ActividadRepository>();
            services.AddScoped<IPropuestaRepository, PropuestaRepository>();
            services.AddScoped<IPaisRepository, PaisRepository>();
            services.AddScoped<ICiudadRepository, CiudadRepository>();
            services.AddScoped<ISectorRepository, SectorRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<IPrefijoTelefonicoRepository, PrefijoTelefonicoRepository>();
            services.AddScoped<IRolContactoRepository, RolContactoRepository>();
            services.AddScoped<IUsuarioInternoRepository, UsuarioInternoRepository>();
            services.AddScoped<IEstadoActividadRepository, EstadoActividadRepository>();
            services.AddScoped<ITipoActividadRepository, TipoActividadRepository>();

            return services;
        }
    }
}