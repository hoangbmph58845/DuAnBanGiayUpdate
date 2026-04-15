using DemoSlide01._1.Model;
using Microsoft.EntityFrameworkCore;

namespace Net4_b2._2.Model
{
    public class DbContextApp : DbContext
    {
        public DbContextApp(DbContextOptions options) : base(options)
        {
        }

        protected DbContextApp()
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
