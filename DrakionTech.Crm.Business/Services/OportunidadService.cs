using AutoMapper;
using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Business.DTOs;
using DrakionTech.Crm.Business.DTOs.Oportunidad;
using DrakionTech.Crm.Business.Exceptions;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Entities.Enums;
using DrakionTech.Crm.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Business.Services;

public class OportunidadService : IOportunidadService
{
    private readonly IOportunidadRepository _oportunidadRepository;
    private readonly IEmpresaRepository _empresaRepository;
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    // Flujo lineal de etapas
    private static readonly List<EtapaOportunidad> _flujo = new()
    {
        EtapaOportunidad.LlamadaInicial,
        EtapaOportunidad.ReunionReconocimiento,
        EtapaOportunidad.PreparacionPropuesta,
        EtapaOportunidad.EnvioPropuesta,
        EtapaOportunidad.SeguimientoPropuesta,
        EtapaOportunidad.SocializacionPropuesta,
        EtapaOportunidad.AjustesPropuesta,
        EtapaOportunidad.PreparacionContrato,
        EtapaOportunidad.EnvioContrato,
        EtapaOportunidad.Firmado
    };

    public OportunidadService(
        IOportunidadRepository oportunidadRepository,
        IEmpresaRepository empresaRepository,
        IMapper mapper,
        ApplicationDbContext context)
    {
        _oportunidadRepository = oportunidadRepository;
        _empresaRepository = empresaRepository;
        _mapper = mapper;
        _context = context;
    }

    public async Task<int> CrearAsync(CrearOportunidadDto dto, CancellationToken ct = default)
    {
        var existeEmpresa = await _empresaRepository.ExisteAsync(dto.EmpresaId, ct);
        if (!existeEmpresa)
            throw new ReglaNegocioException(MensajesError.EmpresaAsociadaNoExiste);

        if (string.IsNullOrWhiteSpace(dto.NombreProyecto))
            throw new ReglaNegocioException(MensajesError.NombreProyectoObligatorio);

        var oportunidad = _mapper.Map<Oportunidad>(dto);
        oportunidad.Etapa = EtapaOportunidad.LlamadaInicial;

        await _oportunidadRepository.AgregarAsync(oportunidad, ct);
        return oportunidad.Id;
    }

    public async Task ActualizarAsync(int oportunidadId, ActualizarOportunidadDto dto, CancellationToken ct = default)
    {
        var oportunidad = await _oportunidadRepository.ObtenerPorIdAsync(oportunidadId, ct)
            ?? throw new EntidadNoEncontradaException("Oportunidad", oportunidadId);

        _mapper.Map(dto, oportunidad);
        await _oportunidadRepository.ActualizarAsync(oportunidad, ct);
    }

    public async Task<OportunidadDto> ObtenerPorIdAsync(int oportunidadId, CancellationToken ct = default)
    {
        var oportunidad = await _oportunidadRepository.ObtenerPorIdAsync(oportunidadId, ct)
            ?? throw new EntidadNoEncontradaException("Oportunidad", oportunidadId);

        return _mapper.Map<OportunidadDto>(oportunidad);
    }

    public async Task<IEnumerable<OportunidadDto>> ObtenerPorEmpresaAsync(int empresaId, CancellationToken ct = default)
    {
        var oportunidades = await _oportunidadRepository.ObtenerPorEmpresaIdAsync(empresaId, ct);
        return _mapper.Map<IEnumerable<OportunidadDto>>(oportunidades);
    }

    public async Task<IEnumerable<OportunidadDto>> ObtenerTodasAsync(CancellationToken ct = default)
    {
        var oportunidades = await _context.Oportunidades
            .Include(o => o.Empresa)
            .Include(o => o.ContactoPrincipal)
            .AsNoTracking()
            .ToListAsync(ct);
        return _mapper.Map<IEnumerable<OportunidadDto>>(oportunidades);
    }

    public async Task CambiarEtapaAsync(CambiarEtapaDto dto, CancellationToken ct = default)
    {
        var oportunidad = await _context.Oportunidades
            .FirstOrDefaultAsync(o => o.Id == dto.OportunidadId, ct)
            ?? throw new EntidadNoEncontradaException("Oportunidad", dto.OportunidadId);

        // Validar que la etapa nueva sea la siguiente en el flujo
        var siguiente = ObtenerSiguienteEtapa(oportunidad.Etapa);
        if (siguiente != dto.NuevaEtapa)
            throw new ReglaNegocioException(
                $"No se puede pasar de '{GetDisplayName(oportunidad.Etapa)}' a '{GetDisplayName(dto.NuevaEtapa)}' directamente.");

        // Si es Firmado, validar que vengan área y responsable
        if (dto.NuevaEtapa == EtapaOportunidad.Firmado)
        {
            if (!dto.AreaId.HasValue || !dto.ResponsableId.HasValue)
                throw new ReglaNegocioException(
                    "Para marcar como Firmado debes asignar un área y un responsable al proyecto.");

            await CrearProyectoDesdeOportunidadAsync(oportunidad, dto.AreaId.Value, dto.ResponsableId.Value);
        }

        // Guardar historial
        var historial = new HistorialCambioOportunidad
        {
            OportunidadId = oportunidad.Id,
            EtapaAnterior = oportunidad.Etapa,
            EtapaNueva = dto.NuevaEtapa,
            FechaCambio = DateTime.UtcNow,
            UsuarioId = dto.UsuarioId
        };

        _context.HistorialCambiosOportunidad.Add(historial);
        oportunidad.Etapa = dto.NuevaEtapa;

        await _context.SaveChangesAsync(ct);
    }

    public EtapaOportunidad? ObtenerSiguienteEtapa(EtapaOportunidad actual)
    {
        var idx = _flujo.IndexOf(actual);
        if (idx < 0 || idx >= _flujo.Count - 1) return null;
        return _flujo[idx + 1];
    }

    public IEnumerable<OpcionEnumDto> ObtenerEtapas()
    {
        return _flujo.Select(e => new OpcionEnumDto
        {
            Valor = (int)e,
            Nombre = GetDisplayName(e)
        });
    }

    // ─── Privados ─────────────────────────────────────────────────────────────

    private async Task CrearProyectoDesdeOportunidadAsync(
        Oportunidad oportunidad, int areaId, int responsableId)
    {
        // Validar que responsable pertenezca al área
        var perteneceAlArea = await _context.Usuarios
            .AnyAsync(u => u.Id == responsableId && u.AreaId == areaId);

        if (!perteneceAlArea)
            throw new ReglaNegocioException(
                "El responsable seleccionado no pertenece al área indicada.");

        var proyecto = new Proyecto
        {
            Nombre = oportunidad.NombreProyecto,
            Descripcion = oportunidad.Descripcion,
            Estado = EstadoProyecto.Planificado,
            FechaInicio = DateTime.UtcNow,
            FechaFin = oportunidad.FechaEstimadaCierre,
            AreaId = areaId,
            ResponsableId = responsableId,
            OportunidadId = oportunidad.Id
        };

        _context.Proyectos.Add(proyecto);
    }

    private static string GetDisplayName(EtapaOportunidad etapa)
    {
        var field = etapa.GetType().GetField(etapa.ToString());
        var attr = field?.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), false)
            .FirstOrDefault() as System.ComponentModel.DataAnnotations.DisplayAttribute;
        return attr?.Name ?? etapa.ToString();
    }
}