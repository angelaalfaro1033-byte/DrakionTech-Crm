using System.Security.Claims;

namespace DrakionTech.Crm.Web.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUsuarioId(this ClaimsPrincipal user)
        {
            var claim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.TryParse(claim, out var id) ? id : 0;
        }
    }
}