namespace MakeMyTrip.VIewModel.dataviewModel
{
    public class FlightBookingDTO : ViewModelBase
    {
        public int PassengerNameRecord { get; set; }
        public TimeSpan BookingTimeStamp { get; set; }
        public int CustomerRefId { get; set; }
        public int FlightScheduleRefId { get; set; }
         public int CustomerContactMobile { get; set; }
        public string CustomerContactEmail { get; set; } = null!;
    }
}
