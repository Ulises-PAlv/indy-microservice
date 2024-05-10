using Microsoft.EntityFrameworkCore;

namespace indy_microservice.Data
{
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Characteristic>().HasData(
                new Characteristic { Id = 1, Name = "DRS", Boost = 7 },
                new Characteristic { Id = 2, Name = "Wide Spoiler", Boost = 8 },
                new Characteristic { Id = 3, Name = "IA Suspension", Boost = 6 },
                new Characteristic { Id = 4, Name = "Carbon Fiber Brakes", Boost = 7 }
            );
        }

        public DbSet<BotPilot> BotPilots { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tire> Tires { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
    }
}