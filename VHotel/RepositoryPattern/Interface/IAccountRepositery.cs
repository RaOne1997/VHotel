using EmployeeCrud.RepositoryPattern.RepositoryBase;
using MakeMuTrip.DataAccess.DTo;
using MakeMuTrip.DataAccess.Model.Master;
using staticclassmodel.DataAccess.Model.Masters;

namespace MakeMuTrip.RepositoryPattern.Interface
{
    public interface IAccountRepositery : IRepository<Account>
    {
        public Task<int> loginAsync(string userID, string Password);
        Task<int> getIdbyname(string userID);
   
    }
}
