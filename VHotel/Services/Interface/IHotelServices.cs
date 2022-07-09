using VHotel.DataAccess.DTo;

namespace VHotel.Services.Interface
{
    public interface IHotelServices
    {
        public Task<List<HotelDTO>> GetAllAsync();

        public Task<HotelDTO?> GetByIdAsync(int id);
        public Task CreateAsync(HotelDTO HotelDTO);
        public Task UpdateAsync(HotelDTO HotelDTO);
        public Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
