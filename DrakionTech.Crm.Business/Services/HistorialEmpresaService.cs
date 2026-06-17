using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Business.DTOs;
using DrakionTech.Crm.Business.DTOs.Empresa;
using DrakionTech.Crm.Business.Exceptions;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Business.Services;

public class HistorialEmpresaService : IHistorialEmpresaService
{
    private readonly ApplicationDbContext _db;

    public HistorialEmpresaService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<ResultadoPaginacion<HistorialEmpresaDto>> ObtenerPorEmpresaAsync(
        FiltroHistorialEmpresaDto filtro,
        CancellationToken ct = default)
    {
        if (filtro.EmpresaId <= 0)
            throw new ReglaNegocioException("La empresa es obligatoria para consultar el historial.");

        var query = _db.HistorialesEmpresa
            .AsNoTracking()
            .Where(h => h.EmpresaId == filtro.EmpresaId);

        if (filtro.FechaDesde.HasValue)
            query = query.Where(h => h.FechaEvento >= filtro.FechaDesde.Value);

        if (filtro.FechaHasta.HasValue)
            query = query.Where(h => h.FechaEvento <= filtro.FechaHasta.Value);

        if (filtro.TipoEvento.HasValue)
            query = query.Where(h => h.TipoEvento == filtro.TipoEvento.Value);

        if (filtro.ModuloOrigen.HasValue)
            query = query.Where(h => h.ModuloOrigen == filtro.ModuloOrigen.Value);

        if (!string.IsNullOrWhiteSpace(filtro.Busqueda))
        {
            var termino = filtro.Busqueda.Trim().ToLower();
            query = query.Where(h =>
                h.TituloEvento.ToLower().Contains(termino) ||
                (h.DescripcionEvento != null && h.DescripcionEvento.ToLower().Contains(termino)) ||
                (h.UsuarioResponsableNombre != null && h.UsuarioResponsableNombre.ToLower().Contains(termino)) ||
                (h.DatosAdicionales != null && h.DatosAdicionales.ToLower().Contains(termino)));
        }

        return await query
            .OrderByDescending(h => h.FechaEvento)
            .ThenByDescending(h => h.Id)
            .Select(h => new HistorialEmpresaDto
            {
                Id = h.Id,
                EmpresaId = h.EmpresaId,
                TipoEvento = h.TipoEvento,
                TituloEvento = h.TituloEvento,
                DescripcionEvento = h.DescripcionEvento,
                FechaEvento = h.FechaEvento,
                UsuarioResponsableId = h.UsuarioResponsableId,
                UsuarioResponsableNombre =
                    h.UsuarioResponsableNombre ??
                    (h.UsuarioResponsable != null
                        ? (h.UsuarioResponsable.Nombre + " " + h.UsuarioResponsable.Apellido).Trim()
                        : "Sin usuario registrado"),
                ModuloOrigen = h.ModuloOrigen,
                RegistroOrigenId = h.RegistroOrigenId,
                DatosAdicionales = h.DatosAdicionales
            })
            .PaginarAsync(filtro.Pagina, filtro.TamañoPagina, ct);
    }

    public async Task<HistorialEmpresaDto?> ObtenerPorIdAsync(
        int historialEmpresaId,
        CancellationToken ct = default)
    {
        return await _db.HistorialesEmpresa
            .AsNoTracking()
            .Where(h => h.Id == historialEmpresaId)
            .Select(h => new HistorialEmpresaDto
            {
                Id = h.Id,
                EmpresaId = h.EmpresaId,
                TipoEvento = h.TipoEvento,
                TituloEvento = h.TituloEvento,
                DescripcionEvento = h.DescripcionEvento,
                FechaEvento = h.FechaEvento,
                UsuarioResponsableId = h.UsuarioResponsableId,
                UsuarioResponsableNombre =
                    h.UsuarioResponsableNombre ??
                    (h.UsuarioResponsable != null
                        ? (h.UsuarioResponsable.Nombre + " " + h.UsuarioResponsable.Apellido).Trim()
                        : "Sin usuario registrado"),
                ModuloOrigen = h.ModuloOrigen,
                RegistroOrigenId = h.RegistroOrigenId,
                DatosAdicionales = h.DatosAdicionales
            })
            .FirstOrDefaultAsync(ct);
    }

