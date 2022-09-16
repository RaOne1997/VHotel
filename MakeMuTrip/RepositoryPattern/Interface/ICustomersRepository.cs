using EmployeeCrud.RepositoryPattern.RepositoryBase;

using staticclassmodel.DataAccess.Model.Masters;

namespace MakeMuTrip.RepositoryPattern.Interface
{
    public interface ICustomersRepository : IRepository<Customer>
    {
         Task<Customer> GetbyrefID(int id);
    }
}
