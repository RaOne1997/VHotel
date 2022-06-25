using VHotel.DataAccess.Model;

namespace VHotel.DataAccess
{
    public interface IRoomServices
    {
        Task<List<Room>> GetTaskAsync();
    }
}