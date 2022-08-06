using MakeMyTrip.VIewModel.dataviewModel;
namespace MakeMyTrip.Models.Services
{
    public interface IRoomServices
    {
        Task<List<FlightBookingDTO>> GetallAsync();
        Task<FlightBookingDTO> GetbyID(int? id);
        Task DeleteAsync(int id);
        Task<bool> CreatAsync(FlightBookingDTO flightBookingDTO);

        Task<bool> UpdateFlightbook(FlightBookingDTO flightBookingDTO);

    }
}