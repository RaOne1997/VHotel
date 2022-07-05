using VHotel.DataAccess.DTo;

namespace VHotel.Services
{
    public interface ICityServices
    {
        public Task<List<CityMasterdto>> GetAllAsync();

        public Task<CityMasterdto?> GetByIdAsync(int id);
        public Task CreateAsync(CityMasterdto cityMasterdto);
        public Task UpdateAsync(CityMasterdto cityMasterdto);
        public Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
