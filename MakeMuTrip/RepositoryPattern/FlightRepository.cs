using AutoMapper;
using EmployeeCrud.RepositoryPattern.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using staticclassmodel.DataAccess.Model.Masters;
using MakeMuTrip.DataAccess;
using MakeMuTrip.DataAccess.DTo;
using MakeMuTrip.RepositoryPattern.Interface;

namespace MakeMuTrip.RepositoryPattern
{
    public class FlightRepository : Repository<Flight>, IFlightRepository
    {
        private readonly VhotelsSQLContex _db;
        private readonly IMapper _mapper;

        public FlightRepository(VhotelsSQLContex db, IMapper mapper) : base(db, mapper)
        {
            _db = db;
            _mapper = mapper;
        }


    }

}

