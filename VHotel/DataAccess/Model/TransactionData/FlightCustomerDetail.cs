using MakeMuTrip.DataAccess.Model.TransactionData;
using staticclassmodel.DataAccess.Model.Masters;
using System.ComponentModel.DataAnnotations.Schema;
using Vhotel.DataAccess.Model.TransactionData;

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
        public Customerinformation customer { get; set; } = null!;
    }

}

