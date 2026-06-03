// ProyectoService.cs
using AutoMapper;
using DrakionTech.Crm.Business.DTOs.Proyecto;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data;
using DrakionTech.Crm.Data.Context;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Repositories;
using Microsoft.EntityFrameworkCore;

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

    public async Task<ProyectoDto?> ObtenerPorIdAsync(int id)
    {
        var proyecto = await _repository.ObtenerPorIdAsync(id);
        return proyecto is null ? null : _mapper.Map<ProyectoDto>(proyecto);
    }
    public async Task CrearAsync(CrearProyectoDto dto)
    {
        await ValidarResponsableEnAreaAsync(dto.AreaId, dto.ResponsableId);
        var proyecto = _mapper.Map<Proyecto>(dto);
        await _repository.AgregarAsync(proyecto);
    }

    public async Task ActualizarAsync(ActualizarProyectoDto dto)
    {
        var proyecto = await _repository.ObtenerPorIdAsync(dto.Id)
            ?? throw new KeyNotFoundException($"Proyecto {dto.Id} no encontrado.");

        await ValidarResponsableEnAreaAsync(dto.AreaId, dto.ResponsableId);

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
}