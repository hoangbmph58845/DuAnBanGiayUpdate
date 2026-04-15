using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BaiTapLab_2.Models
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
               "Server=MHDAYY;Initial Catalog=BaiTaplab2;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>()
                .HasMany(s => s.MonHocs)
                .WithMany(m => m.Students)
                .UsingEntity(j =>
                {
                    j.ToTable("DangKyMonHoc");
                });
            // HasMany().WithMany() nên EF Core sẽ tự tạo bảng trung gian

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lop> Lops { get; set; }
        public DbSet<MonHoc> MonHocs { get; set; }
    }
 }


