using JWT.Restful.Backend.Models.Authentication;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace JWT.Restful.Backend.Authentication
{
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        private readonly Dictionary<string, string> tempUserStore = new Dictionary<string, string> { { "username1", "password1" }};

        public string Key { get; }

        public JWTAuthenticationManager(string key)
        {
            Key = key;
        }

        public string Authenticate(ApiCredentials apiCredentials)
        {
            if (!tempUserStore.Any(x => x.Key == apiCredentials.Username && x.Value == apiCredentials.Password))
            {
                return null;       
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, apiCredentials.Username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
