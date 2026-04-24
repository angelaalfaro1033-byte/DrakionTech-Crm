using AutoMapper;
using DrakionTech.Crm.Business.DTOs.Catalogo;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Repositories;

namespace DrakionTech.Crm.Business.Services
{
    public class CatalogoService : ICatalogoService
    {
        private readonly IPaisRepository _paisRepository;
        private readonly ICiudadRepository _ciudadRepository;
        private readonly ISectorRepository _sectorRepository;
        private readonly IEstadoRepository _estadoRepository;
        private readonly IMapper _mapper;

        public CatalogoService(
            IPaisRepository paisRepository,
            ICiudadRepository ciudadRepository,
            ISectorRepository sectorRepository,
            IEstadoRepository estadoRepository,
            IMapper mapper)
        {
            _paisRepository = paisRepository;
            _ciudadRepository = ciudadRepository;
            _sectorRepository = sectorRepository;
            _estadoRepository = estadoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CatalogoDto>> ObtenerPaisesAsync(CancellationToken ct = default)
        {
            var paises = await _paisRepository.GetAllAsync(ct);
            return _mapper.Map<IEnumerable<CatalogoDto>>(paises);
        }

        public async Task<IEnumerable<CatalogoDto>> ObtenerCiudadesPorPaisAsync(int paisId, CancellationToken ct = default)
        {
            var ciudades = await _ciudadRepository.ObtenerPorPaisAsync(paisId, ct);
            return _mapper.Map<IEnumerable<CatalogoDto>>(ciudades);
        }

        public async Task<IEnumerable<CatalogoDto>> ObtenerSectoresAsync(CancellationToken ct = default)
        {
            var sectores = await _sectorRepository.GetAllAsync(ct);
            return _mapper.Map<IEnumerable<CatalogoDto>>(sectores);
        }

        public async Task<IEnumerable<CatalogoDto>> ObtenerEstadosAsync(CancellationToken ct = default)
        {
            var estados = await _estadoRepository.GetAllAsync(ct);
            return _mapper.Map<IEnumerable<CatalogoDto>>(estados);
        }
    }
}