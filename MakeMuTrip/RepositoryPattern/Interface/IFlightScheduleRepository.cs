using EmployeeCrud.RepositoryPattern.RepositoryBase;
using staticclassmodel.DataAccess.Model.Masters;
using staticclassmodel.DataAccess.Model.TransactionData;
using MakeMuTrip.DataAccess.DTo;

namespace MakeMuTrip.RepositoryPattern.Interface
{
    public interface IFlightScheduleRepository : IRepository<FlightSchedule>
    {
        Task<List<FlightScheduleDTO>> SearchFlight(string locationFrom, string locationTo, DateTime date);
    }
}
