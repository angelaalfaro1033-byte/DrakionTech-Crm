using DrakionTech.Crm.Business.DTOs.Usuario;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Business.Services.Email;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Repositories.Interfaces;
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

    public async Task<List<UsuarioListDto>> ObtenerTodosAsync()
    {
        var usuarios = await _repository.GetAllAsync();
        return usuarios.Select(MapToDto).ToList();
    }

    public async Task<UsuarioListDto> ObtenerPorIdAsync(int id)
    {
        var usuario = await _repository.GetByIdAsync(id)
            ?? throw new Exception("Usuario no encontrado");
        return MapToDto(usuario);
    }

    public async Task CrearAsync(CrearUsuarioDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Email))
            throw new Exception("El email es obligatorio");

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
            ?? throw new Exception("App:BaseUrl no está configurado");

        var link = $"{baseUrl}/activate?token={token}";

        await _emailService.SendTemplateAsync(
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
            ?? throw new Exception("Usuario no encontrado");

        usuario.IsActive = false;
        usuario.FechaModificacion = DateTime.UtcNow;

        await _repository.UpdateAsync(usuario);
    }

    public async Task<bool> ActivarCuentaAsync(string token, string password)
    {
        var usuario = (await _repository.GetAllAsync())
            .FirstOrDefault(u => u.ActivationToken == token);

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
        IsActive = u.IsActive
    };

    public async Task EditarAsync(ActualizarUsuarioDto dto)
    {
        var usuario = await _repository.GetByIdAsync(dto.Id)
            ?? throw new Exception("Usuario no encontrado");

        usuario.Nombre = dto.Nombre;
        usuario.Apellido = dto.Apellido;
        usuario.Email = dto.Email;
        usuario.Telefono = dto.Telefono;
        usuario.RolId = dto.RolId;
        usuario.FechaModificacion = DateTime.UtcNow;

        await _repository.UpdateAsync(usuario);
    }
}