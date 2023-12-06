using Domain.Authontication;
using Domain.Users;
using Infrastructure.Authontication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Authontication
{
    internal class JWTTokenGenerator : ITokenGenerator
    {
        private readonly JwtSettings _jwtSettings;
        

        public JWTTokenGenerator(IOptions<JwtSettings> jwtOptinos)
        {
            _jwtSettings = jwtOptinos.Value;
        }
        public string GenerateToken(User user)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256
                );
            var claims = new List<Claim>()
            {
                new(JwtRegisteredClaimNames.Name,user.Name),
                new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new (ITokenGenerator.Id,user.Id.ToString()),
                new (ClaimTypes.Role,user.Role.Name)
            };
            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                claims: claims,
                signingCredentials: signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
