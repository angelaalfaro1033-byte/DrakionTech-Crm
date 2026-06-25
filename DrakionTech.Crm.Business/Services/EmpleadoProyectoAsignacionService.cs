using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Business.DTOs.AsignacionProyecto;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Business.Services;

public class EmpleadoProyectoAsignacionService : IEmpleadoProyectoAsignacionService
{
    private readonly IEmpleadoProyectoAsignacionRepository _repository;
    private readonly ApplicationDbContext _context;

    public EmpleadoProyectoAsignacionService(
        IEmpleadoProyectoAsignacionRepository repository,
        ApplicationDbContext context)
    {
        _repository = repository;
        _context = context;
    }

    public async Task<List<AsignacionProyectoListDto>> ObtenerTodosAsync(
        int? empleadoId = null,
        int? proyectoId = null,
        bool? soloActivas = null)
    {
        var query = _repository.Query();

        if (empleadoId.HasValue)
            query = query.Where(a => a.EmpleadoId == empleadoId.Value);

        if (proyectoId.HasValue)
            query = query.Where(a => a.ProyectoId == proyectoId.Value);

        if (soloActivas.HasValue)
            query = query.Where(a => a.Activa == soloActivas.Value);

        var asignaciones = await query
            .OrderByDescending(a => a.Activa)
            .ThenBy(a => a.Proyecto.Nombre)
            .ThenBy(a => a.Empleado.Nombre)
            .ToListAsync();

        return asignaciones
            .Select(MapToDto)
            .ToList();
    }

    public async Task<AsignacionProyectoListDto> ObtenerPorIdAsync(int id)
    {
        var asignacion = await _repository.ObtenerPorIdAsync(id)
            ?? throw new KeyNotFoundException($"Asignacion {id} no encontrada.");

        return MapToDto(asignacion);
    }

    public async Task<List<ReporteAsignacionProyectoDto>> ObtenerSinAsignacionAsync()
    {
        var empleados = await _repository.ObtenerEmpleadosActivosSinAsignacionActivaAsync();

        return empleados
            .Select(e => new ReporteAsignacionProyectoDto
            {
                EmpleadoId = e.Id,
                EmpleadoNombre = $"{e.Nombre} {e.Apellido}".Trim(),
                Rol = ObtenerRolEmpleado(e),
                CantidadProyectos = 0,
                Estado = "Disponible"
            })
            .ToList();
    }

    public async Task<List<ReporteAsignacionProyectoDto>> ObtenerMultiplesProyectosAsync()
    {
        var asignaciones = await _repository.ObtenerAsignacionesActivasAsync();

        return asignaciones
            .GroupBy(a => a.Empleado)
            .Where(g => g.Count() > 1)
            .Select(g => new ReporteAsignacionProyectoDto
            {
                EmpleadoId = g.Key.Id,
                EmpleadoNombre = $"{g.Key.Nombre} {g.Key.Apellido}".Trim(),
                Rol = ObtenerRolEmpleado(g.Key),
                CantidadProyectos = g.Count(),
                Proyectos = string.Join(", ", g.Select(a => a.Proyecto.Nombre).OrderBy(nombre => nombre)),
                Estado = ClasificarCarga(g.Count())
            })
            .OrderByDescending(r => r.CantidadProyectos)
            .ThenBy(r => r.EmpleadoNombre)
            .ToList();
    }

    public async Task<List<ReporteAsignacionProyectoDto>> ObtenerDistribucionCargaAsync()
    {
        var empleados = await _context.Empleados
            .Include(e => e.RolUsuario)
            .Include(e => e.EspecialidadNavigation)
            .Where(e => e.Activo)
            .OrderBy(e => e.Nombre)
            .ThenBy(e => e.Apellido)
            .ToListAsync();

        var asignacionesActivas = await _repository.ObtenerAsignacionesActivasAsync();
        var asignacionesPorEmpleado = asignacionesActivas
            .GroupBy(a => a.EmpleadoId)
            .ToDictionary(g => g.Key, g => g.ToList());

        return empleados
            .Select(e =>
            {
                var asignacionesEmpleado = asignacionesPorEmpleado.GetValueOrDefault(e.Id) ?? new List<EmpleadoProyectoAsignacion>();
                var cantidad = asignacionesEmpleado.Count;

                return new ReporteAsignacionProyectoDto
                {
                    EmpleadoId = e.Id,
                    EmpleadoNombre = $"{e.Nombre} {e.Apellido}".Trim(),
                    Rol = ObtenerRolEmpleado(e),
                    CantidadProyectos = cantidad,
                    Proyectos = string.Join(", ", asignacionesEmpleado.Select(a => a.Proyecto.Nombre).OrderBy(nombre => nombre)),
                    Estado = ClasificarCarga(cantidad)
                };
            })
            .ToList();
    }

