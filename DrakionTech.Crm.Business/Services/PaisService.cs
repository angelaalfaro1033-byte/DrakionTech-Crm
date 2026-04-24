using AutoMapper;
using DrakionTech.Crm.Business.DTOs.Ubicacion;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Repositories;

namespace DrakionTech.Crm.Business.Services
{
    public class PaisService : IPaisService
    {
        private readonly IPaisRepository _paisRepository;
        private readonly IMapper _mapper;

        public PaisService(
            IPaisRepository paisRepository,
            IMapper mapper)
        {
            _paisRepository = paisRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaisDto>> ObtenerTodosAsync(
            CancellationToken ct = default)
        {
            var paises = await _paisRepository.ObtenerTodosAsync(ct);

            return _mapper.Map<IEnumerable<PaisDto>>(paises)
                          .OrderBy(p => p.Nombre);
        }
    }
}