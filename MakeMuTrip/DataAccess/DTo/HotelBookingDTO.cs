namespace MakeMuTrip.DataAccess.DTo
{
    public class HotelBookingDTO:ViewModelBase
    {
        public int HotelRefId { get; set; }

        public int ConfirmationCode { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
