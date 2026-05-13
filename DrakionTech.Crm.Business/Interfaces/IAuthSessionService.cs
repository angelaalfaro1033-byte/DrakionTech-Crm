using Microsoft.AspNetCore.Http;

namespace DrakionTech.Crm.Business.Interfaces;

public interface IAuthSessionService
{
    Task SignInAsync(HttpContext ctx, string email, int usuarioId, string nombre);
    Task SignOutAsync(HttpContext ctx);
}