using AutoMapper;
using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Business.DTOs.Marketing;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Entities.Enums;
using DrakionTech.Crm.Data.Repositories;
using DrakionTech.Crm.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace DrakionTech.Crm.Business.Services;

public class PublicacionMarketingService : IPublicacionMarketingService
{
    private readonly IPublicacionMarketingRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICurrentUserContext? _currentUserContext;

    public PublicacionMarketingService(
        IPublicacionMarketingRepository repository,
        IMapper mapper,
        ICurrentUserContext? currentUserContext = null)
    {
        _repository = repository;
        _mapper = mapper;
        _currentUserContext = currentUserContext;
    }

    public async Task<List<PublicacionMarketingDto>> ObtenerTodosAsync()
    {
        var publicaciones = await _repository.ObtenerTodosAsync();

        return _mapper.Map<List<PublicacionMarketingDto>>(publicaciones);
    }

    public async Task<ResultadoPaginacion<PublicacionMarketingDto>> ObtenerTodosConPaginacionAsync(
        string? busqueda = null,
        int pagina = 1,
        int tamañoPagina = 10)
    {
        var query = _repository.Query();

        if (!string.IsNullOrWhiteSpace(busqueda))
        {
            var term = busqueda.Trim().ToLower();

            query = query.Where(x =>
                x.Nombre.ToLower().Contains(term) ||
                x.CopyUtilizado.ToLower().Contains(term) ||
                (x.Responsable.Nombre + " " + x.Responsable.Apellido)
                    .ToLower()
                    .Contains(term));
        }

        var paginado = await query
            .OrderByDescending(x => x.FechaPublicacionProgramada)
            .PaginarAsync(pagina, tamañoPagina);

        return new ResultadoPaginacion<PublicacionMarketingDto>
        {
            Items = _mapper.Map<List<PublicacionMarketingDto>>(paginado.Items),
            TotalRegistros = paginado.TotalRegistros,
            Pagina = paginado.Pagina,
            TamañoPagina = paginado.TamañoPagina
        };
    }

    public async Task<PublicacionMarketingDto?> ObtenerPorIdAsync(int id)
    {
        var publicacion = await _repository.ObtenerPorIdAsync(id);

        return publicacion is null
            ? null
            : _mapper.Map<PublicacionMarketingDto>(publicacion);
    }
    public async Task<int> CrearAsync(CrearPublicacionMarketingDto dto)
    {
        var publicacion = _mapper.Map<PublicacionMarketing>(dto);

        publicacion.RedesSociales = dto.RedesSociales
            .Select(x => new PublicacionRedSocial
            {
                RedSocial = x.RedSocial,
                TienePauta = x.TienePauta,
                CostoPauta = x.CostoPauta,
                DiasPauta = x.DiasPauta
            })
            .ToList();

        publicacion.Archivos = dto.Archivos
            .Select(x => new ArchivoPublicacionMarketing
            {
                Nombre = x.Nombre,
                MimeType = x.MimeType,
                ArchivoIdExterno = x.ArchivoIdExterno,
                Url = x.Url
            })
            .ToList();

        await _repository.AgregarAsync(publicacion);
        return publicacion.Id;
    }

