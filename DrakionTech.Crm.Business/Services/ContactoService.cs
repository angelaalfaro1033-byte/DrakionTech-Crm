using AutoMapper;
using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Business.DTOs.Catalogo;
using DrakionTech.Crm.Business.DTOs.Contacto;
using DrakionTech.Crm.Business.Exceptions;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DrakionTech.Crm.Business.Services
{
    public class ContactoService : IContactoService
    {
        private readonly IContactoRepository _contactoRepository;
        private readonly IRolContactoRepository _rolContactoRepository;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;

        public ContactoService(
            IContactoRepository contactoRepository,
            IEmpresaRepository empresaRepository,
            IRolContactoRepository rolContactoRepository,
            IMapper mapper)
        {
            _contactoRepository = contactoRepository;
            _empresaRepository = empresaRepository;
            _rolContactoRepository = rolContactoRepository;
            _mapper = mapper;
        }

        public async Task<int> CrearAsync(
            CrearContactoDto dto,
            CancellationToken ct = default)
        {
            var existeEmpresa = await _empresaRepository.ExisteAsync(dto.EmpresaId, ct);
            if (!existeEmpresa)
                throw new ReglaNegocioException(MensajesError.EmpresaAsociadaNoExiste);

            var existeRol = await _rolContactoRepository.ExisteAsync(dto.RolContactoId, ct);
            if (!existeRol)
                throw new ReglaNegocioException(MensajesError.RolContactoNoExiste);

            var contacto = _mapper.Map<Contacto>(dto);

            await _contactoRepository.AgregarAsync(contacto, ct);

            return contacto.Id;
        }

        public async Task ActualizarAsync(
            int contactoId,
            ActualizarContactoDto dto,
            CancellationToken ct = default)
        {
            var contacto = await _contactoRepository.ObtenerPorIdAsync(contactoId, ct)
                ?? throw new EntidadNoEncontradaException("Contacto", contactoId);

            var existeRol = await _rolContactoRepository.ExisteAsync(dto.RolContactoId, ct);
            if (!existeRol)
                throw new ReglaNegocioException(MensajesError.RolContactoNoExiste);

            _mapper.Map(dto, contacto);

            await _contactoRepository.ActualizarAsync(contacto, ct);
        }

        public async Task<ContactoDto> ObtenerPorIdAsync(
            int contactoId,
            CancellationToken ct = default)
        {
            var contacto = await _contactoRepository.ObtenerPorIdAsync(contactoId, ct)
                ?? throw new EntidadNoEncontradaException("Contacto", contactoId);

            return _mapper.Map<ContactoDto>(contacto);
        }

        public async Task<IEnumerable<ContactoDto>> ObtenerPorEmpresaAsync(
            int empresaId,
            CancellationToken ct = default)
        {
            var contactos = await _contactoRepository.GetByEmpresaIdAsync(empresaId, ct);
            return _mapper.Map<IEnumerable<ContactoDto>>(contactos);
        }

        public async Task<IEnumerable<CatalogoDto>> ObtenerRolesContactoAsync(CancellationToken ct = default)
        {
            var roles = await _rolContactoRepository.ObtenerTodosAsync(ct);
            return roles.Select(r => new CatalogoDto
            {
                Id = r.Id,
                Nombre = r.Nombre
            });
        }
    }
}