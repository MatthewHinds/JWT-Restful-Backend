using JWT.Restful.Backend.Authentication;
using JWT.Restful.Backend.Interfaces;
using JWT.Restful.Backend.Models.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWT.Restful.Backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : BaseAuthorizedController, IApiAuthenticate
    {
        public TestController(IJWTAuthenticationManager jwtAuthenticationManager) : base(jwtAuthenticationManager) {}

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "You're authorized!" };
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] ApiCredentials apiCredentials)
        {
            var token = JwtAuthenticationManager.Authenticate(apiCredentials);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
