using VHotel.DataAccess.DTo;

namespace VHotel.Services.Interface
{
    public interface ICrudeServices<TModelDTO>
    {
        public Task<List<TModelDTO>> GetAllAsync();

        public Task<TModelDTO?> GetByIdAsync(int id);
        public Task CreateAsync(TModelDTO modelDTO);
        public Task UpdateAsync(TModelDTO modelDTO);
        public Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
