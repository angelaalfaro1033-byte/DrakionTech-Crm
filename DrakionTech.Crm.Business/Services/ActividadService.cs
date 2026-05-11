using AutoMapper;
using DrakionTech.Crm.Business.DTOs.Actividad;
using DrakionTech.Crm.Business.Exceptions;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Repositories;

namespace DrakionTech.Crm.Business.Services
{
    public class ActividadService : IActividadService
    {
        private readonly IActividadRepository _actividadRepository;
        private readonly IMapper _mapper;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IContactoRepository _contactoRepository;
        private readonly IOportunidadRepository _oportunidadRepository;
        private readonly IUsuarioInternoRepository _usuarioInternoRepository;
        private readonly IEstadoActividadRepository _estadoActividadRepository;
        private readonly ITipoActividadRepository _tipoActividadRepository;
        private readonly IWhatsAppNotificationService _whatsapp;


        public ActividadService(
             IActividadRepository actividadRepository,
             IMapper mapper,
             IEmpresaRepository empresaRepository,
             IContactoRepository contactoRepository,
             IOportunidadRepository oportunidadRepository,
             ITipoActividadRepository tipoActividadRepository,
             IWhatsAppNotificationService whatsapp
         )  
        {
            _actividadRepository = actividadRepository;
            _mapper = mapper;
            _empresaRepository = empresaRepository;
            _contactoRepository = contactoRepository;
            _oportunidadRepository = oportunidadRepository;
            _tipoActividadRepository = tipoActividadRepository;
            _whatsapp = whatsapp;
        }

        public async Task<IEnumerable<TipoActividadDto>> ObtenerTiposActividadAsync(
    CancellationToken ct = default)
        {
            var tipos = await _tipoActividadRepository.GetAllAsync(ct);

            return _mapper.Map<IEnumerable<TipoActividadDto>>(tipos);
        }

        public async Task<int> CrearAsync(
    CrearActividadDto dto,
    CancellationToken ct = default)
        {
            var actividad = _mapper.Map<Actividad>(dto);

            await _actividadRepository.AddAsync(actividad, ct);

            try
            {
                await _whatsapp.EnviarTemplateAsync(
                    "573223032562",
                    "hello_world"
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error WhatsApp: {ex.Message}");
            }

            return actividad.Id;
        }

        public async Task ActualizarAsync(
            int actividadId,
            ActualizarActividadDto dto,
            CancellationToken ct = default)
        {
            var actividad = await _actividadRepository.GetByIdAsync(actividadId, ct)
                ?? throw new EntidadNoEncontradaException("Actividad", actividadId);

            _mapper.Map(dto, actividad);

            await _actividadRepository.UpdateAsync(actividad, ct);
        }

        public async Task<ActividadDto> ObtenerPorIdAsync(
            int actividadId,
            CancellationToken ct = default)
        {
            var actividad = await _actividadRepository.GetByIdAsync(actividadId, ct)
                ?? throw new EntidadNoEncontradaException("Actividad", actividadId);

            return _mapper.Map<ActividadDto>(actividad);
        }

        public async Task<IEnumerable<ActividadDto>> ObtenerPorEmpresaAsync(
            int empresaId,
            CancellationToken ct = default)
        {
            var actividades = await _actividadRepository.GetByEmpresaIdAsync(empresaId, ct);
            return _mapper.Map<IEnumerable<ActividadDto>>(actividades);
        }

        public async Task<IEnumerable<ActividadDto>> ObtenerPorOportunidadAsync(
            int oportunidadId,
            CancellationToken ct = default)
        {
            var actividades = await _actividadRepository.GetByOportunidadIdAsync(oportunidadId, ct);
            return _mapper.Map<IEnumerable<ActividadDto>>(actividades);
        }

        public async Task<DashboardActividadDto> ObtenerDashboardAsync(
            int UsuarioId,
            string? busqueda = null,
            string? filtroEstado = null,
            CancellationToken ct = default)
        {
            var entidades = await _actividadRepository
                .GetDashboardByUsuarioAsync(UsuarioId, ct);

            var ahora = DateTime.UtcNow;
            var limiteProxima = ahora.AddDays(3);

            var actividades = entidades.Select(a =>
            {
                var dto = _mapper.Map<ActividadDto>(a);
                var fechaVenc = a.Fin ?? a.Inicio;

                dto.ClasificacionEstado = fechaVenc < ahora
                    ? "Vencida"
                    : fechaVenc <= limiteProxima
                        ? "ProximaAVencer"
                        : "Pendiente";

                dto.TiempoRelativo = CalcularTiempoRelativo(fechaVenc, ahora);

                return dto;
            }).ToList();

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                var texto = busqueda.Trim().ToLower();
                actividades = actividades.Where(a =>
                    (a.EmpresaNombre?.ToLower().Contains(texto) ?? false) ||
                    (a.OportunidadNombre?.ToLower().Contains(texto) ?? false) ||
                    (a.TipoActividadNombre?.ToLower().Contains(texto) ?? false)
                ).ToList();
            }

            if (!string.IsNullOrWhiteSpace(filtroEstado) && filtroEstado != "Todas")
            {
                actividades = actividades
                    .Where(a => a.ClasificacionEstado == filtroEstado)
                    .ToList();
            }

            var totalVencidas = actividades.Count(a => a.ClasificacionEstado == "Vencida");
            var totalProximas = actividades.Count(a => a.ClasificacionEstado == "ProximaAVencer");
            var totalPendientes = actividades.Count(a => a.ClasificacionEstado == "Pendiente");

            var ordenadas = actividades
                .OrderBy(a => a.ClasificacionEstado switch
                {
                    "Vencida" => 0,
                    "ProximaAVencer" => 1,
                    _ => 2
                })
                .ThenBy(a => a.FechaVencimiento)
                .ToList();

            return new DashboardActividadDto
            {
                TotalVencidas = totalVencidas,
                TotalProximasAVencer = totalProximas,
                TotalPendientes = totalPendientes,
                Actividades = ordenadas
            };
        }

        private static string CalcularTiempoRelativo(DateTime fechaVenc, DateTime ahora)
        {
            var diff = fechaVenc.Date - ahora.Date;

            return diff.Days switch
            {
                < -1 => $"Hace {Math.Abs(diff.Days)} días",
                -1 => "Ayer",
                0 => "Hoy",
                1 => "Mañana",
                _ => $"En {diff.Days} días"
            };
        }
    }
}