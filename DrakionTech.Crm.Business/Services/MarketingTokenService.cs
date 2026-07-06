using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DrakionTech.Crm.Business.Services.Marketing;

public interface IMarketingTokenService
{
    string GenerarToken(int publicacionId);
    int? ValidarToken(string token);
}

public class MarketingTokenService : IMarketingTokenService
{
    private readonly string _secret;

    public MarketingTokenService(IConfiguration config)
    {
        _secret = config["Marketing:TokenSecret"]
            ?? throw new InvalidOperationException("Marketing:TokenSecret no configurado");
    }

    public string GenerarToken(int publicacionId)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: [new Claim("pub", publicacionId.ToString())],
            expires: DateTime.UtcNow.AddDays(2),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public int? ValidarToken(string token)
    {
        try
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            var handler = new JwtSecurityTokenHandler();

            handler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                IssuerSigningKey = key,
                ClockSkew = TimeSpan.Zero
            }, out var validated);

            var jwt = (JwtSecurityToken)validated;
            return int.Parse(jwt.Claims.First(c => c.Type == "pub").Value);
        }
        catch
        {
            return null;
        }
    }
}