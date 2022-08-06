

namespace MakeMyTrip.VIewModel.dataviewModel
{
    public class FlightScheduleDTO : ViewModelBase
    {
        public int FlightRefId { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string? FlightName { get; set; }
        public byte[]? Flightlogo { get; set; }
    }
    public class FlightSearchResultViewModel
    {

        public List<FlightScheduleDTO> Flights { get; set; }
        public List<FlightScheduleDTO> Retuen { get; set; }
}
}

