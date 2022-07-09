using AutoMapper;
using EmployeeCrud.RepositoryPattern.RepositoryBase;
using staticclassmodel.DataAccess.Model.Master;
using VHotel.DataAccess;
using VHotel.RepositoryPattern.Interface;

namespace VHotel.RepositoryPattern
{
    public class HotelAmenitiesLinkRepository : Repository<HotelAmenitiesLink>, IHotelAmenitiesLinkRepository
    {
        private readonly VhotelsSQLContex _db;
        private readonly IMapper _mapper;
        public HotelAmenitiesLinkRepository(VhotelsSQLContex db, IMapper mapper) : base(db, mapper)
        {
             _db = db;
            _mapper = mapper;
        }
    }
}
