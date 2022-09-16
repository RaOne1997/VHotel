using AutoMapper;
using EmployeeCrud.RepositoryPattern.RepositoryBase;
using staticclassmodel.DataAccess.Model.Masters;
using staticclassmodel.DataAccess.Model.TransactionData;
using MakeMuTrip.DataAccess;
using MakeMuTrip.RepositoryPattern.Interface;

namespace MakeMuTrip.RepositoryPattern
{
    public class FlightCustomeDetailRepository : Repository<FlightCustomerDetail>, IFlightCustomeDetailRepository
    {
        private readonly VhotelsSQLContex db;
        private readonly IMapper mapper;

        public FlightCustomeDetailRepository(VhotelsSQLContex db, IMapper mapper) : base(db, mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
    }
}
