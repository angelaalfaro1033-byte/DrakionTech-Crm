using AutoMapper;
using DrakionTech.Crm.Business.DTOs.Proyecto;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Repositories;

namespace DrakionTech.Crm.Business.Services;

public class ProyectoService : IProyectoService
{
    private readonly IProyectoRepository _repository;
    private readonly IMapper _mapper;

    public ProyectoService(IProyectoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
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
        var proyecto = _mapper.Map<Proyecto>(dto);
        await _repository.AgregarAsync(proyecto);
    }

    public async Task ActualizarAsync(ActualizarProyectoDto dto)
    {
        var proyecto = await _repository.ObtenerPorIdAsync(dto.Id)
            ?? throw new KeyNotFoundException($"Proyecto {dto.Id} no encontrado.");

        _mapper.Map(dto, proyecto);
        await _repository.ActualizarAsync(proyecto);
    }

    public async Task EliminarAsync(int id)
    {
        var proyecto = await _repository.ObtenerPorIdAsync(id)
            ?? throw new KeyNotFoundException($"Proyecto {id} no encontrado.");

        await _repository.EliminarAsync(proyecto);
    }
}