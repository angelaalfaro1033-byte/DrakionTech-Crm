using AutoMapper;
using DrakionTech.Crm.Business.DTOs.Actividad;
using DrakionTech.Crm.Business.DTOs.Catalogo;
using DrakionTech.Crm.Business.DTOs.Contacto;
using DrakionTech.Crm.Business.DTOs.Empresa;
using DrakionTech.Crm.Business.DTOs.Oportunidad;
using DrakionTech.Crm.Business.DTOs.PrefijoTelefonico;
using DrakionTech.Crm.Business.DTOs.Propuesta;
using DrakionTech.Crm.Business.DTOs.Proyecto;
using DrakionTech.Crm.Business.DTOs.Ubicacion;
using DrakionTech.Crm.Business.DTOs.Marketing;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Entities.Base;
using DrakionTech.Crm.Business.DTOs;
using DrakionTech.Crm.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json;

namespace DrakionTech.Crm.Business.Mapping
{
    public class CrmMappingProfile : Profile
    {
        public CrmMappingProfile()
        {
            // EMPRESA
            CreateMap<CrearEmpresaDto, Empresa>();

            CreateMap<ActualizarEmpresaDto, Empresa>();

            CreateMap<Empresa, EmpresaDto>()
                .ForMember(dest => dest.AuditInfo,
                    opt => opt.MapFrom(src => MapAuditInfo(src)))
                .ForMember(dest => dest.PaisNombre,
                    opt => opt.MapFrom(src => src.Pais != null ? src.Pais.Nombre : string.Empty))
                .ForMember(dest => dest.CiudadNombre,
                    opt => opt.MapFrom(src => src.Ciudad != null ? src.Ciudad.Nombre : string.Empty))
                .ForMember(dest => dest.SectorEmpresaNombre,
                    opt => opt.MapFrom(src => src.SectorEmpresa != null ? src.SectorEmpresa.Nombre : null))
                .ForMember(dest => dest.SubsectorEmpresaNombre,
                    opt => opt.MapFrom(src => src.SubsectorEmpresa != null ? src.SubsectorEmpresa.Nombre : null))
                .ForMember(dest => dest.Correos,
                    opt => opt.MapFrom(src => src.Correos
                        .Where(c => !c.EsPrincipal)
                        .Select(c => new EmpresaCorreoDto { Id = c.Id, Correo = c.Correo, EsPrincipal = false })
                        .ToList()));

            // CONTACTO
            CreateMap<CrearContactoDto, Contacto>()
                .ForMember(dest => dest.RolContactoId,
                    opt => opt.MapFrom(src => src.RolContactoId));

            CreateMap<ActualizarContactoDto, Contacto>()
                .ForMember(dest => dest.RolContactoId,
                    opt => opt.MapFrom(src => src.RolContactoId));

            CreateMap<Contacto, ContactoDto>()
                .ForMember(dest => dest.AuditInfo,
                    opt => opt.MapFrom(src => MapAuditInfo(src)))
                .ForMember(dest => dest.EmpresaNombre,
                    opt => opt.MapFrom(src => src.Empresa!.Nombre))
                .ForMember(dest => dest.RolNombre,
                    opt => opt.MapFrom(src => src.RolContacto!.Nombre));

            // OPORTUNIDAD
            CreateMap<CrearOportunidadDto, Oportunidad>();
            CreateMap<ActualizarOportunidadDto, Oportunidad>();
            CreateMap<Oportunidad, OportunidadDto>()
                .ForMember(d => d.AuditInfo,
                    o => o.MapFrom(s => MapAuditInfo(s)))
                .ForMember(d => d.EmpresaNombre,
                    o => o.MapFrom(s => s.Empresa!.Nombre))
                .ForMember(d => d.ContactoPrincipalNombre,
                    o => o.MapFrom(s =>
                        s.ContactoPrincipal != null
                            ? $"{s.ContactoPrincipal.Nombre} {s.ContactoPrincipal.Apellido}"
                            : null
                    ))
                .ForMember(d => d.EtapaNombre,
                o => o.MapFrom(s =>
                    GetDisplayName((EtapaOportunidad)s.Etapa)));

            // ACTIVIDAD
            CreateMap<TipoActividad, TipoActividadDto>();

            CreateMap<CrearActividadDto, Actividad>()
                .ForMember(d => d.Inicio, o => o.MapFrom(s => s.Fecha))
                .ForMember(d => d.Fin, o => o.MapFrom(s => s.FechaFin));

            CreateMap<Actividad, ActividadDto>()
                .ForMember(d => d.AuditInfo,
                    o => o.MapFrom(s => MapAuditInfo(s)))
                .ForMember(d => d.Fecha,
                    o => o.MapFrom(s => s.Inicio))
                .ForMember(d => d.FechaVencimiento,
                    o => o.MapFrom(s => s.Fin))
                .ForMember(d => d.EmpresaNombre,
                    o => o.MapFrom(s => s.Empresa!.Nombre))
                .ForMember(d => d.ContactoNombre,
                    o => o.MapFrom(s => s.Contacto != null
                        ? $"{s.Contacto.Nombre} {s.Contacto.Apellido}"
                        : null))
                .ForMember(d => d.ContactoTelefono,
                    o => o.MapFrom(s => s.Contacto != null
                        ? s.Contacto.Telefono
                        : null))
                .ForMember(d => d.OportunidadNombre,
                    o => o.MapFrom(s => s.Oportunidad != null
                        ? s.Oportunidad.NombreProyecto
                        : null))
                .ForMember(d => d.ActividadPreviaId,
                    o => o.MapFrom(s => s.ActividadPreviaId))
                .ForMember(d => d.ActividadPreviaNombre,
                    o => o.MapFrom(s => s.ActividadPrevia != null
                        ? s.ActividadPrevia.TipoActividad.Nombre
                        : null));

            // PROYECTO
            CreateMap<Proyecto, ProyectoDto>()
                .ForMember(d => d.AuditInfo,
                    o => o.MapFrom(s => MapAuditInfo(s)))
                .ForMember(d => d.AreaNombre,
                    o => o.MapFrom(s => s.Area.Nombre))
                .ForMember(d => d.ResponsableNombre,
                    o => o.MapFrom(s => s.Responsable.Nombre + " " + s.Responsable.Apellido))
                .ForMember(d => d.SupervisorInternoNombre,
                    o => o.MapFrom(s => s.SupervisorInterno != null
                        ? s.SupervisorInterno.Nombre + " " + s.SupervisorInterno.Apellido
                        : null))
                .ForMember(d => d.SupervisorExternoNombre,
                    o => o.MapFrom(s => s.SupervisorExterno != null
                        ? s.SupervisorExterno.Nombre + " " + s.SupervisorExterno.Apellido
                        : null))
                .ForMember(d => d.OportunidadNombre,
                    o => o.MapFrom(s => s.Oportunidad != null ? s.Oportunidad.NombreProyecto : null))
                .ForMember(d => d.EmpresaId,
                    o => o.MapFrom(s => s.Oportunidad != null ? (int?)s.Oportunidad.EmpresaId : null))
                .ForMember(d => d.EmpresaNombre,
                    o => o.MapFrom(s => s.Oportunidad != null && s.Oportunidad.Empresa != null
                        ? s.Oportunidad.Empresa.Nombre
                        : null))
                .ForMember(d => d.Fases,
    o => o.MapFrom(s =>
        string.IsNullOrEmpty(s.FasesJson)
            ? CrearProyectoDto.GenerarFasesDefault()
            : JsonSerializer.Deserialize<List<FaseProyectoDto>>(
                s.FasesJson,
                new JsonSerializerOptions()
              )
    ));

            CreateMap<CrearProyectoDto, Proyecto>()
                .ForMember(d => d.FasesJson,
                    o => o.MapFrom(s => System.Text.Json.JsonSerializer.Serialize(s.Fases, (System.Text.Json.JsonSerializerOptions?)null)))
                .ForMember(d => d.FechaCreacion, o => o.Ignore())
                .ForMember(d => d.FechaUltimaModificacion, o => o.Ignore());

            CreateMap<ActualizarProyectoDto, Proyecto>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.FasesJson,
                    o => o.MapFrom(s => System.Text.Json.JsonSerializer.Serialize(s.Fases, (System.Text.Json.JsonSerializerOptions?)null)))
                .ForMember(d => d.FechaCreacion, o => o.Ignore())
                .ForMember(d => d.FechaUltimaModificacion,
                    o => o.MapFrom(_ => DateTime.UtcNow));

