using MakeMuTrip.DataAccess.DTo;

namespace MakeMuTrip.Services
{
    public interface IAccountService
    {
        Task<List<AccountDTO>> GetAllAsync();

        Task<int> login(string userID, string Password);
        Task<int> getidBYname(string userID);
        Task<AccountDTO> getidBYname(int userID);
        Task CreateAsync(AccountDTO accountDTO);
       
    }
}