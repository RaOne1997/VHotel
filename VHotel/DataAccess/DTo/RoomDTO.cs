

namespace VHotel.DataAccess.DTo
{
    public class RoomDTO: ViewModelBase
    {
       
        public string RoomNumber { get; set; } = null!;
        public int RoomTypeRefID { get; set; }


        public IFormFile? RoomImagesUplode { get; set; }
        public byte[]? RoomImage { get; set; }
        public int RoomLevel { get; set; }

        public decimal RoomPrice { get; set; }
        public string Description { get; set; } = null!;
    }
}
