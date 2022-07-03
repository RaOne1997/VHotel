using Microsoft.EntityFrameworkCore;
using staticclassmodel.DataAccess.Model.Master;

namespace VHotel.DataAccess
{
    public class VhotelsSQLContex : DbContext
    {

        public VhotelsSQLContex()
        {
        }

        public DbSet<Country> countries { get; set; } = null!;
        public DbSet<Hotel>hotels{get;set;}=null!;
        public DbSet<Room> rooms{get;set;}=null!;
        public DbSet<State> states{get;set;}=null!;
        public DbSet<Type> types {get;set;}=null!;
        public DbSet<CityMaster> cityMasters {get;set;}=null!;
        public DbSet<Airport> airports {get;set;}=null!;
        public DbSet<Customer> customers {get;set;}=null!;
        public DbSet<AirlineDetails> airlineDetails {get;set;}=null!;
        public DbSet<Amenities>  amenities {get;set;}=null!;
        public DbSet<HotelAmenitiesLink> hotelAmenitiesLink { get;set;}=null!;


        public VhotelsSQLContex(DbContextOptions<VhotelsSQLContex> options)
            : base(options)
        {
        }
    }
}
