using VHotel.DataAccess.Model.security;

namespace VHotel.Services
{
    public interface IAuthTokenService
    {
        AuthResponse GetAuthToken(string username, string password);
    }
}