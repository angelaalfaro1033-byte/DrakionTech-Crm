using AutoMapper;
using DrakionTech.Crm.Business.DTOs.UsuarioInterno;
using DrakionTech.Crm.Business.Exceptions;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Repositories;

namespace DrakionTech.Crm.Business.Services
{
    public class UsuarioInternoService : IUsuarioInternoService
    {
        private readonly IUsuarioInternoRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioInternoService(
            IUsuarioInternoRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> CrearAsync(
            CrearUsuarioInternoDto dto,
            CancellationToken ct = default)
        {
            if (!string.IsNullOrWhiteSpace(dto.Email))
            {
                var existente = await _repository.GetByEmailAsync(dto.Email, ct);

                if (existente != null)
                    throw new ReglaNegocioException(
                        $"Ya existe un usuario con el email {dto.Email}");
            }

            var usuario = _mapper.Map<UsuarioInterno>(dto);

            await _repository.AddAsync(usuario, ct);

            return usuario.Id;
        }

        public async Task ActualizarAsync(
            int usuarioId,
            ActualizarUsuarioInternoDto dto,
            CancellationToken ct = default)
        {
            var usuario = await _repository.GetByIdAsync(usuarioId, ct)
                ?? throw new EntidadNoEncontradaException("UsuarioInterno", usuarioId);

            if (!string.IsNullOrWhiteSpace(dto.Email))
            {
                var existente = await _repository.GetByEmailAsync(dto.Email, ct);

                if (existente != null && existente.Id != usuarioId)
                    throw new ReglaNegocioException(
                        $"Ya existe un usuario con el email {dto.Email}");
            }

            _mapper.Map(dto, usuario);

            await _repository.UpdateAsync(usuario, ct);
        }

        public async Task<UsuarioInternoDto> ObtenerPorIdAsync(
            int usuarioId,
            CancellationToken ct = default)
        {
            var usuario = await _repository.GetByIdAsync(usuarioId, ct)
                ?? throw new EntidadNoEncontradaException("UsuarioInterno", usuarioId);

            return _mapper.Map<UsuarioInternoDto>(usuario);
        }

        public async Task<IEnumerable<UsuarioInternoDto>> ObtenerActivosAsync(
            CancellationToken ct = default)
        {
            var usuarios = await _repository.GetActivosAsync(ct);
            return _mapper.Map<IEnumerable<UsuarioInternoDto>>(usuarios);
        }

        public async Task<IEnumerable<UsuarioInternoDto>> ObtenerTodosAsync(
            CancellationToken ct = default)
        {
            var usuarios = await _repository.GetAllAsync(ct);
            return _mapper.Map<IEnumerable<UsuarioInternoDto>>(usuarios);
        }
    }
}