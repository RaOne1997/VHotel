using System.ComponentModel.DataAnnotations.Schema;

namespace staticclassmodel.DataAccess.Model.Masters
{
    [Table("Flight")]
    public class Flight: DataModelBase
    {
      
        public string FlightCode { get; set; } = null!;
        public int AirlineRefId { get; set; }
        [ForeignKey(nameof(AirlineRefId))]
        public  AirlineDetails airlineDetails { get; set; } = null!;
        public int FromAirportRefId { get; set; }
        [ForeignKey(nameof(FromAirportRefId))]
           public Airport airportFrom { get; set; }= null!;
        public int ToAirportRefId { get; set; }
        [ForeignKey(nameof(ToAirportRefId))]
        public Airport airportToAirport { get; set; }= null!;
        

    }
}
