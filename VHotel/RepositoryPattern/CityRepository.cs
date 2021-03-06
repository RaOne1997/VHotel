using AutoMapper;
using EmployeeCrud.RepositoryPattern.RepositoryBase;
using staticclassmodel.DataAccess.Model.Master;
using VHotel.DataAccess;
using VHotel.RepositoryPattern.Interface;

namespace VHotel.RepositoryPattern
{
    public class CityRepository : Repository<CityMaster>, ICityRepository
    {
        private readonly VhotelsSQLContex _db;
        private readonly IMapper _mapper;
        public CityRepository(VhotelsSQLContex db, IMapper mapper) : base(db, mapper)
        {
             _db = db;
            _mapper = mapper;
        }
    }
}
