using EmployeeCrud.RepositoryPattern.RepositoryBase;
using MakeMuTrip.DataAccess.Model.Master;

namespace MakeMuTrip.RepositoryPattern.Interface
{
    public interface IAccountRepositery : IRepository<Account>
    {
        public Task<Account> loginAsync(string userID, string Password);
        Task<int> getIdbyname(string userID);
   
    }
}
