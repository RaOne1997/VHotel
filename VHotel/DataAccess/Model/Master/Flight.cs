using System.ComponentModel.DataAnnotations.Schema;

namespace staticclassmodel.DataAccess.Model.Master
{
    [Table("Flight")]
    public class Flight: DataModelBase
    {
      
        public string FlightCode { get; set; } = null!;
        public int AirlineRefId { get; set; }
        [ForeignKey(nameof(AirlineRefId))]
        AirlineDetails airlineDetails { get; set; } = null!;
        public int FromAirportRefId { get; set; }
        [ForeignKey(nameof(AirlineRefId))]
        Airport airportFrom { get; set; }= null!;
        public int ToAirportRefId { get; set; }
        [ForeignKey(nameof(AirlineRefId))]
        Airport airportToAirport { get; set; }= null!;
        

    }
}