            CreateMap<PagoProyecto, PagoProyectoDto>()
                .ForMember(d => d.AuditInfo,
                    o => o.MapFrom(s => MapAuditInfo(s)));

            CreateMap<PagoProyectoDto, PagoProyecto>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.ProyectoId, o => o.Ignore())
                .ForMember(d => d.Proyecto, o => o.Ignore())
                .ForMember(d => d.FechaCreacion, o => o.Ignore())
                .ForMember(d => d.FechaUltimaModificacion,
                    o => o.MapFrom(_ => DateTime.UtcNow));
            // PROPUESTA
            CreateMap<CrearPropuestaDto, Propuesta>();
            CreateMap<Propuesta, PropuestaDto>()
                .ForMember(d => d.AuditInfo,
                    o => o.MapFrom(s => MapAuditInfo(s)));

            CreateMap<Pais, PaisDto>();
            CreateMap<Ciudad, CiudadDto>();

            // TABLAS CATALOGO
            CreateMap<Pais, CatalogoDto>();
            CreateMap<Ciudad, CatalogoDto>();

            // PREFIJO TELEFONICO
            CreateMap<PrefijoTelefonico, PrefijoTelefonicoDto>();

            //MARKETING
            CreateMap<PublicacionRedSocial, PublicacionRedSocialDto>();

