using VHotel.DataAccess.DTo;

namespace VHotel.Services.Interface
{
    public interface IStateServices
    {
        Task CreateAsync(StateDTO stateDTO);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
        Task<List<StateDTO>> GetAllAsync();
        Task<StateDTO?> GetByIdAsync(int id);
        Task<List<StateDTO>> stateBYcont(int id);
        Task UpdateAsync(StateDTO stateDTO);
    }
}