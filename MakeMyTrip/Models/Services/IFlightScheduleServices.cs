using MakeMyTrip.VIewModel.dataviewModel;

namespace MakeMyTrip.Models.Services
{
    public interface IFlightScheduleServices
    {
        Task<bool> CreatAsync(FlightScheduleDTO RoomDTO);
        Task DeleteAsync(int id);
        Task<List<FlightScheduleDTO>> GetallAsync();
        Task<FlightScheduleDTO> GetbyID(int? id);
        Task<bool> UpdateFlightbook(FlightScheduleDTO FlightScheduleDTO);
        Task<FlightSearchResultViewModel> SearchFlight(string locationFrom, string locationTo, DateTime date,DateTime? returndatre);
    }
}