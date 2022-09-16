using MakeMuTrip.DataAccess.DTo;

namespace MakeMuTrip.Services.Interface
{
    public interface IRoomServices
    {
        public Task<List<RoomDTO>> GetAllAsync();

        public Task<RoomDTO?> GetByIdAsync(int id);
        public Task CreateAsync(RoomDTO roomDTO);
        public Task UpdateAsync(RoomDTO roomDTO);
        public Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
