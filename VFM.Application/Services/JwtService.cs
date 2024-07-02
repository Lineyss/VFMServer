using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VFM.Core.Models;

namespace VFM.Application.Services
{
    public class JwtService() : IJwtService
    {
        public string GenerateToken(User user)
        {
            Claim[] claims = [new Claim(ClaimTypes.NameIdentifier, user.ID.ToString())];

            // Создаем алгоритм для кодмровки токена
            var signingCredentials = new SigningCredentials(
                // Секретный ключ для кодировки
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtOptions.SecretKey)),
                // Алгоритм шифрования
                SecurityAlgorithms.Sha256);

            var token = new JwtSecurityToken(
                // Алгоритм для кодировки токена
                signingCredentials: signingCredentials,
                // Время жизни токена
                expires: DateTime.UtcNow.AddHours(JwtOptions.ExpitesHourse),
                // Хранимая информация в токене
                claims: claims
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
