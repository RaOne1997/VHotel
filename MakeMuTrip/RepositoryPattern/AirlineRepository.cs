using AutoMapper;
using EmployeeCrud.RepositoryPattern.RepositoryBase;
using staticclassmodel.DataAccess.Model.Masters;
using MakeMuTrip.DataAccess;
using MakeMuTrip.RepositoryPattern.Interface;

namespace MakeMuTrip.RepositoryPattern
{
    public class AirlineRepository : 
        Repository<AirlineDetails>, IAirlineRepository
    {
        private readonly VhotelsSQLContex db;
        private readonly IMapper mapper;

        public AirlineRepository(VhotelsSQLContex db, IMapper mapper) : base(db, mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
    }
}
