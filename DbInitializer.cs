using Agri_Energy.Models;

namespace Agri_Energy
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Farmers.Any())
            {
                context.Farmers.AddRange(
                    new Farmer { FarmerId = 1, FirstName = "John", LastName = "Doe", Password = "1234", ContactNumber = "1234567890", Email = "john@farm.com" },
                    new Farmer { FarmerId = 2, FirstName = "Jane", LastName = "Smith", Password = "1234", ContactNumber = "0987654321", Email = "jane@farm.com" }
                );
                context.SaveChanges();
            }

            if (!context.Employees.Any())
            {
                context.Employees.AddRange(
                    new Employee { EmployeeId = 1, FirstName = "Admin", LastName = "User", Password = "admin", Email = "admin@agri.com" }
                );
                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { Name = "Organic Tomatoes", Category = "Vegetables", ProductionDate = DateTime.Now.AddDays(-10), FarmerId = 1 },
                    new Product { Name = "Free Range Eggs", Category = "Poultry", ProductionDate = DateTime.Now.AddDays(-5), FarmerId = 1 },
                    new Product { Name = "Grass-fed Beef", Category = "Livestock", ProductionDate = DateTime.Now.AddDays(-20), FarmerId = 2 }
                );
                context.SaveChanges();
            }
        }
    }
}