    public async Task<int> RegistrarAsync(RegistrarHistorialEmpresaDto dto, CancellationToken ct = default)
    {
        if (dto.EmpresaId <= 0)
            throw new ReglaNegocioException("La empresa es obligatoria para registrar historial.");

        if (string.IsNullOrWhiteSpace(dto.TituloEvento))
            throw new ReglaNegocioException("El titulo del evento es obligatorio.");

        var existeEmpresa = await _db.Empresas
            .AsNoTracking()
            .AnyAsync(e => e.Id == dto.EmpresaId, ct);

        if (!existeEmpresa)
            throw new EntidadNoEncontradaException("Empresa", dto.EmpresaId);

        var claveEvento = ConstruirClaveEvento(dto);

        var existente = await _db.HistorialesEmpresa
            .AsNoTracking()
            .Where(h => h.ClaveEvento == claveEvento)
            .Select(h => h.Id)
            .FirstOrDefaultAsync(ct);

        if (existente > 0)
            return existente;

        var historial = new HistorialEmpresa
        {
            EmpresaId = dto.EmpresaId,
            TipoEvento = dto.TipoEvento,
            TituloEvento = dto.TituloEvento.Trim(),
            DescripcionEvento = string.IsNullOrWhiteSpace(dto.DescripcionEvento)
                ? null
                : dto.DescripcionEvento.Trim(),
            FechaEvento = dto.FechaEvento ?? DateTime.UtcNow,
            UsuarioResponsableId = dto.UsuarioResponsableId,
            UsuarioResponsableNombre = string.IsNullOrWhiteSpace(dto.UsuarioResponsableNombre)
                ? null
                : dto.UsuarioResponsableNombre.Trim(),
            ModuloOrigen = dto.ModuloOrigen,
            RegistroOrigenId = dto.RegistroOrigenId,
            DatosAdicionales = string.IsNullOrWhiteSpace(dto.DatosAdicionales)
                ? null
                : dto.DatosAdicionales.Trim(),
            ClaveEvento = claveEvento
        };

        _db.HistorialesEmpresa.Add(historial);
        await _db.SaveChangesAsync(ct);

        return historial.Id;
    }

    public async Task<int> SincronizarEmpresaAsync(int empresaId, CancellationToken ct = default)
    {
        if (empresaId <= 0)
            throw new ReglaNegocioException("La empresa es obligatoria para sincronizar el historial.");

        var existeEmpresa = await _db.Empresas
            .AsNoTracking()
            .AnyAsync(e => e.Id == empresaId, ct);

        if (!existeEmpresa)
            throw new EntidadNoEncontradaException("Empresa", empresaId);

        var eventos = new List<RegistrarHistorialEmpresaDto>();

        await AgregarEventosEmpresaAsync(empresaId, eventos, ct);
        await AgregarEventosContactosAsync(empresaId, eventos, ct);
        await AgregarEventosOportunidadesAsync(empresaId, eventos, ct);
        await AgregarEventosPropuestasAsync(empresaId, eventos, ct);
        await AgregarEventosProyectosAsync(empresaId, eventos, ct);
        await AgregarEventosPagosAsync(empresaId, eventos, ct);
        await AgregarEventosActividadesAsync(empresaId, eventos, ct);
        await AgregarEventosObservacionesAsync(empresaId, eventos, ct);

        return await RegistrarEventosNuevosAsync(eventos, ct);
    }

    public async Task<bool> ExisteEventoAsync(string claveEvento, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(claveEvento))
            return false;

        var claveNormalizada = claveEvento.Trim().ToLowerInvariant();

