using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjectApi.Interfaces;
using ProjectApi.JWT;
using ProjectApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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

            //contains the user information
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
            };
            //Encoding.UTF8.GetBytes(key) - it converts the string value to bytes,
            // because it accepts the crypograpic algorithum works with bytes.
            //it creates the signing and validates the key which is comes from the configuration key value,
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            //it signs the security key with alogorithm.
            //because it protects the sign key that nobody has modified the security key.
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
            //JwtSecurityTokenHandler() - creats the token handler.
            //WriteToken(token) serializes the JWT object into a string.
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            //i return the string.
            return (tokenString, expires);
        }

        public string GenerateRefreshToken()
        {
            //initially i take empty 64bytes array
            var refreshbytes = new byte[64];

            //here it creates the random unique number is generates.
            var randomnumber = RandomNumberGenerator.Create();

            //it gets the bytes
            randomnumber.GetBytes(refreshbytes);

            return Convert.ToBase64String(refreshbytes);
        }

        public string HashRefreshToken(string token)
        {
            //here it converts the string value to bytes.
            var tokenBytes = Encoding.UTF8.GetBytes(token);

            //it hashes the cryptograpic value
            var hashBytes = SHA256.HashData(tokenBytes);

            //and then again it converts the string
            return Convert.ToBase64String(hashBytes);
        }
    }
}
