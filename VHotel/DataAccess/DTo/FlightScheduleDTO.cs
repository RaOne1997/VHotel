namespace VHotel.DataAccess.DTo
{
    public class FlightScheduleDTO : ViewModelBase
    {
        public int FlightRefId { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public string? FlightName { get; set; }
        public byte[]? Flightlogo { get; set; }
    }
}