    public async Task CrearAsync(CrearAsignacionProyectoDto dto)
    {
        await ValidarEmpleadoYProyectoAsync(dto.EmpleadoId, dto.ProyectoId);
        ValidarFechas(dto.FechaInicio, null);

        var asignacionActiva = await _repository.ObtenerActivaAsync(dto.EmpleadoId, dto.ProyectoId);
        if (asignacionActiva is not null)
            throw new InvalidOperationException("El empleado ya tiene una asignacion activa en este proyecto.");

        var asignacion = new EmpleadoProyectoAsignacion
        {
            EmpleadoId = dto.EmpleadoId,
            ProyectoId = dto.ProyectoId,
            FechaInicio = dto.FechaInicio,
            Activa = true,
            RolEnProyecto = dto.RolEnProyecto,
            Observaciones = dto.Observaciones
        };

        await _repository.AgregarAsync(asignacion);
    }

    public async Task ActualizarAsync(ActualizarAsignacionProyectoDto dto)
    {
        var asignacion = await _repository.ObtenerPorIdAsync(dto.Id)
            ?? throw new KeyNotFoundException($"Asignacion {dto.Id} no encontrada.");

        ValidarFechas(dto.FechaInicio, dto.FechaFin);

        asignacion.FechaInicio = dto.FechaInicio;
        asignacion.FechaFin = dto.FechaFin;
        asignacion.Activa = !dto.FechaFin.HasValue;
        asignacion.RolEnProyecto = dto.RolEnProyecto;
        asignacion.Observaciones = dto.Observaciones;

        if (asignacion.Activa)
        {
            var asignacionActiva = await _repository.ObtenerActivaAsync(asignacion.EmpleadoId, asignacion.ProyectoId);
            if (asignacionActiva is not null && asignacionActiva.Id != asignacion.Id)
                throw new InvalidOperationException("El empleado ya tiene otra asignacion activa en este proyecto.");
        }

        await _repository.ActualizarAsync(asignacion);
    }

    public async Task FinalizarAsync(int id, DateTime? fechaFin = null)
    {
        var asignacion = await _repository.ObtenerPorIdAsync(id)
            ?? throw new KeyNotFoundException($"Asignacion {id} no encontrada.");

        if (!asignacion.Activa)
            throw new InvalidOperationException("La asignacion ya se encuentra finalizada.");

        var fechaFinalizacion = fechaFin ?? DateTime.UtcNow;
        ValidarFechas(asignacion.FechaInicio, fechaFinalizacion);

        asignacion.FechaFin = fechaFinalizacion;
        asignacion.Activa = false;

        await _repository.ActualizarAsync(asignacion);
    }

    public async Task ReactivarAsync(int id)
    {
        var asignacion = await _repository.ObtenerPorIdAsync(id)
            ?? throw new KeyNotFoundException($"Asignacion {id} no encontrada.");

        if (asignacion.Activa)
            return;

        await ValidarEmpleadoYProyectoAsync(asignacion.EmpleadoId, asignacion.ProyectoId);

        var asignacionActiva = await _repository.ObtenerActivaAsync(asignacion.EmpleadoId, asignacion.ProyectoId);
        if (asignacionActiva is not null && asignacionActiva.Id != asignacion.Id)
            throw new InvalidOperationException("No se puede reactivar porque ya existe una asignacion activa para el empleado y proyecto.");

        asignacion.FechaFin = null;
        asignacion.Activa = true;

        await _repository.ActualizarAsync(asignacion);
    }

    private async Task ValidarEmpleadoYProyectoAsync(int empleadoId, int proyectoId)
    {
        var existeEmpleado = await _context.Empleados
            .AnyAsync(e => e.Id == empleadoId && e.Activo);

        if (!existeEmpleado)
            throw new KeyNotFoundException(MensajesError.EmpleadoNoEncontrado);

        var existeProyecto = await _context.Proyectos
            .AnyAsync(p => p.Id == proyectoId);

        if (!existeProyecto)
            throw new KeyNotFoundException($"Proyecto {proyectoId} no encontrado.");
    }

    private static void ValidarFechas(DateTime fechaInicio, DateTime? fechaFin)
    {
        if (fechaInicio == default)
            throw new InvalidOperationException("La fecha de inicio es obligatoria.");

        if (fechaFin.HasValue && fechaFin.Value < fechaInicio)
            throw new InvalidOperationException("La fecha de finalizacion no puede ser anterior a la fecha de inicio.");
    }

    private static AsignacionProyectoListDto MapToDto(EmpleadoProyectoAsignacion a) => new()
    {
        Id = a.Id,
        EmpleadoId = a.EmpleadoId,
        EmpleadoNombre = $"{a.Empleado.Nombre} {a.Empleado.Apellido}".Trim(),
        ProyectoId = a.ProyectoId,
        ProyectoNombre = a.Proyecto.Nombre,
        FechaInicio = a.FechaInicio,
        FechaFin = a.FechaFin,
        Activa = a.Activa,
        RolEnProyecto = a.RolEnProyecto,
        Observaciones = a.Observaciones,
        AuditInfo = AuditInfoFactory.FromEntity(a)
    };

    private static string? ObtenerRolEmpleado(Empleado empleado)
    {
        return empleado.EspecialidadNavigation?.Nombre
            ?? empleado.RolUsuario?.Nombre;
    }

    private static string ClasificarCarga(int cantidadProyectos) => cantidadProyectos switch
    {
        0 => "Disponible",
        1 => "Baja",
        2 => "Media",
        _ => "Alta"
    };
}
