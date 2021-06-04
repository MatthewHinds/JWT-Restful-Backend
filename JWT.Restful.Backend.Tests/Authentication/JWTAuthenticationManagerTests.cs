using JWT.Restful.Backend.Models.Authentication;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JWT.Restful.Backend.Authentication.Tests
{
    [TestClass()]
    public class JWTAuthenticationManagerTests
    {
        private string Key => "A testful key that is quite long";
        private ApiCredentials apiCredentials;
        private JWTAuthenticationManager authenticationManager;

        [TestInitialize]
        public void JWTAuthenticationManagerTestsInitializer()
        {
            // Credential preperation
            apiCredentials = new ApiCredentials
            {
                Username = "username1",
                Password = "password1"
            };

            // Authentication manager preperation
            authenticationManager = new JWTAuthenticationManager(Key);
        }

        [TestMethod()]
        public void JWT_CreateToken_ShouldBeValidatedAsTrue()
        {
            // Create a token and it's validation parameters
            var token = authenticationManager.Authenticate(apiCredentials);

            var tokenParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key)),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            // Validate the token
            SecurityToken validatedToken;
            var handler = new JwtSecurityTokenHandler();
            var username = handler.ValidateToken(token, tokenParameters, out validatedToken);

            Assert.AreEqual(username.Identity.Name, apiCredentials.Username);
        }
    }
}