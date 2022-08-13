using staticclassmodel.DataAccess.Model.Master;
using System.ComponentModel.DataAnnotations.Schema;
using VHotel.DataAccess.Model.TransactionData;

namespace staticclassmodel.DataAccess.Model.TransactionData
{
    [Table(nameof(FlightBooking), Schema = "TransactionData")]
    public class FlightBooking : DataModelBase
    {

        public int? PassengerNameRecord { get; set; }
        public TimeSpan BookingTimeStamp { get; set; }

        public int FlightScheduleRefId { get; set; }
        [ForeignKey(nameof(FlightScheduleRefId))]
        public FlightSchedule flightSchedule { get; set; } = null!;

        public int CustomerContactMobile { get; set; }
        public string CustomerContactEmail { get; set; } = null!;
       public ICollection<Customerinformation> FlightCustomerDetails { get; set; }

    }

}