    public async Task ActualizarAsync(ActualizarPublicacionMarketingDto dto)
    {
        var publicacion = await _repository.ObtenerPorIdAsync(dto.Id)
            ?? throw new InvalidOperationException("Publicación no encontrada.");

        if (publicacion.FechaPublicacionProgramada.Date != dto.FechaPublicacionProgramada.Date)
        {
            publicacion.Recordatorio3DiasEnviado = false;
            publicacion.RecordatorioDiaPublicacionEnviado = false;
            publicacion.AlertaRetrasoEnviada = false;
        }

        _mapper.Map(dto, publicacion);

        publicacion.RedesSociales.Clear();
        foreach (var red in dto.RedesSociales)
        {
            publicacion.RedesSociales.Add(new PublicacionRedSocial
            {
                RedSocial = red.RedSocial,
                TienePauta = red.TienePauta,
                CostoPauta = red.CostoPauta,
                DiasPauta = red.DiasPauta
            });
        }

        publicacion.Archivos.Clear();
        foreach (var archivo in dto.Archivos)
        {
            publicacion.Archivos.Add(new ArchivoPublicacionMarketing
            {
                Nombre = archivo.Nombre,
                MimeType = archivo.MimeType,
                ArchivoIdExterno = archivo.ArchivoIdExterno,
                Url = archivo.Url
            });
        }

        publicacion.FechaActualizacion = DateTime.UtcNow;
        await _repository.ActualizarAsync(publicacion);
    }

    public async Task EliminarAsync(int id)
    {
        var publicacion = await _repository.ObtenerPorIdAsync(id);

        if (publicacion is null)
            throw new KeyNotFoundException($"Publicación {id} no encontrada.");

        publicacion.Activo = false;
        publicacion.FechaActualizacion = DateTime.UtcNow;

        await _repository.ActualizarAsync(publicacion);
    }

    public async Task<List<MetricaPublicacionDto>> ObtenerMetricasAsync()
    {
        var publicaciones = await _repository.Query()
            .AsNoTracking()
            .ToListAsync();

        return publicaciones
            .SelectMany(publicacion => publicacion.Metricas.Select(metrica =>
                new MetricaPublicacionDto
                {
                    Id = metrica.Id,
                    PublicacionMarketingId = publicacion.Id,
                    PublicacionNombre = publicacion.Nombre,
                    RedSocial = metrica.RedSocial,
                    FechaRegistro = metrica.FechaRegistro,
                    Visualizaciones = metrica.Visualizaciones,
                    Reacciones = metrica.Reacciones,
                    Alcance = metrica.Alcance,
                    ContactoAreaComercial = metrica.ContactoAreaComercial,
                    Observaciones = metrica.Observaciones
                }))
            .OrderByDescending(x => x.FechaRegistro)
            .ToList();
    }

    public async Task CrearMetricaAsync(CrearMetricaPublicacionDto dto)
    {
        var publicacion = await _repository.ObtenerPorIdAsync(dto.PublicacionMarketingId);

        if (publicacion is null)
            throw new KeyNotFoundException($"Publicación {dto.PublicacionMarketingId} no encontrada.");

        publicacion.Metricas.Add(new MetricaPublicacion
        {
            RedSocial = dto.RedSocial,
            FechaRegistro = dto.FechaRegistro,
            Visualizaciones = dto.Visualizaciones,
            Reacciones = dto.Reacciones,
            Alcance = dto.Alcance,
            ContactoAreaComercial = dto.ContactoAreaComercial,
            Observaciones = dto.Observaciones
        });

        publicacion.FechaActualizacion = DateTime.UtcNow;

        await _repository.ActualizarAsync(publicacion);
    }

    public async Task<ResultadoPaginacion<MetricaPublicacionDto>> ObtenerMetricasConPaginacionAsync(
    string? busqueda = null,
    int pagina = 1,
    int tamañoPagina = 10)
    {
        var query = _repository.Query()
            .AsNoTracking()
            .SelectMany(publicacion => publicacion.Metricas.Select(metrica =>
                new MetricaPublicacionDto
                {
                    Id = metrica.Id,
                    PublicacionMarketingId = publicacion.Id,
                    PublicacionNombre = publicacion.Nombre,
                    RedSocial = metrica.RedSocial,
                    FechaRegistro = metrica.FechaRegistro,
                    Visualizaciones = metrica.Visualizaciones,
                    Reacciones = metrica.Reacciones,
                    Alcance = metrica.Alcance,
                    ContactoAreaComercial = metrica.ContactoAreaComercial,
                    Observaciones = metrica.Observaciones
                }));

        if (!string.IsNullOrWhiteSpace(busqueda))
        {
            var term = busqueda.Trim().ToLower();

            query = query.Where(x =>
                x.PublicacionNombre.ToLower().Contains(term) ||
                x.RedSocial.ToString().ToLower().Contains(term));
        }

        var paginado = await query
            .OrderByDescending(x => x.FechaRegistro)
            .PaginarAsync(pagina, tamañoPagina);

        return new ResultadoPaginacion<MetricaPublicacionDto>
        {
            Items = paginado.Items,
            TotalRegistros = paginado.TotalRegistros,
            Pagina = paginado.Pagina,
            TamañoPagina = paginado.TamañoPagina
        };
    }

