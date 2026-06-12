using AutoMapper;
using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Business.DTOs.Proyecto;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data;
using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Entities.Enums;
using DrakionTech.Crm.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DrakionTech.Crm.Business.Services;

public class ProyectoService : IProyectoService
{
    private readonly IProyectoRepository _repository;
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public ProyectoService(IProyectoRepository repository, IMapper mapper, ApplicationDbContext context)
    {
        _repository = repository;
        _mapper = mapper;
        _context = context;
    }
    public async Task<List<ProyectoDto>> ObtenerTodosAsync()
    {
        var proyectos = await _repository.ObtenerTodosAsync();
        return _mapper.Map<List<ProyectoDto>>(proyectos);
    }

    public async Task<ResultadoPaginacion<ProyectoDto>> ObtenerTodosConPaginacionAsync(
    string? busqueda = null,
    int pagina = 1,
    int tamañoPagina = 10)
    {
        var query = _repository.Query();

        if (!string.IsNullOrWhiteSpace(busqueda))
        {
            var term = busqueda.Trim().ToLower();

            query = query.Where(p =>
                p.Nombre.ToLower().Contains(term) ||
                p.Area.Nombre.ToLower().Contains(term) ||
                p.Responsable.Nombre.ToLower().Contains(term) ||
                p.Responsable.Apellido.ToLower().Contains(term));
        }

        var paginado = await query
            .OrderBy(p => p.Nombre)
            .PaginarAsync(pagina, tamañoPagina);

        return new ResultadoPaginacion<ProyectoDto>
        {
            Items = _mapper.Map<List<ProyectoDto>>(paginado.Items),
            TotalRegistros = paginado.TotalRegistros,
            Pagina = paginado.Pagina,
            TamañoPagina = paginado.TamañoPagina
        };
    }

    public async Task<ProyectoDto?> ObtenerPorIdAsync(int id)
    {
        var proyecto = await _repository.ObtenerPorIdAsync(id);
        return proyecto is null ? null : _mapper.Map<ProyectoDto>(proyecto);
    }
    public async Task CrearAsync(CrearProyectoDto dto)
    {
        await ValidarResponsableEnAreaAsync(dto.AreaId, dto.ResponsableId);
        await ValidarSupervisoresAsync(dto.OportunidadId, dto.SupervisorInternoId, dto.SupervisorExternoId);
        var proyecto = _mapper.Map<Proyecto>(dto);
        await _repository.AgregarAsync(proyecto);
    }

    public async Task ActualizarAsync(ActualizarProyectoDto dto)
    {
        var proyecto = await _repository.ObtenerPorIdAsync(dto.Id)
            ?? throw new KeyNotFoundException($"Proyecto {dto.Id} no encontrado.");

        await ValidarResponsableEnAreaAsync(dto.AreaId, dto.ResponsableId);
        await ValidarSupervisoresAsync(dto.OportunidadId, dto.SupervisorInternoId, dto.SupervisorExternoId);

        _mapper.Map(dto, proyecto);
        await _repository.ActualizarAsync(proyecto);
    }

    public async Task EliminarAsync(int id)
    {
        var proyecto = await _repository.ObtenerPorIdAsync(id)
            ?? throw new KeyNotFoundException($"Proyecto {id} no encontrado.");
        await _repository.EliminarAsync(proyecto);
    }

    // ─── Validación ───────────────────────────────────────────────────────────
    private async Task ValidarResponsableEnAreaAsync(int areaId, int responsableId)
    {
        var perteneceAlArea = await _context.Usuarios
            .AnyAsync(u => u.Id == responsableId && u.AreaId == areaId);

        if (!perteneceAlArea)
            throw new InvalidOperationException(
                "El responsable seleccionado no pertenece al área asociada al proyecto.");
    }

    private async Task ValidarSupervisoresAsync(
        int? oportunidadId,
        int? supervisorInternoId,
        int? supervisorExternoId)
    {
        if (!oportunidadId.HasValue)
            throw new InvalidOperationException("Selecciona una oportunidad para el proyecto.");

        var oportunidad = await _context.Oportunidades
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == oportunidadId.Value);

        if (oportunidad is null)
            throw new InvalidOperationException("La oportunidad seleccionada no existe.");

        if (supervisorInternoId.HasValue)
        {
            var existeUsuario = await _context.Usuarios
                .AnyAsync(u => u.Id == supervisorInternoId.Value && u.IsActive);

            if (!existeUsuario)
                throw new InvalidOperationException("El supervisor interno seleccionado no existe o no está activo.");
        }

