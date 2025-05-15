using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Agri_Energy.Models;

namespace Agri_Energy
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite("Data Source=AgriEnergy.db");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
