using DrakionTech.Crm.Data.Configurations;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Seed;
using Microsoft.EntityFrameworkCore;
namespace DrakionTech.Crm.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<Empresa> Empresas { get; set; } = null!;
        public DbSet<Contacto> Contactos { get; set; } = null!;
        public DbSet<Oportunidad> Oportunidades { get; set; } = null!;
        public DbSet<Actividad> Actividades { get; set; } = null!;
        public DbSet<Propuesta> Propuestas { get; set; } = null!;
        public DbSet<HistorialCambioOportunidad> HistorialCambiosOportunidad { get; set; } = null!;
        public DbSet<Pais> Paises => Set<Pais>();
        public DbSet<Ciudad> Ciudades => Set<Ciudad>();
        public DbSet<Sector> Sectores { get; set; } = null!;
        public DbSet<Estado> Estados { get; set; } = null!;
        public DbSet<PrefijoTelefonico> PrefijosTelefonicos => Set<PrefijoTelefonico>();
        public DbSet<RolContacto> RolesContacto => Set<RolContacto>();
        public DbSet<UsuarioInterno> UsuariosInternos => Set<UsuarioInterno>();
        public DbSet<EstadoActividad> EstadosActividad => Set<EstadoActividad>();
        public DbSet<TipoActividad> TiposActividad => Set<TipoActividad>();
        public DbSet<ActividadUsuario> ActividadUsuarios => Set<ActividadUsuario>();
        public DbSet<GoogleEvento> GoogleEventos { get; set; } = null!;
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<GoogleEventoArchivo> GoogleEventoArchivos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplicar todas las configuraciones de entidades
            modelBuilder.ApplyConfiguration(new EmpresaConfiguration());
            modelBuilder.ApplyConfiguration(new ContactoConfiguration());
            modelBuilder.ApplyConfiguration(new OportunidadConfiguration());
            modelBuilder.ApplyConfiguration(new ActividadConfiguration());
            modelBuilder.ApplyConfiguration(new PropuestaConfiguration());
            modelBuilder.ApplyConfiguration(new HistorialCambioOportunidadConfiguration());
            modelBuilder.ApplyConfiguration(new PaisConfiguration());
            modelBuilder.ApplyConfiguration(new CiudadConfiguration());
            modelBuilder.ApplyConfiguration(new SectorConfiguration());
            modelBuilder.ApplyConfiguration(new EstadoConfiguration());
            modelBuilder.ApplyConfiguration(new PrefijoTelefonicoConfiguration());
            modelBuilder.ApplyConfiguration(new RolContactoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioInternoConfiguration());
            modelBuilder.ApplyConfiguration(new EstadoActividadConfiguration());
            modelBuilder.ApplyConfiguration(new TipoActividadConfiguration());
            modelBuilder.ApplyConfiguration(new ActividadUsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new GoogleEventoConfiguration());
            modelBuilder.ApplyConfiguration(new EmpleadoConfiguration());

            InitialSeed.Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}