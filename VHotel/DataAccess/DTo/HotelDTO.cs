namespace VHotel.DataAccess.DTo
{
    public class HotelDTO : ViewModelBase
    {

        public string Name { get; set; } = null!;
        public int HotelId { get; set; }
        public byte[]? HotelImage { get; set; }
        public int HotelRating { get; set; }
        public DateTime checkout { get; set; }
        public DateTime checkin { get; set; }
        public int GaustNo { get; set; }
        public int RoomtypeRef { get; set; }
        public string Address { get; set; } = null!;
        public int CountryRefID { get; set; }
        public string Landmark { get; set; } = null!;
        public int Pincode { get; set; }
        public string City { get; set; } = null!;
    }
}
