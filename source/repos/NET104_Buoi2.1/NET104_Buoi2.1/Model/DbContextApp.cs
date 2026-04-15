using Microsoft.EntityFrameworkCore;

namespace NET104_Buoi2._1.Model
{
    public class DbContextApp : DbContext
    {
        public DbContextApp(DbContextOptions options) : base(options)
        {
        }

        public DbContextApp()
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=MHDAYY;Initial Catalog=DemoSlide2;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Student> Students { get; set; }
       
    }
}
