namespace MakeMuTrip.DataAccess.DTo
{
    public class FlightBookingDTO : ViewModelBase
    {
        public int PassengerNameRecord { get; set; }
        public TimeSpan? BookingTimeStamp { get; set; }

        public int FlightScheduleRefId { get; set; }
        public int CustomerContactMobile { get; set; }
        public string CustomerContactEmail { get; set; } = null!;
        public DateTime DepartureDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public string FlightCode { get; set; } = null!;
        public string Fromairport { get; set; } = null!;
        public string Toairport { get; set; } = null!;
        public string FromAirportCode { get; set; } = null!;
        public string toAirportCode { get; set; } = null!;
        public Guid AccountRefID { get; set; }   
        public ICollection<CustomerinformationDTO> FlightCustomerDetails { get; set; }
    }


    public class FlightBookingInputDTO : ViewModelBase
    {
        public int PassengerNameRecord { get; set; }
        public TimeSpan? BookingTimeStamp { get; set; }

        public int FlightScheduleRefId { get; set; }
        public int CustomerContactMobile { get; set; }
        public string CustomerContactEmail { get; set; } = null!;
        public Guid AccountRefID { get; set; }
        public ICollection<CustomerinformationDTO> FlightCustomerDetails { get; set; }
    }

    public class BookingFlightDTO : ViewModelBase
    {
        public int PassengerNameRecord { get; set; }
        public int FlightScheduleRefId { get; set; }
        public int CustomerContactMobile { get; set; }
        public string CustomerContactEmail { get; set; } = null!;
       public DateTime DepartureDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public string FlightCode { get; set; } = null!;
        public string Fromairport { get; set; } = null!;
        public string Toairport { get; set; } = null!;
        public string FromAirportCode { get; set; } = null!;
        public string toAirportCode { get; set; } = null!;


    }
    public class CustomerinformationDTO : ViewModelBase
    {
        public string PassengerName { get; set; }
        public int flightBookingRefID { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }

    }
}
