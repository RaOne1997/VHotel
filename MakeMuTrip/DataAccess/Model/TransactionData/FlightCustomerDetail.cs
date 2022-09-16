using staticclassmodel.DataAccess.Model.Masters;
using System.ComponentModel.DataAnnotations.Schema;

namespace staticclassmodel.DataAccess.Model.TransactionData
{
    [Table(nameof(FlightCustomerDetail), Schema = "TransactionData")]
    public class FlightCustomerDetail : DataModelBase
    {
     
        public int FlightBookingRefId { get; set; }
        [ForeignKey(nameof(FlightBookingRefId))]
        public FlightBooking flightBooking { get; set; } = null!;
        public int CustomerRefId { get; set; }
        [ForeignKey(nameof(CustomerRefId))]
        public Customer customer { get; set; } = null!;
    }

}

