using staticclassmodel.DataAccess.Model.Masters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace staticclassmodel.DataAccess.Model.TransactionData
{
    [Table(nameof(FlightSchedule), Schema = "TransactionData")]
    public class FlightSchedule :DataModelBase
    {
        
        public int FlightRefId { get; set; }
        [ForeignKey(nameof(FlightRefId))]
        public Flight flight { get; set; } = null!;
        public DateTime DepartureDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
    }

}

