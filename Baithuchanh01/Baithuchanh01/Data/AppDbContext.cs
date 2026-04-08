using Baithuchanh01.Model;
using Microsoft.EntityFrameworkCore;

namespace Baithuchanh01.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }




        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        
    }
}
