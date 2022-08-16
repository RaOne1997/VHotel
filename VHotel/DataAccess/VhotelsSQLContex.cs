using Microsoft.EntityFrameworkCore;
using staticclassmodel.DataAccess.Model.Master;
using staticclassmodel.DataAccess.Model.TransactionData;
using VHotel.DataAccess.DTo;
using VHotel.DataAccess.Model.Master;
using VHotel.DataAccess.Model.TransactionData;

namespace VHotel.DataAccess
{
    public class VhotelsSQLContex : DbContext
    {

        public VhotelsSQLContex()
        {
        }

        public DbSet<Account> accounts { get; set; } = null!;
        public DbSet<Country> countries { get; set; } = null!;
        public DbSet<Customerinformation> CustomerInformation { get; set; } = null!;
        public DbSet<Hotel> hotels { get; set; } = null!;
        public DbSet<Room> rooms { get; set; } = null!;
        public DbSet<State> states { get; set; } = null!;
        public DbSet<Type> types { get; set; } = null!;
        public DbSet<CityMaster> cityMasters { get; set; } = null!;
        public DbSet<Airport> airports { get; set; } = null!;
        public DbSet<Customer> customers { get; set; } = null!;
        public DbSet<AirlineDetails> airlineDetails { get; set; } = null!;
        public DbSet<Amenities> amenities { get; set; } = null!;
        public DbSet<Flight>  Flights { get; set; } = null!;
        public DbSet<HotelAmenitiesLink> hotelAmenitiesLink { get; set; } = null!;

        public DbSet<FlightBooking> flightBookings { get; set; } = null!;
        public DbSet<FlightCustomerDetail> flightCustomerDetails { get; set; } = null!;
        public DbSet<FlightSchedule> flightSchedules { get; set; } = null!;
        public DbSet<HotelBooking> hotelBookings { get; set; } = null!;
        public DbSet<HotelCustomerDetail> hotelCustomerDetails { get; set; } = null!;
        public VhotelsSQLContex(DbContextOptions<VhotelsSQLContex> options)
            : base(options)
        {
        }
       
    
      
    }
}
