using HotelBooking.Models.DTO;

namespace HotelBooking.Models.Services
{
    public interface IRoomServices
    {
        Task<List<Room>> GetallAsync();
        Task<Room> GetbyID(int? id);
        Task DeleteAsync(int id);
        Task<bool> CreatAsync(Room room);
    }
}