        return await _db.HistorialesEmpresa
            .AsNoTracking()
            .AnyAsync(h => h.ClaveEvento == claveNormalizada, ct);
    }

    public IEnumerable<OpcionEnumDto> ObtenerTiposEvento()
    {
        return Enum.GetValues<TipoEventoHistorialEmpresa>()
            .Select(tipo => new OpcionEnumDto
            {
                Valor = (int)tipo,
                Nombre = tipo.ToString()
            });
    }

    public IEnumerable<OpcionEnumDto> ObtenerModulosOrigen()
    {
        return Enum.GetValues<ModuloOrigenHistorialEmpresa>()
            .Select(modulo => new OpcionEnumDto
            {
                Valor = (int)modulo,
                Nombre = modulo.ToString()
            });
    }

    private static string ConstruirClaveEvento(RegistrarHistorialEmpresaDto dto)
    {
        if (!string.IsNullOrWhiteSpace(dto.ClaveEvento))
            return dto.ClaveEvento.Trim().ToLowerInvariant();

        if (dto.RegistroOrigenId.HasValue)
        {
            return string.Join(
                ":",
                dto.EmpresaId,
                dto.ModuloOrigen,
                dto.RegistroOrigenId.Value,
                dto.TipoEvento).ToLowerInvariant();
        }

        return string.Join(
            ":",
            dto.EmpresaId,
            dto.ModuloOrigen,
            dto.TipoEvento,
            dto.TituloEvento.Trim(),
            (dto.FechaEvento ?? DateTime.UtcNow).Ticks).ToLowerInvariant();
    }

    private async Task<int> RegistrarEventosNuevosAsync(
        IEnumerable<RegistrarHistorialEmpresaDto> eventos,
        CancellationToken ct)
    {
        var eventosNormalizados = eventos
            .Where(e => !string.IsNullOrWhiteSpace(e.TituloEvento))
            .Select(e => new
            {
                Dto = e,
                Clave = ConstruirClaveEvento(e)
            })
            .GroupBy(e => e.Clave)
            .Select(g => g.First())
            .ToList();

        if (!eventosNormalizados.Any())
            return 0;

        var claves = eventosNormalizados.Select(e => e.Clave).ToList();

        var clavesExistentes = await _db.HistorialesEmpresa
            .AsNoTracking()
            .Where(h => claves.Contains(h.ClaveEvento))
            .Select(h => h.ClaveEvento)
            .ToListAsync(ct);

        var existentes = clavesExistentes.ToHashSet(StringComparer.OrdinalIgnoreCase);

        var nuevos = eventosNormalizados
            .Where(e => !existentes.Contains(e.Clave))
            .Select(e => new HistorialEmpresa
            {
                EmpresaId = e.Dto.EmpresaId,
                TipoEvento = e.Dto.TipoEvento,
                TituloEvento = e.Dto.TituloEvento.Trim(),
                DescripcionEvento = string.IsNullOrWhiteSpace(e.Dto.DescripcionEvento)
                    ? null
                    : e.Dto.DescripcionEvento.Trim(),
                FechaEvento = e.Dto.FechaEvento ?? DateTime.UtcNow,
                UsuarioResponsableId = e.Dto.UsuarioResponsableId,
                UsuarioResponsableNombre = string.IsNullOrWhiteSpace(e.Dto.UsuarioResponsableNombre)
                    ? null
                    : e.Dto.UsuarioResponsableNombre.Trim(),
                ModuloOrigen = e.Dto.ModuloOrigen,
                RegistroOrigenId = e.Dto.RegistroOrigenId,
                DatosAdicionales = string.IsNullOrWhiteSpace(e.Dto.DatosAdicionales)
                    ? null
                    : e.Dto.DatosAdicionales.Trim(),
                ClaveEvento = e.Clave
            })
            .ToList();

        if (!nuevos.Any())
            return 0;

        _db.HistorialesEmpresa.AddRange(nuevos);
        await _db.SaveChangesAsync(ct);

        return nuevos.Count;
    }

    private async Task AgregarEventosEmpresaAsync(
        int empresaId,
        ICollection<RegistrarHistorialEmpresaDto> eventos,
        CancellationToken ct)
    {
        var empresa = await _db.Empresas
            .AsNoTracking()
            .Include(e => e.CreatedByUser)
            .Include(e => e.ModifiedByUser)
            .FirstOrDefaultAsync(e => e.Id == empresaId, ct);

        if (empresa is null)
            return;

        eventos.Add(new RegistrarHistorialEmpresaDto
        {
            EmpresaId = empresa.Id,
            TipoEvento = TipoEventoHistorialEmpresa.Creacion,
            TituloEvento = "Empresa registrada",
            DescripcionEvento = $"Se registro la empresa {empresa.Nombre}.",
            FechaEvento = empresa.CreatedAt ?? empresa.FechaCreacion,
            UsuarioResponsableId = empresa.CreatedByUserId,
            UsuarioResponsableNombre = ObtenerNombreUsuario(empresa.CreatedByUser),
            ModuloOrigen = ModuloOrigenHistorialEmpresa.Empresas,
            RegistroOrigenId = empresa.Id,
            ClaveEvento = $"empresa:{empresa.Id}:creacion"
        });

        if (empresa.ModifiedAt.HasValue)
        {
            eventos.Add(new RegistrarHistorialEmpresaDto
            {
                EmpresaId = empresa.Id,
                TipoEvento = TipoEventoHistorialEmpresa.Actualizacion,
                TituloEvento = "Empresa actualizada",
                DescripcionEvento = $"Se actualizo la informacion de la empresa {empresa.Nombre}.",
                FechaEvento = empresa.ModifiedAt,
                UsuarioResponsableId = empresa.ModifiedByUserId,
                UsuarioResponsableNombre = ObtenerNombreUsuario(empresa.ModifiedByUser),
                ModuloOrigen = ModuloOrigenHistorialEmpresa.Empresas,
                RegistroOrigenId = empresa.Id,
                ClaveEvento = $"empresa:{empresa.Id}:actualizacion:{empresa.ModifiedAt.Value.Ticks}"
            });
        }
    }

    private async Task AgregarEventosContactosAsync(
        int empresaId,
        ICollection<RegistrarHistorialEmpresaDto> eventos,
        CancellationToken ct)
    {
        var contactos = await _db.Contactos
            .AsNoTracking()
            .Include(c => c.CreatedByUser)
            .Include(c => c.ModifiedByUser)
            .Where(c => c.EmpresaId == empresaId)
            .ToListAsync(ct);

        foreach (var contacto in contactos)
        {
            eventos.Add(new RegistrarHistorialEmpresaDto
            {
                EmpresaId = empresaId,
                TipoEvento = TipoEventoHistorialEmpresa.ContactoCreado,
                TituloEvento = "Contacto registrado",
                DescripcionEvento = $"Se registro el contacto {contacto.Nombre} {contacto.Apellido}.",
                FechaEvento = contacto.CreatedAt ?? contacto.FechaCreacion,
                UsuarioResponsableId = contacto.CreatedByUserId,
                UsuarioResponsableNombre = ObtenerNombreUsuario(contacto.CreatedByUser),
                ModuloOrigen = ModuloOrigenHistorialEmpresa.Contactos,
                RegistroOrigenId = contacto.Id,
                ClaveEvento = $"contacto:{contacto.Id}:creacion"
            });

            if (contacto.ModifiedAt.HasValue)
            {
                eventos.Add(new RegistrarHistorialEmpresaDto
                {
                    EmpresaId = empresaId,
                    TipoEvento = TipoEventoHistorialEmpresa.ContactoActualizado,
                    TituloEvento = "Contacto actualizado",
                    DescripcionEvento = $"Se actualizo el contacto {contacto.Nombre} {contacto.Apellido}.",
                    FechaEvento = contacto.ModifiedAt,
                    UsuarioResponsableId = contacto.ModifiedByUserId,
                    UsuarioResponsableNombre = ObtenerNombreUsuario(contacto.ModifiedByUser),
                    ModuloOrigen = ModuloOrigenHistorialEmpresa.Contactos,
                    RegistroOrigenId = contacto.Id,
                    ClaveEvento = $"contacto:{contacto.Id}:actualizacion:{contacto.ModifiedAt.Value.Ticks}"
                });
            }
        }
    }

    private async Task AgregarEventosOportunidadesAsync(
        int empresaId,
        ICollection<RegistrarHistorialEmpresaDto> eventos,
        CancellationToken ct)
    {
        var oportunidades = await _db.Oportunidades
            .AsNoTracking()
            .Include(o => o.CreatedByUser)
            .Include(o => o.ModifiedByUser)
            .Where(o => o.EmpresaId == empresaId)
            .ToListAsync(ct);

        foreach (var oportunidad in oportunidades)
        {
            eventos.Add(new RegistrarHistorialEmpresaDto
            {
                EmpresaId = empresaId,
                TipoEvento = TipoEventoHistorialEmpresa.OportunidadCreada,
                TituloEvento = "Oportunidad creada",
                DescripcionEvento = $"Se creo la oportunidad {oportunidad.NombreProyecto}.",
                FechaEvento = oportunidad.CreatedAt ?? oportunidad.FechaCreacion,
                UsuarioResponsableId = oportunidad.CreatedByUserId,
                UsuarioResponsableNombre = ObtenerNombreUsuario(oportunidad.CreatedByUser),
                ModuloOrigen = ModuloOrigenHistorialEmpresa.Oportunidades,
                RegistroOrigenId = oportunidad.Id,
                DatosAdicionales = $"Valor estimado: {oportunidad.ValorEstimado}",
                ClaveEvento = $"oportunidad:{oportunidad.Id}:creacion"
            });
        }

        var cambios = await _db.HistorialCambiosOportunidad
            .AsNoTracking()
            .Include(h => h.Oportunidad)
            .Where(h => h.Oportunidad.EmpresaId == empresaId)
            .ToListAsync(ct);

        foreach (var cambio in cambios)
        {
            eventos.Add(new RegistrarHistorialEmpresaDto
            {
                EmpresaId = empresaId,
                TipoEvento = TipoEventoHistorialEmpresa.CambioEtapaOportunidad,
                TituloEvento = "Cambio de etapa de oportunidad",
                DescripcionEvento = $"La oportunidad paso de {cambio.EtapaAnterior} a {cambio.EtapaNueva}.",
                FechaEvento = cambio.FechaCambio,
                UsuarioResponsableId = cambio.UsuarioId,
                ModuloOrigen = ModuloOrigenHistorialEmpresa.Oportunidades,
                RegistroOrigenId = cambio.Id,
                ClaveEvento = $"historial-cambio-oportunidad:{cambio.Id}"
            });
        }
    }

    private async Task AgregarEventosPropuestasAsync(
        int empresaId,
        ICollection<RegistrarHistorialEmpresaDto> eventos,
        CancellationToken ct)
    {
        var propuestas = await _db.Propuestas
            .AsNoTracking()
            .Include(p => p.Oportunidad)
            .Include(p => p.CreatedByUser)
            .Where(p => p.Oportunidad.EmpresaId == empresaId)
            .ToListAsync(ct);

        foreach (var propuesta in propuestas)
        {
            eventos.Add(new RegistrarHistorialEmpresaDto
            {
                EmpresaId = empresaId,
                TipoEvento = TipoEventoHistorialEmpresa.PropuestaCreada,
                TituloEvento = "Propuesta cargada",
                DescripcionEvento = $"Se cargo la propuesta {propuesta.NombreArchivo}.",
                FechaEvento = propuesta.CreatedAt ?? propuesta.FechaCarga,
                UsuarioResponsableId = propuesta.CreatedByUserId,
                UsuarioResponsableNombre = ObtenerNombreUsuario(propuesta.CreatedByUser),
                ModuloOrigen = ModuloOrigenHistorialEmpresa.Propuestas,
                RegistroOrigenId = propuesta.Id,
                DatosAdicionales = $"Tipo contenido: {propuesta.TipoContenido}; Tamano: {propuesta.TamanoArchivo}",
                ClaveEvento = $"propuesta:{propuesta.Id}:creacion"
            });
        }
    }

    private async Task AgregarEventosProyectosAsync(
        int empresaId,
        ICollection<RegistrarHistorialEmpresaDto> eventos,
        CancellationToken ct)
    {
        var proyectos = await _db.Proyectos
            .AsNoTracking()
            .Include(p => p.Oportunidad)
            .Include(p => p.CreatedByUser)
            .Include(p => p.ModifiedByUser)
            .Where(p => p.Oportunidad != null && p.Oportunidad.EmpresaId == empresaId)
            .ToListAsync(ct);

        foreach (var proyecto in proyectos)
        {
            eventos.Add(new RegistrarHistorialEmpresaDto
            {
                EmpresaId = empresaId,
                TipoEvento = TipoEventoHistorialEmpresa.ProyectoCreado,
                TituloEvento = "Proyecto creado",
                DescripcionEvento = $"Se creo el proyecto {proyecto.Nombre}.",
                FechaEvento = proyecto.CreatedAt ?? proyecto.FechaCreacion,
                UsuarioResponsableId = proyecto.CreatedByUserId,
                UsuarioResponsableNombre = ObtenerNombreUsuario(proyecto.CreatedByUser),
                ModuloOrigen = ModuloOrigenHistorialEmpresa.Proyectos,
                RegistroOrigenId = proyecto.Id,
                ClaveEvento = $"proyecto:{proyecto.Id}:creacion"
            });
        }

        var cambiosEtapa = await _db.HistorialesEtapaProyecto
            .AsNoTracking()
            .Include(h => h.Proyecto)
            .ThenInclude(p => p.Oportunidad)
            .Where(h => h.Proyecto.Oportunidad != null && h.Proyecto.Oportunidad.EmpresaId == empresaId)
            .ToListAsync(ct);

        foreach (var cambio in cambiosEtapa)
        {
            eventos.Add(new RegistrarHistorialEmpresaDto
            {
                EmpresaId = empresaId,
                TipoEvento = TipoEventoHistorialEmpresa.CambioEtapaProyecto,
                TituloEvento = "Cambio de etapa de proyecto",
                DescripcionEvento = $"El proyecto paso de {cambio.EtapaAnterior} a {cambio.EtapaNueva}.",
                FechaEvento = cambio.FechaCambio,
                ModuloOrigen = ModuloOrigenHistorialEmpresa.Proyectos,
                RegistroOrigenId = cambio.Id,
                DatosAdicionales = cambio.Observaciones,
                ClaveEvento = $"historial-etapa-proyecto:{cambio.Id}"
            });
        }
    }

    private async Task AgregarEventosPagosAsync(
        int empresaId,
        ICollection<RegistrarHistorialEmpresaDto> eventos,
        CancellationToken ct)
    {
        var pagos = await _db.PagosProyecto
            .AsNoTracking()
            .Include(p => p.Proyecto)
            .ThenInclude(p => p.Oportunidad)
            .Include(p => p.CreatedByUser)
            .Include(p => p.ModifiedByUser)
            .Where(p => p.Proyecto.Oportunidad != null && p.Proyecto.Oportunidad.EmpresaId == empresaId)
            .ToListAsync(ct);

        foreach (var pago in pagos)
        {
            eventos.Add(new RegistrarHistorialEmpresaDto
            {
                EmpresaId = empresaId,
                TipoEvento = pago.FechaPago.HasValue
                    ? TipoEventoHistorialEmpresa.PagoRegistrado
                    : TipoEventoHistorialEmpresa.PagoProgramado,
                TituloEvento = pago.FechaPago.HasValue ? "Pago registrado" : "Pago programado",
                DescripcionEvento = $"Pago de proyecto por valor {pago.Valor}.",
                FechaEvento = pago.FechaPago ?? pago.CreatedAt ?? pago.FechaProgramada,
                UsuarioResponsableId = pago.FechaPago.HasValue ? pago.ModifiedByUserId : pago.CreatedByUserId,
                UsuarioResponsableNombre = pago.FechaPago.HasValue
                    ? ObtenerNombreUsuario(pago.ModifiedByUser)
                    : ObtenerNombreUsuario(pago.CreatedByUser),
                ModuloOrigen = ModuloOrigenHistorialEmpresa.Pagos,
                RegistroOrigenId = pago.Id,
                DatosAdicionales = $"Estado: {pago.Estado}; Fecha programada: {pago.FechaProgramada:yyyy-MM-dd}",
                ClaveEvento = pago.FechaPago.HasValue
                    ? $"pago:{pago.Id}:registrado:{pago.FechaPago.Value.Ticks}"
                    : $"pago:{pago.Id}:programado"
            });
        }
    }

    private async Task AgregarEventosActividadesAsync(
        int empresaId,
        ICollection<RegistrarHistorialEmpresaDto> eventos,
        CancellationToken ct)
    {
        var actividades = await _db.Actividades
            .AsNoTracking()
            .Include(a => a.TipoActividad)
            .Include(a => a.EstadoActividad)
            .Include(a => a.Usuario)
            .Include(a => a.CreatedByUser)
            .Where(a => a.EmpresaId == empresaId || (a.Oportunidad != null && a.Oportunidad.EmpresaId == empresaId))
            .ToListAsync(ct);

        foreach (var actividad in actividades)
        {
            eventos.Add(new RegistrarHistorialEmpresaDto
            {
                EmpresaId = empresaId,
                TipoEvento = actividad.Fin.HasValue
                    ? TipoEventoHistorialEmpresa.ActividadCompletada
                    : TipoEventoHistorialEmpresa.ActividadCreada,
                TituloEvento = actividad.Fin.HasValue ? "Actividad completada" : "Actividad creada",
                DescripcionEvento = actividad.Resultado ?? actividad.Notas ?? actividad.TipoActividad.Nombre,
                FechaEvento = actividad.Fin ?? actividad.CreatedAt ?? actividad.Inicio,
                UsuarioResponsableId = actividad.UsuarioId,
                UsuarioResponsableNombre = ObtenerNombreUsuario(actividad.Usuario),
                ModuloOrigen = ModuloOrigenHistorialEmpresa.Actividades,
                RegistroOrigenId = actividad.Id,
                DatosAdicionales = $"Tipo: {actividad.TipoActividad.Nombre}; Estado: {actividad.EstadoActividad.Nombre}",
                ClaveEvento = actividad.Fin.HasValue
                    ? $"actividad:{actividad.Id}:completada:{actividad.Fin.Value.Ticks}"
                    : $"actividad:{actividad.Id}:creacion"
            });
        }
    }

    private async Task AgregarEventosObservacionesAsync(
        int empresaId,
        ICollection<RegistrarHistorialEmpresaDto> eventos,
        CancellationToken ct)
    {
        var empresa = await _db.Empresas
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == empresaId, ct);

        if (!string.IsNullOrWhiteSpace(empresa?.Seguimiento))
        {
            eventos.Add(new RegistrarHistorialEmpresaDto
            {
                EmpresaId = empresaId,
                TipoEvento = TipoEventoHistorialEmpresa.ObservacionRegistrada,
                TituloEvento = "Observacion de empresa",
                DescripcionEvento = empresa.Seguimiento,
                FechaEvento = empresa.ModifiedAt ?? empresa.CreatedAt ?? empresa.FechaCreacion,
                ModuloOrigen = ModuloOrigenHistorialEmpresa.Observaciones,
                RegistroOrigenId = empresa.Id,
                ClaveEvento = $"empresa:{empresa.Id}:observacion"
            });
        }

        var proyectos = await _db.Proyectos
            .AsNoTracking()
            .Include(p => p.Oportunidad)
            .Where(p => p.Oportunidad != null &&
                        p.Oportunidad.EmpresaId == empresaId &&
                        p.Observaciones != null &&
                        p.Observaciones != string.Empty)
            .ToListAsync(ct);

        foreach (var proyecto in proyectos)
        {
            eventos.Add(new RegistrarHistorialEmpresaDto
            {
                EmpresaId = empresaId,
                TipoEvento = TipoEventoHistorialEmpresa.ObservacionRegistrada,
                TituloEvento = "Observacion de proyecto",
                DescripcionEvento = proyecto.Observaciones,
                FechaEvento = proyecto.ModifiedAt ?? proyecto.CreatedAt ?? proyecto.FechaCreacion,
                ModuloOrigen = ModuloOrigenHistorialEmpresa.Observaciones,
                RegistroOrigenId = proyecto.Id,
                ClaveEvento = $"proyecto:{proyecto.Id}:observacion"
            });
        }
    }

    private static string? ObtenerNombreUsuario(Usuario? usuario)
    {
        return usuario is null
            ? null
            : $"{usuario.Nombre} {usuario.Apellido}".Trim();
    }
}
