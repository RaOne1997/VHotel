namespace VHotel.DataAccess.DTo
{
    public class RoomDTO
    {
        
        public string RoomNumber { get; set; }
        public int RoomTypeRefID { get; set; }


        public IFormFile? RoomImage { get; set; }
        public int RoomLevel { get; set; }

        public decimal RoomPrice { get; set; }
        public string Description { get; set; }
    }
}
