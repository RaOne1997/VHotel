using AutoMapper;
using staticclassmodel.DataAccess.Model.Masters;
using MakeMuTrip.DataAccess.DTo;
using MakeMuTrip.RepositoryPattern.Interface;
using MakeMuTrip.Services.Interface;

namespace MakeMuTrip.Services
{
    public class RoomServices : IRoomServices
    {
        private readonly IRoomRepository _RoomServices;
        private readonly IMapper _mapper;

        public RoomServices(IRoomRepository roomServices, IMapper mapper)
        {
            _RoomServices = roomServices;
            _mapper = mapper;
        }

        public async Task CreateAsync(RoomDTO roomDTO)
        {
            await using var memorystring = new MemoryStream();
            await roomDTO.RoomImagesUplode.CopyToAsync(memorystring);
            roomDTO.RoomImage = memorystring.ToArray();

            var room = _mapper.Map<Room>(roomDTO);
            await _RoomServices.CreateAsync(room); ;
        }

        public async Task DeleteAsync(int id)
        {
            if (await _RoomServices.Exists(id))
            {
                await _RoomServices.DeleteAsync(id);
            }

        }

        public Task<bool> Exists(int id)
        {
            return _RoomServices.Exists(id);
        }

        public async Task<List<RoomDTO>> GetAllAsync()
        {
            var citys = await _RoomServices.GetAllAsync<RoomDTO>();

            var cityMasterdtos = citys
                .Select(d => _mapper.Map<RoomDTO>(d))
                .ToList();

            return cityMasterdtos;
        }

        public async Task<RoomDTO?> GetByIdAsync(int id)
        {
            return await _RoomServices.GetByIdAsync<RoomDTO>(id);
        }

        public async Task UpdateAsync(RoomDTO roomDTO)
        {
            try
            {

                if (await _RoomServices.Exists((int)roomDTO.ID))
                {
                    var room = _mapper.Map<Room>(roomDTO);
                    await _RoomServices.UpdateAsync(room);

                }
            }
            catch (Exception)
            {

            }
        }
    }
}
