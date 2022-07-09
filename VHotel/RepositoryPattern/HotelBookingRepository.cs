using AutoMapper;
using EmployeeCrud.RepositoryPattern.RepositoryBase;
using staticclassmodel.DataAccess.Model.Master;
using staticclassmodel.DataAccess.Model.TransactionData;
using VHotel.DataAccess;
using VHotel.RepositoryPattern.Interface;

namespace VHotel.RepositoryPattern
{
    public class HotelBookingRepository : Repository<HotelBooking>, IHotelBookingRepository
    {
        private readonly VhotelsSQLContex db;
        private readonly IMapper mapper;

        public HotelBookingRepository(VhotelsSQLContex db, IMapper mapper) : base(db, mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
    }
}
