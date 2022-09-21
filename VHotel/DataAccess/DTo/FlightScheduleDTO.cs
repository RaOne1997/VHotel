using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace MakeMuTrip.DataAccess.DTo
{
    public class FlightScheduleDTO : ViewModelBase
    {
        public int FlightRefId { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public string? FlightName { get; set; }
        public byte[]? Flightlogo { get; set; }
        [Column(TypeName = "Money")]
        public decimal price { get; set; }
    }
}
