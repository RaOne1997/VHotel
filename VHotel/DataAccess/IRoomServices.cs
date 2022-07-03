using staticclassmodel.DataAccess.Model.Master;

namespace VHotel.DataAccess
{
    public interface IRoomServices
    {
        Task<List<Room>> GetTaskAsync();
    }
}