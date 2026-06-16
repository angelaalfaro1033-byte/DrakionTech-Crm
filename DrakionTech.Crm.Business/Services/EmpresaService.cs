using AutoMapper;
using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Business.DTOs.Empresa;
using DrakionTech.Crm.Business.Exceptions;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using DrakionTech.Crm.Data.Context;

namespace DrakionTech.Crm.Business.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public EmpresaService(
            IEmpresaRepository empresaRepository,
            IMapper mapper,
            ApplicationDbContext db)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
            _db = db;
        }

        public async Task<ResultadoPaginacion<EmpresaDto>> ObtenerTodasConPaginacionAsync(string? busqueda = null, bool? soloActivas = null, int pagina = 1, int tamañoPagina = 10, CancellationToken ct = default)
        {
            var query = _empresaRepository.Query();

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                var term = busqueda.Trim().ToLower();

                query = query.Where(e =>
                    e.Nombre.ToLower().Contains(term) ||
                    e.NumeroDocumento.ToLower().Contains(term) ||
                    e.Correo.ToLower().Contains(term));
            }

            if (soloActivas.HasValue)
                query = query.Where(e => e.Activa == soloActivas.Value);

            var paginado = await query
                .OrderBy(e => e.Nombre)
                .PaginarAsync(pagina, tamañoPagina, ct);

            return new ResultadoPaginacion<EmpresaDto>
            {
                Items = _mapper.Map<List<EmpresaDto>>(paginado.Items),
                TotalRegistros = paginado.TotalRegistros,
                Pagina = paginado.Pagina,
                TamañoPagina = paginado.TamañoPagina
            };
        }

        public async Task<int> CrearAsync(CrearEmpresaDto dto, CancellationToken ct = default)
        {
            var empresa = new Empresa
            {
                TipoCliente = dto.TipoCliente,
                TipoDocumento = dto.TipoDocumento,
                NumeroDocumento = dto.NumeroDocumento,
                Nombre = dto.Nombre,
                Direccion = dto.Direccion,
                PaisId = dto.PaisId,
                CiudadId = dto.CiudadId,
                Telefono = dto.Telefono,
                PrefijoTelefonicoId = dto.PrefijoTelefonicoId,
                PrefijoTelefonicoCodigo = dto.PrefijoTelefonicoCodigo,
                Correo = dto.Correo,
                RepresentanteLegal = dto.RepresentanteLegal,
                FechaCreacionEmpresa = dto.FechaCreacionEmpresa,
                FechaRegistroCrm = dto.FechaRegistroCrm,
                SectorEmpresaId = dto.SectorEmpresaId,
                SubsectorEmpresaId = dto.SubsectorEmpresaId,
                Tamaño = dto.Tamaño,
                Descripcion = dto.Descripcion,
                Seguimiento = dto.Seguimiento,
                HaTrabajadoAntes = dto.HaTrabajadoAntes,
                Activa = false,
                FechaCreacion = DateTime.UtcNow
            };

            foreach (var c in dto.Correos.Where(c => c.Correo != dto.Correo))
                empresa.Correos.Add(new EmpresaCorreo { Correo = c.Correo, EsPrincipal = false });

            if (dto.ContactoPrincipal is { Nombre: not null } cp)
            {
                empresa.Contactos.Add(new Contacto
                {
                    Nombre = cp.Nombre,
                    Apellido = cp.Apellido ?? string.Empty,
                    Cargo = cp.Cargo,
                    Email = cp.Email,
                    Telefono = cp.Telefono,
                    RolContactoId = cp.RolContactoId ?? 1,
                    EsPrincipal = true,
                    FechaCreacion = DateTime.UtcNow
                });
            }

            foreach (var ca in dto.ContactosAdicionales.Where(c => c.Nombre != null))
            {
                empresa.Contactos.Add(new Contacto
                {
                    Nombre = ca.Nombre,
                    Apellido = ca.Apellido ?? string.Empty,
                    Cargo = ca.Cargo,
                    Email = ca.Email,
                    Telefono = ca.Telefono,
                    RolContactoId = ca.RolContactoId ?? 1,
                    EsPrincipal = false,
                    FechaCreacion = DateTime.UtcNow
                });
            }

            empresa.Activa = false;

            await _empresaRepository.AgregarAsync(empresa, ct);
            return empresa.Id;
        }

        public async Task ActualizarAsync(int empresaId, ActualizarEmpresaDto dto, CancellationToken ct = default)
        {
            var empresa = await _db.Empresas
                .Include(e => e.Correos)
                .Include(e => e.Contactos)
                .FirstOrDefaultAsync(e => e.Id == empresaId, ct)
                ?? throw new EntidadNoEncontradaException("Empresa", empresaId);

            empresa.TipoCliente = dto.TipoCliente;
            empresa.TipoDocumento = dto.TipoDocumento;
            empresa.NumeroDocumento = dto.NumeroDocumento;
            empresa.Nombre = dto.Nombre;
            empresa.Direccion = dto.Direccion;
            empresa.PaisId = dto.PaisId;
            empresa.CiudadId = dto.CiudadId;
            empresa.Telefono = dto.Telefono;
            empresa.PrefijoTelefonicoId = dto.PrefijoTelefonicoId;
            empresa.PrefijoTelefonicoCodigo = dto.PrefijoTelefonicoCodigo;
            empresa.Correo = dto.Correo;
            empresa.RepresentanteLegal = dto.RepresentanteLegal;
            empresa.FechaCreacionEmpresa = dto.FechaCreacionEmpresa;
            empresa.FechaRegistroCrm = dto.FechaRegistroCrm;
            empresa.SectorEmpresaId = dto.SectorEmpresaId;
            empresa.SubsectorEmpresaId = dto.SubsectorEmpresaId;
            empresa.Tamaño = dto.Tamaño;
            empresa.Descripcion = dto.Descripcion;
            empresa.Seguimiento = dto.Seguimiento;

            _db.EmpresaCorreos.RemoveRange(empresa.Correos);
            empresa.Correos = new List<EmpresaCorreo>
    {
        new() { Correo = dto.Correo!, EsPrincipal = true }
    };
            foreach (var c in dto.Correos.Where(c => c.Correo != dto.Correo))
                empresa.Correos.Add(new EmpresaCorreo { Correo = c.Correo, EsPrincipal = false });

            var principal = empresa.Contactos.FirstOrDefault(c => c.EsPrincipal);
            if (dto.ContactoPrincipal is { Nombre: not null } cp)
            {
                if (principal is null)
                {
                    empresa.Contactos.Add(new Contacto
                    {
                        Nombre = cp.Nombre,
                        Apellido = cp.Apellido ?? "",
                        Cargo = cp.Cargo,
                        Email = cp.Email,
                        Telefono = cp.Telefono,
                        RolContactoId = cp.RolContactoId ?? 1,
                        EsPrincipal = true,
                        FechaCreacion = DateTime.UtcNow
                    });
                }
                else
                {
                    principal.Nombre = cp.Nombre;
                    principal.Apellido = cp.Apellido ?? "";
                    principal.Cargo = cp.Cargo;
                    principal.Email = cp.Email;
                    principal.Telefono = cp.Telefono;
                    if (cp.RolContactoId.HasValue) principal.RolContactoId = cp.RolContactoId.Value;
                }
            }

            var contactosNoPrincipales = empresa.Contactos.Where(c => !c.EsPrincipal).ToList();
            _db.Contactos.RemoveRange(contactosNoPrincipales);

            foreach (var ca in dto.ContactosAdicionales.Where(c => c.Nombre != null))
            {
                empresa.Contactos.Add(new Contacto
                {
                    Nombre = ca.Nombre,
                    Apellido = ca.Apellido ?? string.Empty,
                    Cargo = ca.Cargo,
                    Email = ca.Email,
                    Telefono = ca.Telefono,
                    RolContactoId = ca.RolContactoId ?? 1,
                    EsPrincipal = false,
                    FechaCreacion = DateTime.UtcNow
                });
            }

            await _db.SaveChangesAsync(ct);
        }

        public async Task<EmpresaDto> ObtenerPorIdAsync(int empresaId, CancellationToken ct = default)
        {
            var empresa = await _empresaRepository.ObtenerConUbicacionAsync(empresaId, ct)
                ?? throw new EntidadNoEncontradaException("Empresa", empresaId);
            return _mapper.Map<EmpresaDto>(empresa);
        }

        public async Task<IEnumerable<EmpresaDto>> ObtenerTodasAsync(
            string? busqueda = null, bool? soloActivas = null, CancellationToken ct = default)
        {
            var query = _empresaRepository.Query();

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                var term = busqueda.Trim().ToLower();
                query = query.Where(e =>
                    e.Nombre.ToLower().Contains(term) ||
                    e.NumeroDocumento.ToLower().Contains(term) ||
                    e.Correo.ToLower().Contains(term));
            }

            if (soloActivas.HasValue)
                query = query.Where(e => e.Activa == soloActivas.Value);

            return _mapper.Map<IEnumerable<EmpresaDto>>(await query.ToListAsync(ct));
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

    }
}