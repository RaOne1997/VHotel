using Microsoft.EntityFrameworkCore;
using VHotel.DataAccess.Model;

namespace VHotel.DataAccess
{
    public class VhotelsSQLContex : DbContext
    {

        

        public DbSet<Country> countries { get; set; } = null!;
        public DbSet<Hotel>hotels{get;set;}=null!;
        public DbSet<Room> rooms{get;set;}=null!;
        public DbSet<State> states{get;set;}=null!;
        public DbSet<Type> types {get;set;}=null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=WAIANGDESK03;Initial Catalog=VhotelSql;User ID=abhi;Password=1234");
            

        }



        //Data Source=WAIANGDESK03;Initial Catalog=VhotelSql;User ID=abhi;Password=1234
    }
}
