using JWT.Restful.Backend.Authentication;

namespace JWT.Restful.Backend.Interfaces
{
    public interface IBaseAuthorizedController
    {
        IJWTAuthenticationManager JwtAuthenticationManager { get; }
    }
}