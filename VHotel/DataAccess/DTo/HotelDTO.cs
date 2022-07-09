namespace VHotel.DataAccess.DTo
{
    public class HotelDTO : ViewModelBase
    {

        public string Name { get; set; } = null!;
        public int HotelId { get; set; }
        public IFormFile? HotelUplodeImage { get; set; }
        public byte[]? HotelImage { get; set; }
        public int HotelRating { get; set; }
        public DateTime checkout { get; set; }
        public DateTime checkin { get; set; }
        public int GaustNo { get; set; }
        public int StaterefID { get; set; }
        public int StateName { get; set; }
        public int RoomTypeRefID { get; set; }
        public int RoomType { get; set; }
        public string Address { get; set; } = null!;
        public int CountryRefID { get; set; }
        public string Landmark { get; set; } = null!;
        public int Pincode { get; set; }
        public string City { get; set; } = null!;
    }
}
