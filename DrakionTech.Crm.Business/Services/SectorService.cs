using AutoMapper;
using DrakionTech.Crm.Business.DTOs.Catalogo;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Repositories;

namespace DrakionTech.Crm.Business.Services
{
    public class SectorService : ISectorService
    {
        private readonly ISectorRepository _sectorRepository;
        private readonly IMapper _mapper;

        public SectorService(
            ISectorRepository sectorRepository,
            IMapper mapper)
        {
            _sectorRepository = sectorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CatalogoDto>> ObtenerTodosAsync(CancellationToken ct = default)
        {
            var sectores = await _sectorRepository.GetAllAsync(ct);
            return _mapper.Map<IEnumerable<CatalogoDto>>(sectores);
        }
    }
}