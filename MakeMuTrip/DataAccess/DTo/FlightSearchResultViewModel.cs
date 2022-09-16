using MakeMuTrip.DataAccess.DTo;

namespace MakeMuTrip.DataAccess.DTo
{
    public class FlightSearchResultViewModel
    {

        public List<FlightScheduleDTO> Flights { get; set; }
        public List<FlightScheduleDTO> Retuen { get; set; }
    }
}
