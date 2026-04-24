using AutoMapper;
using DrakionTech.Crm.Business.DTOs.Ubicacion;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Repositories;

namespace DrakionTech.Crm.Business.Services
{
    public class CiudadService : ICiudadService
    {
        private readonly ICiudadRepository _ciudadRepository;
        private readonly IMapper _mapper;

        public CiudadService(
            ICiudadRepository ciudadRepository,
            IMapper mapper)
        {
            _ciudadRepository = ciudadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CiudadDto>> ObtenerPorPaisAsync(
            int paisId,
            CancellationToken ct = default)
        {
            var ciudades = await _ciudadRepository
                .ObtenerPorPaisAsync(paisId, ct);

            return _mapper.Map<IEnumerable<CiudadDto>>(ciudades)
                          .OrderBy(c => c.Nombre);
        }
    }
}