using staticclassmodel.DataAccess.Model.Master;
using staticclassmodel.DataAccess.Model.TransactionData;
using System.ComponentModel.DataAnnotations.Schema;

namespace VHotel.DataAccess.Model.TransactionData
{
 
    public class Customerinformation : DataModelBase
    {

        public string PassengerName { get; set; }
        public int flightBookingRefID{ get; set; }
   
        [ForeignKey(nameof(flightBookingRefID))]
        public FlightBooking flightBooking { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
    }

  



}
