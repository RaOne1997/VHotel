using VHotel.DataAccess.DTo;

namespace VHotel.Services.Interface
{
    public interface ICityServices
    {
        public Task<List<CityMasterdto>> GetAllAsync();

        public Task<CityMasterdto?> GetByIdAsync(int id);
        public Task CreateAsync(CityMasterdto modelDTO);
        public Task UpdateAsync(CityMasterdto modelDTO);
        public Task DeleteAsync(int id);
        Task<bool> Exists(int id);
        Task<List<DropDownViewModel>> GetDepartmentsForDropDownAsync(int contid);
    }
}
