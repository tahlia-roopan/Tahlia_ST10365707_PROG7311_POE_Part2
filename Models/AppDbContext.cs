using Microsoft.EntityFrameworkCore;

namespace Agri_Energy.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
