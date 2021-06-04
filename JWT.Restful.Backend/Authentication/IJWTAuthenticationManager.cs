using JWT.Restful.Backend.Models.Authentication;

namespace JWT.Restful.Backend.Authentication
{
    public interface IJWTAuthenticationManager
    {
        public string Authenticate(ApiCredentials apiCredentials);
    }
}
