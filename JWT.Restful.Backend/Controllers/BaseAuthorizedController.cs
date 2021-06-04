using JWT.Restful.Backend.Authentication;
using JWT.Restful.Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Restful.Backend.Controllers
{
    public class BaseAuthorizedController : ControllerBase, IBaseAuthorizedController
    {
        public IJWTAuthenticationManager JwtAuthenticationManager { get; }

        public BaseAuthorizedController(IJWTAuthenticationManager jwtAuthenticationManager)
        {
            JwtAuthenticationManager = jwtAuthenticationManager;
        }
    }
}
