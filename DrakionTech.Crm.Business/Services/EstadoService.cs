using AutoMapper;
using DrakionTech.Crm.Business.DTOs.Catalogo;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Repositories;

namespace DrakionTech.Crm.Business.Services
{
    public class EstadoService : IEstadoService
    {
        private readonly IEstadoRepository _estadoRepository;
        private readonly IMapper _mapper;

        public EstadoService(
            IEstadoRepository estadoRepository,
            IMapper mapper)
        {
            _estadoRepository = estadoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CatalogoDto>> ObtenerTodosAsync(CancellationToken ct = default)
        {
            var estados = await _estadoRepository.GetAllAsync(ct);
            return _mapper.Map<IEnumerable<CatalogoDto>>(estados);
        }
    }
}