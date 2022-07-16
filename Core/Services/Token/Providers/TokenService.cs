using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EDiaristas.Core.Models;
using EDiaristas.Core.Services.Token.Adapters;
using Microsoft.IdentityModel.Tokens;

namespace EDiaristas.Core.Services.Token.Providers;

public class TokenService : ITokenService
{
    private readonly byte[] _accessKey;
    private readonly int _accessExpirationInSeconds;

    public TokenService(IConfiguration configuration)
    {
        _accessKey = Encoding.ASCII.GetBytes(configuration.GetValue<string>("Jwt:AccessKey"));
        _accessExpirationInSeconds = configuration.GetValue<int>("Jwt:AccessExpirationInSeconds");
    }

    public string GenerateAccessToken(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptior = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Email),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.TipoUsuario.ToTipoUsuarioName())
            }),
            Expires = DateTime.UtcNow.AddSeconds(_accessExpirationInSeconds),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_accessKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptior);
        return tokenHandler.WriteToken(token);
    }
}