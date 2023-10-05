using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Proyecto.API.Aplication.DTOs;
using Proyecto.API.Domain.Entities;
using Proyecto.API.Domain.Interfaces;
using Proyecto.API.Infrastructure.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Proyecto.API.Aplication.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public AuthToken GenerateJwt(Usuario user)
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.AccessTokenSecret);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.SerialNumber, user.Organizacion.SlugTenant),
            };

            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Audience,
                audience: _jwtSettings.Issuer,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenDurationInMinutes), // DateTime.Now.AddMinutes(30), // Define la duración del token
                signingCredentials: creds
            );

            return new AuthToken
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                SlugTenant = new List<string> { user?.Organizacion?.SlugTenant ?? string.Empty }
            };
        }
    }
}
