using Microsoft.EntityFrameworkCore;
using staticclassmodel.DataAccess.Model.Master;

namespace VHotel.DataAccess
{
    public class RoomServices : IRoomServices
    {
        public readonly VhotelsSQLContex _vhotelsSQLContex;
        public RoomServices(VhotelsSQLContex vhotelsSQLContex)
        {
            _vhotelsSQLContex = vhotelsSQLContex;
        }

        public async Task<List<Room>> GetTaskAsync()
        {
        
            return await _vhotelsSQLContex.rooms.Include("type").ToListAsync();
        }



       

    }
}
