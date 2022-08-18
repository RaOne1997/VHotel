using VHotel.DataAccess.DTo;

namespace VHotel.Services
{
    public interface IAccountService
    {
        Task<List<AccountDTO>> GetAllAsync();

        Task<AccountDTO> login(string userID, string Password);
        Task<int> getidBYname(string userID);
        Task<AccountDTO> getidBYname(int userID);
        Task CreateAsync(AccountDTO accountDTO);
       
    }
}