using AutoMapper;
using DrakionTech.Crm.Business.DTOs.Propuesta;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Repositories;

namespace DrakionTech.Crm.Business.Services
{
    public class PropuestaService : IPropuestaService
    {
        private readonly IPropuestaRepository _propuestaRepository;
        private readonly IMapper _mapper;

        public PropuestaService(
            IPropuestaRepository propuestaRepository,
            IMapper mapper)
        {
            _propuestaRepository = propuestaRepository;
            _mapper = mapper;
        }

        public async Task<int> CrearAsync(
            CrearPropuestaDto dto,
            CancellationToken ct = default)
        {
            var propuesta = _mapper.Map<Propuesta>(dto);

            await _propuestaRepository.AddAsync(propuesta, ct);

            return propuesta.Id;
        }

        public async Task<IEnumerable<PropuestaDto>> ObtenerPorOportunidadAsync(
            int oportunidadId,
            CancellationToken ct = default)
        {
            var propuestas = await _propuestaRepository.GetByOportunidadIdAsync(oportunidadId, ct);
            return _mapper.Map<IEnumerable<PropuestaDto>>(propuestas);
        }
    }
}