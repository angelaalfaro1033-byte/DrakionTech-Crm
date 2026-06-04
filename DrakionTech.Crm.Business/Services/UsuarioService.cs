using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Business.DTOs.Usuario;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Business.Services.Email;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DrakionTech.Crm.Business.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;
    private readonly IEmailService _emailService;
    private readonly IConfiguration _config;

    public UsuarioService(
        IUsuarioRepository repository,
        IEmailService emailService,
        IConfiguration config)
    {
        _repository = repository;
        _emailService = emailService;
        _config = config;
    }

    public async Task<ResultadoPaginacion<UsuarioListDto>>
    ObtenerTodosConPaginacionAsync(string? busqueda = null, bool? soloActivos = null, int pagina = 1, int tamañoPagina = 10)
    {
        var query = _repository.Query();

        if (!string.IsNullOrWhiteSpace(busqueda))
        {
            var term = busqueda.Trim().ToLower();

            query = query.Where(u =>
                (u.Nombre != null && u.Nombre.ToLower().Contains(term)) ||
                (u.Apellido != null && u.Apellido.ToLower().Contains(term)) ||
                (u.Email != null && u.Email.ToLower().Contains(term)) ||
                (u.Rol != null && u.Rol.Nombre.ToLower().Contains(term)));
        }

        if (soloActivos.HasValue)
        {
            query = query.Where(u => u.IsActive == soloActivos.Value);
        }

        return await query
            .OrderBy(u => u.Nombre)
            .Select(u => new UsuarioListDto
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Email = u.Email,
                Telefono = u.Telefono,
                Rol = u.Rol != null ? u.Rol.Nombre : "Sin rol",
                IsActive = u.IsActive,
                AreaId = u.AreaId
            })
            .PaginarAsync(pagina, tamañoPagina);
    }

    public async Task<List<UsuarioListDto>> ObtenerTodosAsync(string? busqueda = null, bool? soloActivos = null)
    {
        var query = _repository.Query();
        if (!string.IsNullOrWhiteSpace(busqueda))
        {
            var term = busqueda.Trim().ToLower();
            query = query.Where(u =>
                (u.Nombre != null && u.Nombre.ToLower().Contains(term)) ||
                (u.Apellido != null && u.Apellido.ToLower().Contains(term)) ||
                (u.Email != null && u.Email.ToLower().Contains(term)) ||
                (u.Rol != null && u.Rol.Nombre.ToLower().Contains(term)));
        }
        if (soloActivos.HasValue)
            query = query.Where(u => u.IsActive == soloActivos.Value);

        return await query.Select(u => new UsuarioListDto
        {
            Id = u.Id,
            Nombre = u.Nombre,
            Apellido = u.Apellido,
            Email = u.Email,
            Telefono = u.Telefono,
            Rol = u.Rol != null ? u.Rol.Nombre : "Sin rol",
            IsActive = u.IsActive,
            AreaId = u.AreaId
        }).ToListAsync();
    }

    public async Task<UsuarioListDto> ObtenerPorIdAsync(int id)
    {
        var usuario = await _repository.GetByIdAsync(id)
            ?? throw new Exception(MensajesError.UsuarioNoEncontrado);
        return MapToDto(usuario);
    }

    public async Task CrearAsync(CrearUsuarioDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Email))
            throw new Exception(MensajesError.EmailObligatorio);

        var token = Guid.NewGuid().ToString();

        var usuario = new Usuario
        {
            Nombre = dto.Nombre,
            Apellido = dto.Apellido,
            Email = dto.Email,
            Telefono = dto.Telefono,
            RolId = dto.RolId,
            FechaCreacion = DateTime.UtcNow,
            IsActive = false,
            ActivationToken = token,
            ActivationTokenExpiration = DateTime.UtcNow.AddHours(24)
        };

        await _repository.AddAsync(usuario);

        var baseUrl = _config["App:BaseUrl"]
            ?? throw new Exception(MensajesError.AppBaseUrlNoConfigurado);

        var link = $"{baseUrl}/activate?token={token}";

        await _emailService.EnviarPlantillaAsync(
            usuario.Email,
            "ActivacionCuenta",
            new Dictionary<string, string>
            {
                { "Nombre", usuario.Nombre },
                { "ActivationLink", link }
            });
    }

    public async Task DesactivarAsync(int id)
    {
        var usuario = await _repository.GetByIdAsync(id)
            ?? throw new Exception(MensajesError.UsuarioNoEncontrado);

        usuario.IsActive = false;
        usuario.FechaModificacion = DateTime.UtcNow;

        await _repository.UpdateAsync(usuario);
    }

    public async Task ActivarAsync(int id)
    {
        var usuario = await _repository.GetByIdAsync(id)
            ?? throw new Exception("Usuario no encontrado");

        usuario.IsActive = true;
        usuario.FechaModificacion = DateTime.UtcNow;

        await _repository.UpdateAsync(usuario);
    }

    public async Task<bool> ActivarCuentaAsync(string token, string password)
    {
        var usuario = await _repository.GetByTokenAsync(token);

        if (usuario == null) return false;
        if (usuario.ActivationTokenExpiration < DateTime.UtcNow) return false;

        usuario.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        usuario.IsActive = true;
        usuario.ActivationToken = null;
        usuario.FechaModificacion = DateTime.UtcNow;

        await _repository.UpdateAsync(usuario);
        return true;
    }

    private static UsuarioListDto MapToDto(Usuario u) => new()
    {
        Id = u.Id,
        Nombre = u.Nombre,
        Apellido = u.Apellido,
        Email = u.Email,
        Telefono = u.Telefono,
        Rol = u.Rol?.Nombre ?? "Sin rol",
        IsActive = u.IsActive,
        AreaId = u.AreaId
    };

    public async Task EditarAsync(ActualizarUsuarioDto dto)
    {
        var usuario = await _repository.GetByIdAsync(dto.Id)
            ?? throw new Exception(MensajesError.UsuarioNoEncontrado);

        usuario.Nombre = dto.Nombre;
        usuario.Apellido = dto.Apellido;
        usuario.Email = dto.Email;
        usuario.Telefono = dto.Telefono;
        usuario.RolId = dto.RolId;
        usuario.FechaModificacion = DateTime.UtcNow;

        await _repository.UpdateAsync(usuario);
    }

    public async Task<bool> ExisteAlgunUsuarioAsync()
        => await _repository.Query().AnyAsync();

    public async Task<IEnumerable<UsuarioListDto>> ObtenerPorAreaAsync(int areaId)
    {
        var usuarios = await _repository.GetAllAsync();
        return usuarios
            .Where(u => u.AreaId == areaId && u.IsActive)
            .Select(MapToDto)
            .ToList();
    }
}