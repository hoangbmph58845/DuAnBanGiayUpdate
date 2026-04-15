using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LamDeThiThu2.Models
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
               "Server=MHDAYY;Initial Catalog=LamDeThiThu2;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}

