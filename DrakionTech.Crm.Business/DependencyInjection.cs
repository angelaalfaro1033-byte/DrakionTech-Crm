using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Business.Mapping;
using DrakionTech.Crm.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DrakionTech.Crm.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCrmBusiness(
            this IServiceCollection services)
        {
            // AutoMapper
            services.AddAutoMapper(typeof(CrmMappingProfile));

            // Servicios
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IContactoService, ContactoService>();
            services.AddScoped<IOportunidadService, OportunidadService>();
            services.AddScoped<IActividadService, ActividadService>();
            services.AddScoped<IPropuestaService, PropuestaService>();
            services.AddScoped<IPaisService, PaisService>();
            services.AddScoped<ICiudadService, CiudadService>();
            services.AddScoped<ISectorService, SectorService>();
            services.AddScoped<IEmpleadoService, EmpleadoService>();
            services.AddScoped<IEstadoService, EstadoService>();
            services.AddScoped<IPrefijoTelefonicoService, PrefijoTelefonicoService>();
            services.AddScoped<IUsuarioInternoService, UsuarioInternoService>();
            services.AddScoped<IGoogleCalendarService, GoogleCalendarService>();
            services.AddScoped<GoogleEventoSyncService>();
            services.AddScoped<IRolUsuarioService, RolUsuarioService>();
            services.AddScoped<IEspecialidadService, EspecialidadService>();

            return services;
        }
    }
}