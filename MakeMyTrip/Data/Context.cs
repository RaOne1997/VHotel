using Microsoft.EntityFrameworkCore;

namespace MakeMyTrip.Data
{
    public class Context : DbContext
    {
        public DbSet<Books> books { get; set; }
        public DbSet<Categories> categories { get; set; }
        public DbSet<Bookdetals> bookdetals { get; set; }
        public DbSet<Authors> authors { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=WAIANGDESK03;Initial Catalog=BookStore;User ID=abhi;Password=1234");
        }
    }
}
