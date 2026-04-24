using AutoMapper;
using DrakionTech.Crm.Business.DTOs.Actividad;
using DrakionTech.Crm.Business.DTOs.Catalogo;
using DrakionTech.Crm.Business.DTOs.Contacto;
using DrakionTech.Crm.Business.DTOs.Empresa;
using DrakionTech.Crm.Business.DTOs.Oportunidad;
using DrakionTech.Crm.Business.DTOs.PrefijoTelefonico;
using DrakionTech.Crm.Business.DTOs.Propuesta;
using DrakionTech.Crm.Business.DTOs.Ubicacion;
using DrakionTech.Crm.Business.DTOs.UsuarioInterno;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

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
                .ForMember(dest => dest.PaisNombre,
                    opt => opt.MapFrom(src => src.Pais != null ? src.Pais.Nombre : string.Empty))
                .ForMember(dest => dest.CiudadNombre,
                    opt => opt.MapFrom(src => src.Ciudad != null ? src.Ciudad.Nombre : string.Empty))
                .ForMember(dest => dest.SectorNombre,
                    opt => opt.MapFrom(src => src.Sector != null ? src.Sector.Nombre : string.Empty))
                .ForMember(dest => dest.EstadoNombre,
                    opt => opt.MapFrom(src => src.Estado != null ? src.Estado.Nombre : string.Empty));

            // CONTACTO
            CreateMap<CrearContactoDto, Contacto>()
                .ForMember(dest => dest.RolContactoId,
                    opt => opt.MapFrom(src => src.RolContactoId));

            CreateMap<ActualizarContactoDto, Contacto>()
                .ForMember(dest => dest.RolContactoId,
                    opt => opt.MapFrom(src => src.RolContactoId));

            CreateMap<Contacto, ContactoDto>()
                .ForMember(dest => dest.EmpresaNombre,
                    opt => opt.MapFrom(src => src.Empresa!.Nombre))
                .ForMember(dest => dest.RolNombre,
                    opt => opt.MapFrom(src => src.RolContacto!.Nombre));

            // OPORTUNIDAD
            CreateMap<CrearOportunidadDto, Oportunidad>();
            CreateMap<ActualizarOportunidadDto, Oportunidad>();
            CreateMap<Oportunidad, OportunidadDto>()
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
            CreateMap<CrearActividadDto, Actividad>()
    .ForMember(d => d.Inicio,
        o => o.MapFrom(s => s.Fecha));
            CreateMap<ActualizarActividadDto, Actividad>()
    .ForMember(d => d.Inicio,
        o => o.MapFrom(s => s.Fecha));
            CreateMap<TipoActividad, TipoActividadDto>();
            CreateMap<Actividad, ActividadDto>()
             .ForMember(d => d.Fecha,
                 o => o.MapFrom(s => s.Inicio))
             .ForMember(d => d.EmpresaNombre,
                 o => o.MapFrom(s => s.Empresa!.Nombre))
             .ForMember(d => d.ContactoNombre,
                 o => o.MapFrom(s =>
                     s.Contacto != null
                         ? $"{s.Contacto.Nombre} {s.Contacto.Apellido}"
                         : null))
             .ForMember(d => d.OportunidadNombre,
                 o => o.MapFrom(s =>
                     s.Oportunidad != null
                         ? s.Oportunidad.NombreProyecto
                         : null));

            // PROPUESTA
            CreateMap<CrearPropuestaDto, Propuesta>();
            CreateMap<Propuesta, PropuestaDto>();

            CreateMap<Pais, PaisDto>();
            CreateMap<Ciudad, CiudadDto>();

            // TABLAS CATALOGO
            CreateMap<Sector, CatalogoDto>();
            CreateMap<Estado, CatalogoDto>();
            CreateMap<Pais, CatalogoDto>();
            CreateMap<Ciudad, CatalogoDto>();

            // PREFIJO TELEFONICO
            CreateMap<PrefijoTelefonico, PrefijoTelefonicoDto>();

            // USUARIO INTERNO
            CreateMap<CrearUsuarioInternoDto, UsuarioInterno>();
            CreateMap<ActualizarUsuarioInternoDto, UsuarioInterno>();
            CreateMap<UsuarioInterno, UsuarioInternoDto>();
        }

        private static string GetDisplayName(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttribute<DisplayAttribute>();
            return attribute?.Name ?? value.ToString();
        }
    }
}