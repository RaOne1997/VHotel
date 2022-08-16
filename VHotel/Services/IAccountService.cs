using VHotel.DataAccess.DTo;

namespace VHotel.Services
{
    public interface IAccountService
    {
        Task<List<AccountDTO>> GetAllAsync();

        Task<AccountDTO> login(string userID, string Password);
    }
}