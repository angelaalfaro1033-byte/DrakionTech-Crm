using System.Security.Claims;
using DrakionTech.Crm.Business.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace DrakionTech.Crm.Business.Services;

public class AuthSessionService : IAuthSessionService
{
    public async Task SignInAsync(HttpContext ctx, string email, int usuarioId, string nombre)
    {
        var claims = new List<Claim>
    {
        new(ClaimTypes.Name, nombre),
        new(ClaimTypes.Email, email),
        new(ClaimTypes.NameIdentifier, usuarioId.ToString())
    };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        var authProperties = new AuthenticationProperties
        {
            IsPersistent = false,
            AllowRefresh = true
        };

        await ctx.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal,
            authProperties);
    }

    public async Task SignOutAsync(HttpContext ctx)
    {
        await ctx.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}