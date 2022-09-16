using AutoMapper;
using EmployeeCrud.RepositoryPattern.RepositoryBase;
using staticclassmodel.DataAccess.Model.Masters;
using MakeMuTrip.DataAccess;
using MakeMuTrip.RepositoryPattern.Interface;

namespace MakeMuTrip.RepositoryPattern
{
    public class HotelRepository : Repository<Hotel>, IHotelRepository
    {
        private readonly VhotelsSQLContex _db;
        private readonly IMapper _mapper;
     
        public HotelRepository(VhotelsSQLContex db, IMapper mapper) : base(db, mapper)
        {
            _db = db;
            _mapper = mapper;
        }
    }
}
