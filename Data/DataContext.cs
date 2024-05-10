using Microsoft.EntityFrameworkCore;

namespace indy_microservice.Data
{
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<BotPilot> BotPilots { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tire> Tires { get; set; }
    }
}