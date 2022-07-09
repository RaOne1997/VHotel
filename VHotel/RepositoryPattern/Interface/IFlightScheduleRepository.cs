using EmployeeCrud.RepositoryPattern.RepositoryBase;
using staticclassmodel.DataAccess.Model.Master;
using staticclassmodel.DataAccess.Model.TransactionData;
using VHotel.DataAccess.DTo;

namespace VHotel.RepositoryPattern.Interface
{
    public interface IFlightScheduleRepository : IRepository<FlightSchedule>
    {
        Task<List<FlightScheduleDTO>> SearchFlight(string locationFrom, string locationTo, DateTime date);
    }
}
