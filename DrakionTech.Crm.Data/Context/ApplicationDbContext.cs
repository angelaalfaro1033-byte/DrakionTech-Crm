using DrakionTech.Crm.Data.Configurations;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Entities.Base;
using DrakionTech.Crm.Data.Seed;
using DrakionTech.Crm.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ICurrentUserContext? _currentUserContext;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            ICurrentUserContext? currentUserContext = null)
            : base(options)
        {
            _currentUserContext = currentUserContext;
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
        public DbSet<RolUsuario> RolesUsuario => Set<RolUsuario>();
        public DbSet<Especialidad> Especialidades => Set<Especialidad>();
        public DbSet<UsuarioInterno> UsuariosInternos => Set<UsuarioInterno>();
        public DbSet<EstadoActividad> EstadosActividad => Set<EstadoActividad>();
        public DbSet<TipoActividad> TiposActividad => Set<TipoActividad>();
        public DbSet<ActividadUsuario> ActividadUsuarios => Set<ActividadUsuario>();
        public DbSet<GoogleEvento> GoogleEventos { get; set; } = null!;
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<GoogleEventoArchivo> GoogleEventoArchivos { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<EmpleadoSalario> EmpleadoSalarios { get; set; } = null!;
        public DbSet<Area> Areas { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<PublicacionMarketing> PublicacionesMarketing { get; set; } = null!;
        public DbSet<PublicacionRedSocial> PublicacionRedesSociales { get; set; } = null!;
        public DbSet<ArchivoPublicacionMarketing> ArchivosPublicacionMarketing { get; set; }
        public DbSet<MetricaPublicacion> MetricasPublicacion { get; set; } = null!;
        public DbSet<PagoProyecto> PagosProyecto { get; set; } = null!;
        public DbSet<SectorEmpresa> SectoresEmpresa { get; set; } = null!;
        public DbSet<SubsectorEmpresa> SubsectoresEmpresa { get; set; } = null!;
        public DbSet<EmpresaCorreo> EmpresaCorreos { get; set; } = null!;
        public DbSet<HistorialEtapaProyecto> HistorialesEtapaProyecto => Set<HistorialEtapaProyecto>();
        public DbSet<HistorialEmpresa> HistorialesEmpresa => Set<HistorialEmpresa>();

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
            modelBuilder.ApplyConfiguration(new RolUsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new EspecialidadConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioInternoConfiguration());
            modelBuilder.ApplyConfiguration(new EstadoActividadConfiguration());
            modelBuilder.ApplyConfiguration(new TipoActividadConfiguration());
            modelBuilder.ApplyConfiguration(new ActividadUsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new GoogleEventoConfiguration());
            modelBuilder.ApplyConfiguration(new EmpleadoConfiguration());
            modelBuilder.ApplyConfiguration(new EmailTemplateConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new EmpleadoSalarioConfiguration());
            modelBuilder.Entity<Area>().HasOne(a => a.Responsable).WithMany().HasForeignKey(a => a.ResponsableId).OnDelete(DeleteBehavior.SetNull).IsRequired(false);
            modelBuilder.Entity<Usuario>().HasOne(u => u.Area).WithMany(a => a.Usuarios).HasForeignKey(u => u.AreaId).OnDelete(DeleteBehavior.SetNull).IsRequired(false);
            modelBuilder.ApplyConfiguration(new ProyectoConfiguration());
            modelBuilder.ApplyConfiguration(new PagoProyectoConfiguration());
            modelBuilder.ApplyConfiguration(new SectorEmpresaConfiguration());
            modelBuilder.ApplyConfiguration(new SubsectorEmpresaConfiguration());
            modelBuilder.ApplyConfiguration(new EmpresaCorreoConfiguration());
            modelBuilder.ApplyConfiguration(new PublicacionMarketingConfiguration());
            modelBuilder.ApplyConfiguration(new PublicacionRedSocialConfiguration());
            modelBuilder.ApplyConfiguration(new MetricaPublicacionConfiguration());
            modelBuilder.ApplyConfiguration(new HistorialEmpresaConfiguration());
            modelBuilder.Entity<ArchivoPublicacionMarketing>().HasOne(x => x.PublicacionMarketing).WithMany(x => x.Archivos).HasForeignKey(x => x.PublicacionMarketingId).OnDelete(DeleteBehavior.Cascade);

            ConfigureAuditableEntities(modelBuilder);

            InitialSeed.Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ApplyAuditInformation();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ApplyAuditInformation();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditInformation();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            ApplyAuditInformation();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private static void ConfigureAuditableEntities(ModelBuilder modelBuilder)
        {
            var auditableEntityTypes = modelBuilder.Model
                .GetEntityTypes()
                .Where(entityType => typeof(AuditableEntity).IsAssignableFrom(entityType.ClrType));

            foreach (var entityType in auditableEntityTypes)
            {
                var entity = modelBuilder.Entity(entityType.ClrType);

                entity.Property(nameof(AuditableEntity.CreatedByUserId))
                    .IsRequired(false);

                entity.Property(nameof(AuditableEntity.CreatedAt))
                    .IsRequired(false);

                entity.Property(nameof(AuditableEntity.ModifiedByUserId))
                    .IsRequired(false);

                entity.Property(nameof(AuditableEntity.ModifiedAt))
                    .IsRequired(false);

                entity.HasOne(typeof(Usuario), nameof(AuditableEntity.CreatedByUser))
                    .WithMany()
                    .HasForeignKey(nameof(AuditableEntity.CreatedByUserId))
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired(false);

                entity.HasOne(typeof(Usuario), nameof(AuditableEntity.ModifiedByUser))
                    .WithMany()
                    .HasForeignKey(nameof(AuditableEntity.ModifiedByUserId))
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired(false);
            }
        }

        private void ApplyAuditInformation()
        {
            var now = DateTime.UtcNow;
            var currentUserId = _currentUserContext?.UserId;

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = now;
                    entry.Entity.CreatedByUserId = currentUserId;

                    if (entry.Entity is BaseEntity baseEntity && baseEntity.FechaCreacion == default)
                    {
                        baseEntity.FechaCreacion = now;
                    }
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property(entity => entity.CreatedAt).IsModified = false;
                    entry.Property(entity => entity.CreatedByUserId).IsModified = false;

                    entry.Entity.ModifiedAt = now;
                    entry.Entity.ModifiedByUserId = currentUserId;

                    if (entry.Entity is BaseEntity baseEntity)
                    {
                        baseEntity.FechaActualizacion = now;
                    }
                }
            }
        }
    }
}
