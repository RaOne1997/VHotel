namespace MakeMuTrip.DataAccess.DTo
{
    public class HotelAmenitiesLinkDTO : ViewModelBase
    {
        public int HotelRefId { get; set; }
        public string? HotelName { get; set; }
           
        public int AmenitiesRefId { get; set; }
        public string? AmenitiesName { get; set; }

   

    }
}
