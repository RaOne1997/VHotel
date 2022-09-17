using VHotel.DataAccess.Model.Master;
using VHotel.DataAccess.Model.security;

namespace VHotel.Services
{
    public interface IAuthTokenService
    {
        Task<AuthResponse> GetAuthTokenAsync(LoginViewModel model);
    }
}