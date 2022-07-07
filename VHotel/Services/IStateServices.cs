using VHotel.DataAccess.DTo;

namespace VHotel.Services
{
    public interface IStateServices
    {
        public Task<List<StateDTO>> GetAllAsync();

        public Task<StateDTO?> GetByIdAsync(int id);
        public Task CreateAsync(StateDTO  stateDTO);
        public Task UpdateAsync(StateDTO  stateDTO);
        public Task DeleteAsync(int id);
        public Task<List<StateDTO>> stateBYcont(int id);
        Task<bool> Exists(int id);
    }
}
