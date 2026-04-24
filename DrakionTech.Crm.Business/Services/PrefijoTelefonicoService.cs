using AutoMapper;
using DrakionTech.Crm.Business.DTOs.PrefijoTelefonico;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Repositories;

namespace DrakionTech.Crm.Business.Services
{
    public class PrefijoTelefonicoService : IPrefijoTelefonicoService
    {
        private readonly IPrefijoTelefonicoRepository _repository;
        private readonly IMapper _mapper;

        public PrefijoTelefonicoService(
            IPrefijoTelefonicoRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PrefijoTelefonicoDto>> ObtenerTodosAsync(CancellationToken ct = default)
        {
            var prefijos = await _repository.GetAllAsync(ct);
            return _mapper.Map<IEnumerable<PrefijoTelefonicoDto>>(prefijos);
        }

        public async Task<IEnumerable<PrefijoTelefonicoDto>> ObtenerPorPaisAsync(int paisId, CancellationToken ct = default)
        {
            var prefijos = await _repository.GetByPaisIdAsync(paisId, ct);
            return _mapper.Map<IEnumerable<PrefijoTelefonicoDto>>(prefijos);
        }

        public async Task<PrefijoTelefonicoDto?> ObtenerPorPaisUnicoAsync(int paisId, CancellationToken ct = default)
        {
            var prefijo = await _repository.GetByPaisAsync(paisId, ct);
            return _mapper.Map<PrefijoTelefonicoDto?>(prefijo);
        }

        public async Task<string?> ObtenerCodigoPorPaisAsync(int paisId, CancellationToken ct = default)
        {
            var prefijo = await _repository.GetByPaisAsync(paisId, ct);

            if (prefijo == null)
                return null;

            return prefijo.Codigo;
        }
    }
}