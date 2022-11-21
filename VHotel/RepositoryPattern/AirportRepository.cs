using AutoMapper;
using EmployeeCrud.RepositoryPattern.RepositoryBase;
using staticclassmodel.DataAccess.Model.Masters;
using MakeMuTrip.DataAccess;
using MakeMuTrip.RepositoryPattern.Interface;
using VHotel.Migrations;

namespace MakeMuTrip.RepositoryPattern
{
    public class AirportRepository : Repository<Airport>, IAirportRepository
    {
        private readonly VhotelsSQLContex _db;
        private readonly IMapper _mapper;
        public AirportRepository(VhotelsSQLContex db, IMapper mapper) : base(db, mapper)
        {
             _db = db;
            _mapper = mapper;
        }



        public async Task IsActiveornot()
        {
            var objects = await DbSet.FindAsync(1);

            objects.Isactive = true;
        }
    }
}