    public async Task<MetricaPublicacionDto?> ObtenerMetricaPorIdAsync(int id)
    {
        var publicaciones = await _repository.Query()
            .AsNoTracking()
            .ToListAsync();

        return publicaciones
            .SelectMany(publicacion => publicacion.Metricas.Select(metrica =>
                new MetricaPublicacionDto
                {
                    Id = metrica.Id,
                    PublicacionMarketingId = publicacion.Id,
                    PublicacionNombre = publicacion.Nombre,
                    RedSocial = metrica.RedSocial,
                    FechaRegistro = metrica.FechaRegistro,
                    Visualizaciones = metrica.Visualizaciones,
                    Reacciones = metrica.Reacciones,
                    Alcance = metrica.Alcance,
                    ContactoAreaComercial = metrica.ContactoAreaComercial,
                    Observaciones = metrica.Observaciones
                }))
            .FirstOrDefault(x => x.Id == id);
    }

    public async Task ActualizarMetricaAsync(ActualizarMetricaPublicacionDto dto)
    {
        var publicaciones = await _repository.Query()
            .ToListAsync();

        var publicacionActual = publicaciones
            .FirstOrDefault(x => x.Metricas.Any(m => m.Id == dto.Id));

        if (publicacionActual is null)
            throw new KeyNotFoundException($"Métrica {dto.Id} no encontrada.");

        var metrica = publicacionActual.Metricas.First(x => x.Id == dto.Id);

        if (publicacionActual.Id != dto.PublicacionMarketingId)
        {
            publicacionActual.Metricas.Remove(metrica);

            var nuevaPublicacion = await _repository.ObtenerPorIdAsync(dto.PublicacionMarketingId);

            if (nuevaPublicacion is null)
                throw new KeyNotFoundException($"Publicación {dto.PublicacionMarketingId} no encontrada.");

            nuevaPublicacion.Metricas.Add(metrica);
            publicacionActual = nuevaPublicacion;
        }

        metrica.RedSocial = dto.RedSocial;
        metrica.FechaRegistro = dto.FechaRegistro;
        metrica.Visualizaciones = dto.Visualizaciones;
        metrica.Reacciones = dto.Reacciones;
        metrica.Alcance = dto.Alcance;
        metrica.ContactoAreaComercial = dto.ContactoAreaComercial;
        metrica.Observaciones = dto.Observaciones;

        publicacionActual.FechaActualizacion = DateTime.UtcNow;

        await _repository.ActualizarAsync(publicacionActual);
    }

    public async Task ActualizarEstadoAsync(int id, EstadoPublicacionMarketing nuevoEstado, string? observacion)
    {
        var pub = await _repository.ObtenerPorIdAsync(id)
            ?? throw new InvalidOperationException("Publicación no encontrada.");

        pub.Estado = nuevoEstado;

        if (!string.IsNullOrWhiteSpace(observacion))
            pub.Observaciones = string.IsNullOrWhiteSpace(pub.Observaciones)
                ? observacion
                : $"{pub.Observaciones}\n\n[{DateTime.Today:dd/MM/yyyy}] {observacion}";

        await _repository.ActualizarAsync(pub);
    }
}