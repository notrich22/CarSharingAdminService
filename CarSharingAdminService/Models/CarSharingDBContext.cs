using Microsoft.EntityFrameworkCore;

namespace CarSharingAdminService.Models
{
    public class CarSharingDBContext : DbContext
    {
        public DbSet<User> Users{ get; set; }
        public DbSet<Ride> Rides{ get; set; }
        public DbSet<Car> Cars{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CarSharingDB;Trusted_Connection=True;");
        }
    }
}
