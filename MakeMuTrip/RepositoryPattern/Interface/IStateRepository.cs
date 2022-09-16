using EmployeeCrud.RepositoryPattern.RepositoryBase;
using staticclassmodel.DataAccess.Model.Masters;
using MakeMuTrip.DataAccess.DTo;

namespace MakeMuTrip.RepositoryPattern.Interface
{
    public interface IStateRepository : IRepository<State>
    {

        Task<List<State>> GetStateByCont(int contid);
        Task<List<DropDownViewModel>> GetForDropDownAsync(int contid);

    }
}