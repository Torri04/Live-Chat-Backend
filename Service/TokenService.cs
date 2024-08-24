using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ASP.NET_API.Interfaces;
using ASP.NET_SignalR.Model;
using Microsoft.IdentityModel.Tokens;

namespace ASP.NET_SignalR.Service;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    private SymmetricSecurityKey _key;
    public TokenService(IConfiguration config)
    {
        _config = config;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("JWT")["SigningKey"]));
    }
    public string CreateToken(AppUser user)
    {
        //JSON: Header(creds).Payload(claims).Signature(creds)

        //Claims for authentication (Payload)
        var claims = new List<Claim>() {
              new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
             };

        //SigningCredentials (creds)
        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(15),
            SigningCredentials = creds,
            Issuer = _config.GetSection("JWT")["Issuer"],
            Audience = _config.GetSection("JWT")["Audience"],
        };

        var tokenHandle = new JwtSecurityTokenHandler();

        var token = tokenHandle.CreateToken(tokenDescriptor);

        return tokenHandle.WriteToken(token);
    }
}
