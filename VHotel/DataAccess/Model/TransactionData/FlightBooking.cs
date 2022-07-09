using staticclassmodel.DataAccess.Model.Master;
using System.ComponentModel.DataAnnotations.Schema;

namespace staticclassmodel.DataAccess.Model.TransactionData
{
    [Table(nameof(FlightBooking), Schema = "TransactionData")]
    public class FlightBooking : DataModelBase
    {
    
        public int PassengerNameRecord { get; set; }
        public TimeSpan BookingTimeStamp { get; set; }
        public int CustomerRefId { get; set; }
        [ForeignKey(nameof(CustomerRefId))]
        public Customer customer { get; set; } = null!;

        public int FlightScheduleRefId { get; set; }
        [ForeignKey(nameof(FlightScheduleRefId))]
        public FlightSchedule flightSchedule { get; set; } = null!;

        public int CustomerContactMobile { get; set; }
        public string CustomerContactEmail { get; set; } = null!;
        //List<FlightCustomerDetail> FlightCustomerDetails)

    }

}

