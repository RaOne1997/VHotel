using AutoMapper;
using VHotel.DataAccess.DTo;

namespace VHotel.Services
{
    public class RoomServices : IRoomServices
    {
        private readonly IRoomServices _RoomServices;
        private readonly IMapper _mapper;

        public RoomServices(IRoomServices roomServices,IMapper mapper)
        {
            _RoomServices = roomServices;
            _mapper=mapper;
        }

        public Task CreateAsync(RoomDTO roomDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<RoomDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RoomDTO?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(RoomDTO roomDTO)
        {
            throw new NotImplementedException();
        }
    }
}
