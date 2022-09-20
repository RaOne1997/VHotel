using staticclassmodel.DataAccess.Model.Masters;
using System.ComponentModel.DataAnnotations.Schema;

using Vhotel.DataAccess.Model.TransactionData;
using Vhotel.DataAccess.Model.Master;
using VHotel.DataAccess.Model.Master;

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
        public string  AccountRefID { get; set; }
        [ForeignKey(nameof(AccountRefID))]
        public User Accounts { get; set; }
        public ICollection<Customerinformation> FlightCustomerDetails { get; set; }

    }

}

