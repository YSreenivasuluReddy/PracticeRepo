using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjectApi.Interfaces;
using ProjectApi.JWT;
using ProjectApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectApi.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtSetting _jwtSetting;

        //here i am using the constructor dependency injection.
        public JwtService(IOptions<JwtSetting> options)
        {
            _jwtSetting = options.Value;
        }

        //here i am implementing the generate access token.
        public (string Token, DateTime ExpiresAt) GenerateAccessToken(User user)
        {
            //here i am reading the configuration values from the appsettings.json file.
            //which ever i implemented.
            var key = _jwtSetting.SecretKey;
            string audience = _jwtSetting.Audience;
            string issuer = _jwtSetting.Issuer;
            int accessexpiremin = Convert.ToInt32(_jwtSetting.AccessTokenExpirationMinutes);
            int refreshdays = Convert.ToInt32(_jwtSetting.RefreshTokenExpirationDays);
            var expires = DateTime.UtcNow.AddMinutes(accessexpiremin);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var signingcredientials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            //here i generate the token with headers,claims,algorithms
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expires,
                signingCredentials: signingcredientials
            );

            //here i convert it as string
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            //i return the string.
            return (tokenString, expires);
        }
    }
}
