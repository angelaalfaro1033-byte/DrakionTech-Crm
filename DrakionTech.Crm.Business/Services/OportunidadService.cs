using AutoMapper;
using DrakionTech.Crm.Business.DTOs;
using DrakionTech.Crm.Business.DTOs.Oportunidad;
using DrakionTech.Crm.Business.Exceptions;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Entities.Enums;
using DrakionTech.Crm.Data.Repositories;

namespace DrakionTech.Crm.Business.Services
{
    public class OportunidadService : IOportunidadService
    {
        private readonly IOportunidadRepository _oportunidadRepository;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;

        public OportunidadService(
            IOportunidadRepository oportunidadRepository,
            IEmpresaRepository empresaRepository,
            IMapper mapper)
        {
            _oportunidadRepository = oportunidadRepository;
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }

        public async Task<int> CrearAsync(
            CrearOportunidadDto dto,
            CancellationToken ct = default)
        {
            var existeEmpresa = await _empresaRepository.ExistsAsync(dto.EmpresaId, ct);
            if (!existeEmpresa)
                throw new ReglaNegocioException("La empresa asociada no existe");

            if (string.IsNullOrWhiteSpace(dto.NombreProyecto))
                throw new ReglaNegocioException("El nombre del proyecto es obligatorio");

            var oportunidad = _mapper.Map<Oportunidad>(dto);

            oportunidad.Etapa = EtapaOportunidad.Lead;

            await _oportunidadRepository.AddAsync(oportunidad, ct);

            return oportunidad.Id;
        }

        public async Task ActualizarAsync(
            int oportunidadId,
            ActualizarOportunidadDto dto,
            CancellationToken ct = default)
        {
            var oportunidad = await _oportunidadRepository.GetByIdAsync(oportunidadId, ct)
                ?? throw new EntidadNoEncontradaException("Oportunidad", oportunidadId);

            _mapper.Map(dto, oportunidad);

            await _oportunidadRepository.UpdateAsync(oportunidad, ct);
        }

        public async Task<OportunidadDto> ObtenerPorIdAsync(
            int oportunidadId,
            CancellationToken ct = default)
        {
            var oportunidad = await _oportunidadRepository.GetByIdAsync(oportunidadId, ct)
                ?? throw new EntidadNoEncontradaException("Oportunidad", oportunidadId);

            return _mapper.Map<OportunidadDto>(oportunidad);
        }

        public async Task<IEnumerable<OportunidadDto>> ObtenerPorEmpresaAsync(
            int empresaId,
            CancellationToken ct = default)
        {
            var oportunidades = await _oportunidadRepository.GetByEmpresaIdAsync(empresaId, ct);
            return _mapper.Map<IEnumerable<OportunidadDto>>(oportunidades);
        }

        public async Task CambiarEtapaAsync(
            int oportunidadId,
            EtapaOportunidad nuevaEtapa,
            CancellationToken ct = default)
        {
            var oportunidad = await _oportunidadRepository.GetByIdAsync(oportunidadId, ct)
                ?? throw new EntidadNoEncontradaException("Oportunidad", oportunidadId);

            oportunidad.Etapa = nuevaEtapa;

            await _oportunidadRepository.UpdateAsync(oportunidad, ct);
        }

        public IEnumerable<OpcionEnumDto> ObtenerEtapas()
        {
            return Enum.GetValues<EtapaOportunidad>()
                .Select(e => new OpcionEnumDto
                {
                    Valor = (int)e,
                    Nombre = e switch
                    {
                        EtapaOportunidad.Lead => "Lead",
                        EtapaOportunidad.Prospecto => "Prospecto",
                        EtapaOportunidad.PropuestaEnviada => "Propuesta Enviada",
                        EtapaOportunidad.Negociacion => "Negociación",
                        EtapaOportunidad.Ganado => "Ganado",
                        EtapaOportunidad.Perdido => "Perdido",
                        _ => e.ToString()
                    }
                });
        }
    }
}