using VHotel.DataAccess.DTo;

namespace VHotel.Services
{
    public interface IFlightBookingServices
    {
        Task CreateAsync(FlightBookingInputDTO modelDTO);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
        Task<List<FlightBookingDTO>> GetAllAsync();
        Task<FlightBookingDTO> GetByIdAsync(int id);
        Task<List<FlightBookingDTO>> GetByIdShedulID(int id);
        Task UpdateAsync(FlightBookingInputDTO modelDTO);
    }
}