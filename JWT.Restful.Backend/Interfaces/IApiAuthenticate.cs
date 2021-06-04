using JWT.Restful.Backend.Models.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Restful.Backend.Interfaces
{
    public interface IApiAuthenticate
    {
        public IActionResult Authenticate([FromBody] ApiCredentials apiCredentials);
    }
}
