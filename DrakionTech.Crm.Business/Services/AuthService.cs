using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using DrakionTech.Crm.Data.Repositories.Interfaces;

public class AuthService : IAuthService
{
    private readonly IEmpleadoRepository _repo;
    private readonly IHttpContextAccessor _httpContext;

    public AuthService(IEmpleadoRepository repo, IHttpContextAccessor httpContext)
    {
        _repo = repo;
        _httpContext = httpContext;
    }

    public async Task<bool> LoginAsync(string email, string password)
    {
        var user = (await _repo.GetAllAsync())
            .FirstOrDefault(x => x.Email == email);

        if (user == null)
            return false;

        if (!user.IsActive)
            throw new Exception("Cuenta no activada");

        if (string.IsNullOrEmpty(user.PasswordHash))
            return false;

        if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            return false;

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email),
            new Claim("UserId", user.Id.ToString())
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await _httpContext.HttpContext!.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal);

        return true;
    }

    public async Task LogoutAsync()
    {
        await _httpContext.HttpContext!.SignOutAsync();
    }
}