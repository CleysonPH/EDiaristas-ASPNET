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
    private readonly byte[] _refreshKey;
    private readonly int _refreshExpirationInSeconds;

    public TokenService(IConfiguration configuration)
    {
        _accessKey = Encoding.ASCII.GetBytes(configuration.GetValue<string>("Jwt:AccessKey"));
        _accessExpirationInSeconds = configuration.GetValue<int>("Jwt:AccessExpirationInSeconds");
        _refreshKey = Encoding.ASCII.GetBytes(configuration.GetValue<string>("Jwt:RefreshKey"));
        _refreshExpirationInSeconds = configuration.GetValue<int>("Jwt:RefreshExpirationInSeconds");
    }

    public string GenerateAccessToken(Usuario usuario)
    {
        return generateToken(usuario, _accessKey, _accessExpirationInSeconds);
    }

    public string GenerateRefreshToken(Usuario usuario)
    {
        return generateToken(usuario, _refreshKey, _refreshExpirationInSeconds);
    }

    public string GetEmailFromRefreshToken(string accessToken)
    {
        var claims = getClaims(accessToken, _refreshKey);
        var email = claims.First(c => c.Type == ClaimTypes.Email).Value;
        return email;
    }

    public DateTime GetExpirationDateFromRefreshToken(string refreshToken)
    {
        var claims = getClaims(refreshToken, _refreshKey);
        var expirationDate = claims.First(c => c.Type == JwtRegisteredClaimNames.Exp).Value;
        return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(double.Parse(expirationDate));
    }

    private IEnumerable<Claim> getClaims(string token, byte[] key)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenObject = tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero
        }, out var securityToken);
        var claims = tokenObject.Claims;
        return claims;
    }

    private string generateToken(Usuario usuario, byte[] key, int expirationInSeconds)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptior = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.TipoUsuario.ToTipoUsuarioName())
            }),
            Expires = DateTime.UtcNow.AddSeconds(expirationInSeconds),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptior);
        return tokenHandler.WriteToken(token);
    }
}