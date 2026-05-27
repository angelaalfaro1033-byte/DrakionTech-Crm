using AutoMapper;
using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Business.DTOs.Empresa;
using DrakionTech.Crm.Business.Exceptions;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Repositories;

namespace DrakionTech.Crm.Business.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly ISectorRepository _sectorRepository;
        private readonly IEstadoRepository _estadoRepository;
        private readonly IMapper _mapper;

        public EmpresaService(
            IEmpresaRepository empresaRepository,
            ISectorRepository sectorRepository,
            IEstadoRepository estadoRepository,
            IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _sectorRepository = sectorRepository;
            _estadoRepository = estadoRepository;
            _mapper = mapper;
        }

        public async Task<int> CrearAsync(CrearEmpresaDto dto, CancellationToken ct = default)
        {
            await ValidarCatalogosAsync(dto, ct);
            NormalizarEmpresa(dto);
            var empresa = _mapper.Map<Empresa>(dto);
            await _empresaRepository.AgregarAsync(empresa, ct);
            return empresa.Id;
        }

        public async Task ActualizarAsync(int empresaId, ActualizarEmpresaDto dto, CancellationToken ct = default)
        {
            await ValidarCatalogosAsync(dto, ct);
            var empresa = await _empresaRepository.ObtenerPorIdAsync(empresaId, ct)
                ?? throw new EntidadNoEncontradaException("Empresa", empresaId);
            _mapper.Map(dto, empresa);
            await _empresaRepository.ActualizarAsync(empresa, ct);
        }

        public async Task<EmpresaDto> ObtenerPorIdAsync(int empresaId, CancellationToken ct = default)
        {
            var empresa = await _empresaRepository.ObtenerConUbicacionAsync(empresaId, ct)
                ?? throw new EntidadNoEncontradaException("Empresa", empresaId);
            return _mapper.Map<EmpresaDto>(empresa);
        }

        public async Task<IEnumerable<EmpresaDto>> ObtenerTodasAsync(string? busqueda = null, bool? soloActivas = null, CancellationToken ct = default)
        {
            var empresas = await _empresaRepository.ObtenerTodasConRelacionesAsync(ct);

            var query = empresas.AsQueryable();

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                var term = busqueda.Trim().ToLower();
                query = query.Where(e =>
                    (e.Nombre != null && e.Nombre.ToLower().Contains(term)) ||
                    (e.Nit != null && e.Nit.ToLower().Contains(term)) ||
                    (e.Correo != null && e.Correo.ToLower().Contains(term)));
            }

            if (soloActivas.HasValue)
                query = query.Where(e => e.Activa == soloActivas.Value);

            return _mapper.Map<IEnumerable<EmpresaDto>>(query.ToList());
        }

        public async Task ActivarAsync(int empresaId, CancellationToken ct = default)
        {
            var empresa = await _empresaRepository.ObtenerPorIdAsync(empresaId, ct)
                ?? throw new EntidadNoEncontradaException("Empresa", empresaId);
            empresa.Activa = true;
            await _empresaRepository.ActualizarAsync(empresa, ct);
        }

        public async Task DesactivarAsync(int empresaId, CancellationToken ct = default)
        {
            var empresa = await _empresaRepository.ObtenerPorIdAsync(empresaId, ct)
                ?? throw new EntidadNoEncontradaException("Empresa", empresaId);
            empresa.Activa = false;
            await _empresaRepository.ActualizarAsync(empresa, ct);
        }

        private async Task ValidarCatalogosAsync(IEmpresaCatalogoDto dto, CancellationToken ct)
        {
            await ValidarCatalogoAsync(dto.SectorId, dto.SectorOtro, "sector", _sectorRepository.ExisteAsync, ct);
            await ValidarCatalogoAsync(dto.EstadoId, dto.EstadoOtro, "estado", _estadoRepository.ExisteAsync, ct);
        }

        private static async Task ValidarCatalogoAsync(
            int? id, string? otro, string nombreCampo,
            Func<int, CancellationToken, Task<bool>> existsFunc,
            CancellationToken ct)
        {
            if (id == null && string.IsNullOrWhiteSpace(otro))
                throw new ReglaNegocioException($"Debe seleccionar un {nombreCampo} o ingresar otro.");

            if (id != null && !string.IsNullOrWhiteSpace(otro))
                throw new ReglaNegocioException($"No puede seleccionar un {nombreCampo} y escribir otro al mismo tiempo.");

            if (id != null)
            {
                var existe = await existsFunc(id.Value, ct);
                if (!existe)
                    throw new ReglaNegocioException($"El {nombreCampo} seleccionado no existe.");
            }
        }

        private static void NormalizarEmpresa(IEmpresaCatalogoDto dto)
        {
            if (dto is CrearEmpresaDto crear)
            {
                crear.Nombre = TextNormalizer.ToTitleCase(crear.Nombre);
                crear.Direccion = TextNormalizer.ToTitleCase(crear.Direccion);
                crear.Correo = TextNormalizer.NormalizeEmail(crear.Correo);
                crear.Nit = TextNormalizer.NormalizeNit(crear.Nit);
                crear.RepresentanteLegal = TextNormalizer.ToTitleCase(crear.RepresentanteLegal);
                crear.Telefono = TextNormalizer.ToUpper(crear.Telefono);
            }

            if (dto is ActualizarEmpresaDto actualizar)
            {
                actualizar.Nombre = TextNormalizer.ToTitleCase(actualizar.Nombre);
                actualizar.Direccion = TextNormalizer.ToTitleCase(actualizar.Direccion);
                actualizar.Correo = TextNormalizer.NormalizeEmail(actualizar.Correo);
                actualizar.RepresentanteLegal = TextNormalizer.ToTitleCase(actualizar.RepresentanteLegal);
                actualizar.Telefono = TextNormalizer.ToUpper(actualizar.Telefono);
            }
        }
    }
}