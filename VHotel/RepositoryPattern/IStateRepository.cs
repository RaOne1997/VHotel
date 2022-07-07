using EmployeeCrud.RepositoryPattern.RepositoryBase;
using staticclassmodel.DataAccess.Model.Master;

namespace VHotel.RepositoryPattern
{
    public interface IStateRepository : IRepository<State>
    {
     
        Task<List<State>> GetStateByCont(int contid);

    }
}
