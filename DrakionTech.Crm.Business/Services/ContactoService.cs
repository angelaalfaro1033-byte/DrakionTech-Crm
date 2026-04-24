using AutoMapper;
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
            var existeEmpresa = await _empresaRepository.ExistsAsync(dto.EmpresaId, ct);
            if (!existeEmpresa)
                throw new ReglaNegocioException("La empresa asociada no existe");

            var existeRol = await _rolContactoRepository.ExistsAsync(dto.RolContactoId, ct);
            if (!existeRol)
                throw new ReglaNegocioException("El rol de contacto no existe");

            var contacto = _mapper.Map<Contacto>(dto);

            await _contactoRepository.AddAsync(contacto, ct);

            return contacto.Id;
        }

        public async Task ActualizarAsync(
            int contactoId,
            ActualizarContactoDto dto,
            CancellationToken ct = default)
        {
            var contacto = await _contactoRepository.GetByIdAsync(contactoId, ct)
                ?? throw new EntidadNoEncontradaException("Contacto", contactoId);

            var existeRol = await _rolContactoRepository.ExistsAsync(dto.RolContactoId, ct);
            if (!existeRol)
                throw new ReglaNegocioException("El rol de contacto no existe");

            _mapper.Map(dto, contacto);

            await _contactoRepository.UpdateAsync(contacto, ct);
        }

        public async Task<ContactoDto> ObtenerPorIdAsync(
            int contactoId,
            CancellationToken ct = default)
        {
            var contacto = await _contactoRepository.GetByIdAsync(contactoId, ct)
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
            var roles = await _rolContactoRepository.GetAllAsync(ct);
            return roles.Select(r => new CatalogoDto
            {
                Id = r.Id,
                Nombre = r.Nombre
            });
        }
    }
}