        if (supervisorExternoId.HasValue)
        {
            var contactoPerteneceEmpresa = await _context.Contactos
                .AnyAsync(c => c.Id == supervisorExternoId.Value && c.EmpresaId == oportunidad.EmpresaId);

            if (!contactoPerteneceEmpresa)
                throw new InvalidOperationException("El supervisor externo debe ser un contacto de la empresa asociada a la oportunidad.");
        }
    }

    public async Task CambiarEtapaAsync(CambiarEtapaProyectoDto dto)
    {
        var proyecto = await _repository.ObtenerPorIdAsync(dto.ProyectoId)
            ?? throw new KeyNotFoundException($"Proyecto {dto.ProyectoId} no encontrado.");

        var fechaCambio = DateTime.UtcNow;
        var historial = new HistorialEtapaProyecto
        {
            ProyectoId = dto.ProyectoId,
            EtapaAnterior = proyecto.EtapaFlujo,
            EtapaNueva = dto.NuevaEtapa,
            PorcentajeIva = dto.PorcentajeIva,
            ValorCalculado = dto.ValorCalculado,
            Observaciones = dto.Observaciones,
            FechaCambio = fechaCambio
        };

        SincronizarFaseJson(proyecto, dto, fechaCambio);
        proyecto.EtapaFlujo = dto.NuevaEtapa;

        _context.HistorialesEtapaProyecto.Add(historial);
        await _repository.ActualizarAsync(proyecto);
    }

    private static void SincronizarFaseJson(
        Proyecto proyecto,
        CambiarEtapaProyectoDto dto,
        DateTime fechaCambio)
    {
        var fases = DeserializarFases(proyecto.FasesJson);
        var fasesDeEtapa = fases
            .Where(f => f.EtapaFlujo == dto.NuevaEtapa)
            .ToList();

        if (fasesDeEtapa.Count > 1)
        {
            throw new InvalidOperationException(
                $"El proyecto tiene más de una fase asociada a la etapa {dto.NuevaEtapa}.");
        }

        var fase = fasesDeEtapa.SingleOrDefault();
        if (fase is null)
        {
            var requiereBackfill = fases.Any(f => !f.EtapaFlujo.HasValue);
            var mensaje = requiereBackfill
                ? "No se puede actualizar FasesJson porque una o más fases no tienen EtapaFlujo. Realiza el backfill de FasesJson antes de cambiar la etapa del proyecto."
                : $"No existe una fase asociada a la etapa {dto.NuevaEtapa} en FasesJson.";

            throw new InvalidOperationException(mensaje);
        }

        fase.Iva = dto.PorcentajeIva ?? fase.Iva;
        fase.ValorCalculado = dto.ValorCalculado ?? fase.ValorCalculado;
        fase.Observaciones = dto.Observaciones;
        fase.FechaInicio ??= fechaCambio;
        fase.FechaFin = fechaCambio;
        fase.PorcentajeAvance = 100;
        fase.Completada = true;

        proyecto.FasesJson = JsonSerializer.Serialize(fases, (JsonSerializerOptions?)null);
        proyecto.FechaUltimaModificacion = fechaCambio;
    }

    private static List<FaseProyectoDto> DeserializarFases(string? fasesJson)
    {
        if (string.IsNullOrWhiteSpace(fasesJson))
            return CrearProyectoDto.GenerarFasesDefault();

        try
        {
            return JsonSerializer.Deserialize<List<FaseProyectoDto>>(
                fasesJson,
                new JsonSerializerOptions()) ?? new List<FaseProyectoDto>();
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException("FasesJson no tiene un formato JSON válido.", ex);
        }
    }

    public EtapaFlujoProyecto? ObtenerSiguienteEtapa(EtapaFlujoProyecto actual)
    {
        int siguiente = (int)actual + 1;
        int max = (int)EtapaFlujoProyecto.CierreProyecto;
        if (siguiente > max) return null;
        return (EtapaFlujoProyecto)siguiente;
    }

    public async Task AgregarPagoAsync(int proyectoId, PagoProyectoDto dto)
    {
        var existeProyecto = await _context.Proyectos.AnyAsync(p => p.Id == proyectoId);
        if (!existeProyecto)
            throw new KeyNotFoundException($"Proyecto {proyectoId} no encontrado.");

        ValidarPago(dto);

        var pago = _mapper.Map<PagoProyecto>(dto);
        pago.ProyectoId = proyectoId;
        pago.FechaCreacion = DateTime.UtcNow;

        _context.PagosProyecto.Add(pago);
        await _context.SaveChangesAsync();
    }

    public async Task ActualizarPagoAsync(int proyectoId, PagoProyectoDto dto)
    {
        var pago = await _context.PagosProyecto
            .FirstOrDefaultAsync(p => p.Id == dto.Id && p.ProyectoId == proyectoId)
            ?? throw new KeyNotFoundException($"Pago {dto.Id} no encontrado.");

        ValidarPago(dto);

        pago.Valor = dto.Valor;
        pago.FechaProgramada = dto.FechaProgramada;
        pago.FechaPago = dto.FechaPago;
        pago.Estado = dto.Estado;
        pago.DiasAnticipacionRecordatorio = dto.DiasAnticipacionRecordatorio;
        pago.DescripcionRecordatorio = dto.DescripcionRecordatorio;
        pago.FechaUltimaModificacion = DateTime.UtcNow;

        await _context.SaveChangesAsync();
    }

    public async Task EliminarPagoAsync(int proyectoId, int pagoId)
    {
        var pago = await _context.PagosProyecto
            .FirstOrDefaultAsync(p => p.Id == pagoId && p.ProyectoId == proyectoId)
            ?? throw new KeyNotFoundException($"Pago {pagoId} no encontrado.");

        _context.PagosProyecto.Remove(pago);
        await _context.SaveChangesAsync();
    }

    private static void ValidarPago(PagoProyectoDto dto)
    {
        if (dto.Valor <= 0)
            throw new InvalidOperationException("El valor del pago debe ser mayor a cero.");

        if (dto.DiasAnticipacionRecordatorio is < 0)
            throw new InvalidOperationException("Los días de anticipación no pueden ser negativos.");

        if (dto.Estado == EstadoPagoProyecto.Pagado && dto.FechaPago is null)
            dto.FechaPago = DateTime.Today;
    }
}
