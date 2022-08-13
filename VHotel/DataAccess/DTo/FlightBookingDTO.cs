﻿namespace VHotel.DataAccess.DTo
{
    public class FlightBookingDTO : ViewModelBase
    {
        public int PassengerNameRecord { get; set; }
        public TimeSpan? BookingTimeStamp { get; set; }

        public int FlightScheduleRefId { get; set; }
        public int CustomerContactMobile { get; set; }
        public string CustomerContactEmail { get; set; } = null!;

        public ICollection<CustomerinformationDTO> FlightCustomerDetails { get; set; }
    }
    public class CustomerinformationDTO : ViewModelBase
    {
        public string PassengerName { get; set; }
        public int flightBookingRefID { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }

    }
}
