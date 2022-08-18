using EmployeeCrud.RepositoryPattern.RepositoryBase;
using VHotel.DataAccess.Model.Master;

namespace VHotel.RepositoryPattern.Interface
{
    public interface IAccountRepositery : IRepository<Account>
    {
        public Task<Account> loginAsync(string userID, string Password);
        Task<int> getIdbyname(string userID);
   
    }
}
