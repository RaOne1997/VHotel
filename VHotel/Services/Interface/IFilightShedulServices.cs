using VHotel.DataAccess.DTo;

namespace VHotel.Services.Interface
{
    public interface IFilightShedulServices
    {
        public Task<List<FlightScheduleDTO>> GetAllAsync();

        public Task<FlightScheduleDTO?> GetByIdAsync(int id);
        public Task CreateAsync(FlightScheduleDTO modelDTO);
        public Task UpdateAsync(FlightScheduleDTO modelDTO);
        public Task DeleteAsync(int id);
        Task<bool> Exists(int id);
        Task<List<FlightScheduleDTO>> SearchFlight(string locationFrom, string locationTo, DateTime date);
    }
}