            CreateMap<MetricaPublicacion, MetricaPublicacionDto>();

            CreateMap<RedSocialPublicacionDto, PublicacionRedSocial>();

            CreateMap<PublicacionMarketing, PublicacionMarketingDto>()
                .ForMember(d => d.AuditInfo,
                    o => o.MapFrom(s => MapAuditInfo(s)))
                .ForMember(d => d.ResponsableNombre,
                    o => o.MapFrom(s =>
                        s.Responsable.Nombre + " " + s.Responsable.Apellido));

            CreateMap<CrearPublicacionMarketingDto, PublicacionMarketing>();

            CreateMap<ArchivoPublicacionMarketing, ArchivoPublicacionDto>();

            CreateMap<ArchivoPublicacionDto, ArchivoPublicacionMarketing>();

            CreateMap<ActualizarPublicacionMarketingDto, PublicacionMarketing>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.FechaCreacion, o => o.Ignore())
                .ForMember(d => d.FechaActualizacion,
                    o => o.MapFrom(_ => DateTime.UtcNow));
        }

        private static string GetDisplayName(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttribute<DisplayAttribute>();
            return attribute?.Name ?? value.ToString();
        }

        private static AuditInfoDto MapAuditInfo(AuditableEntity entity)
        {
            return new AuditInfoDto
            {
                CreatedByUserId = entity.CreatedByUserId,
                CreatedByUserName = FormatUserName(entity.CreatedByUser),
                CreatedAt = entity.CreatedAt,
                ModifiedByUserId = entity.ModifiedByUserId,
                ModifiedByUserName = FormatUserName(entity.ModifiedByUser),
                ModifiedAt = entity.ModifiedAt
            };
        }

        private static string? FormatUserName(Usuario? usuario)
        {
            if (usuario is null)
                return null;

            var fullName = $"{usuario.Nombre} {usuario.Apellido}".Trim();
            return string.IsNullOrWhiteSpace(fullName) ? usuario.Email : fullName;
        }
    }
}
