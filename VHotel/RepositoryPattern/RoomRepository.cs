using AutoMapper;
using EmployeeCrud.RepositoryPattern.RepositoryBase;
using staticclassmodel.DataAccess.Model.Master;
using VHotel.DataAccess;

namespace VHotel.RepositoryPattern
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {

        private readonly VhotelsSQLContex _db;
        private readonly IMapper _mapper;
        public RoomRepository(VhotelsSQLContex db, IMapper mapper) : base(db, mapper)
        {
            _db = db;
            _mapper = mapper;
        }

    }
}
