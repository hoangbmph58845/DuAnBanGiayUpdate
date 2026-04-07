using Microsoft.EntityFrameworkCore;

namespace BaiKtraNet104.DB.Model
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
          
            
                optionsBuilder.UseSqlServer("Server=DESKTOP-4Q61549\\SQLEXPRESS03;Initial Catalog=BaiKtraNet104;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
