using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SmartBite.Core.Helpers.Token
{
    public class CreateToken
    {
        private readonly IConfiguration _configuration;
        private readonly byte[] _key;

        public CreateToken(IConfiguration configuration)
        {
            _configuration = configuration;

            // Token'ı TokenSettings'den al
            var tokenString = _configuration.GetSection("TokenSettings:Token").Value ??
                            throw new InvalidOperationException("JWT secret key is not configured");

            var issuer = _configuration["TokenSettings:Issuer"] ??
                     throw new InvalidOperationException("TokenSettings:Issuer is not configured");

            var audience = _configuration["TokenSettings:Audience"] ??
                          throw new InvalidOperationException("TokenSettings:Audience is not configured");


            // Token'ı SHA512 ile hash'le ve 64 byte'a dönüştür
            using var sha512 = SHA512.Create();
            _key = sha512.ComputeHash(Encoding.UTF8.GetBytes(tokenString));
        }

        public string CreateTokenHandler(TokenRequestModel tokenRequest)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, tokenRequest.Id.ToString()),
                new Claim(ClaimTypes.Email, tokenRequest.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString())
            };

            var key = new SymmetricSecurityKey(_key);
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                issuer: _configuration["TokenSettings:Issuer"],
                audience: _configuration["TokenSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: cred);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
