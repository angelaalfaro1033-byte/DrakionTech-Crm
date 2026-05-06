using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Entities.Enums;
using DrakionTech.Crm.Data.Repositories.Interfaces;

namespace DrakionTech.Crm.Business.Services;

public class AccountService : IAccountService
{
    private readonly IUsuarioRepository _repo;

    public AccountService(IUsuarioRepository repo)
    {
        _repo = repo;
    }

    public async Task<LoginErrorEnum> LoginAsync(string email, string password)
    {
        var user = await _repo.GetByEmailAsync(email);

        if (user == null || string.IsNullOrEmpty(user.PasswordHash))
            return LoginErrorEnum.Credenciales;

        if (!user.IsActive)
            return LoginErrorEnum.Inactivo;

        if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            return LoginErrorEnum.Credenciales;

        return LoginErrorEnum.Ninguno;
    }

    public async Task<RegistroResultadoEnum> RegistroInicialAsync(
        string nombre, string apellido, string email, string password, string confirmar)
    {
        var usuarios = await _repo.GetAllAsync();
        if (usuarios.Any()) return RegistroResultadoEnum.Bloqueado;

        if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) ||
            string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            return RegistroResultadoEnum.CamposFaltantes;

        if (password != confirmar) return RegistroResultadoEnum.PasswordsNoCoinciden;
        if (password.Length < 8) return RegistroResultadoEnum.PasswordCorta;

        var admin = new Usuario
        {
            Nombre = nombre,
            Apellido = apellido,
            Email = email,
            RolId = 1,
            FechaCreacion = DateTime.UtcNow,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
            IsActive = true
        };

        await _repo.AddAsync(admin);
        return RegistroResultadoEnum.Ok;
    }

    public async Task<(GoogleCallbackResultadoEnum resultado, Usuario? user)> GoogleCallbackAsync(string? email)
    {
        if (string.IsNullOrEmpty(email))
            return (GoogleCallbackResultadoEnum.EmailNulo, null);

        var user = await _repo.GetByEmailAsync(email);

        if (user == null) return (GoogleCallbackResultadoEnum.NoRegistrado, null);
        if (!user.IsActive) return (GoogleCallbackResultadoEnum.Inactivo, null);

        return (GoogleCallbackResultadoEnum.Ok, user);
    }
}