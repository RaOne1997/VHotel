

namespace HotelBooking.Models.DTO
{


    public class Room
    {
        public int ID { get; set; }
        public string RoomNumber { get; set; } = null!;
        public int RoomTypeRefID { get; set; }

        public byte[]? RoomImage { get; set; }

        public int RoomLevel { get; set; }
        public Type? type { get; set; }
        public decimal RoomPrice { get; set; }
        public string Description { get; set; } = null!;

    }


    public class RoomInsert
    {
        public int ID { get; set; }
        public string RoomNumber { get; set; } = null!;
        public int RoomTypeRefID { get; set; }

  

        public int RoomLevel { get; set; }

        public decimal RoomPrice { get; set; }
        public string Description { get; set; } = null!;

    }
}
