using staticclassmodel.DataAccess.Model.Master;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace staticclassmodel.DataAccess.Model.TransactionData
{
    [Table(nameof(FlightSchedule), Schema = "TransactionData")]
    public class FlightSchedule
    {
        [Key]
        public int Id { get; set; }
        public int FlightRefId { get; set; }
        [ForeignKey(nameof(FlightRefId))]
        public Flight flight { get; set; } = null!;
        public DateTime DepartureDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
    }

}

