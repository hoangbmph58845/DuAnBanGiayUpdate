using Microsoft.EntityFrameworkCore;

namespace Net4_b2._2.Model
{
    public class DbContextApp : DbContext  
    {
        public DbContextApp()
        {
        }

        public DbContextApp(DbContextOptions<DbContextApp> options) : base(options)
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=MHDAYY;Initial Catalog=DemoSlide1;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

   
        public DbSet<Student> Students { get; set; }  
    }
}
