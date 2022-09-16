namespace MakeMuTrip.DataAccess.DTo
{
    public class FlightDTO : ViewModelBase
    {

        public string FlightCode { get; set; } = null!;
        public int AirlineRefId { get; set; }

        public int FromAirportRefId { get; set; }
 
 
        public int ToAirportRefId { get; set; }
     
      
    }
}
