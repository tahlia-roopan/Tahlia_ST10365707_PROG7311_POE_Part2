using Microsoft.AspNetCore.Mvc;
using Agri_Energy.Models;
using System.Linq;

namespace Agri_Energy.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            if (model.UserType == "Farmer")
            {
                var farmer = _context.Farmers.FirstOrDefault(f => f.FirstName == model.FirstName && f.Password == model.Password);
                if (farmer != null)
                {
                    HttpContext.Session.SetInt32("FarmerId", farmer.FarmerId);
                    HttpContext.Session.SetString("UserType", "Farmer");
                    return RedirectToAction("Dashboard", "Farmer");
                }
            }
            else if (model.UserType == "Employee")
            {
                var employee = _context.Employees.FirstOrDefault(e => e.FirstName == model.FirstName && e.Password == model.Password);
                if (employee != null)
                {
                    HttpContext.Session.SetInt32("EmployeeId", employee.EmployeeId);
                    HttpContext.Session.SetString("UserType", "Employee");
                    return RedirectToAction("Dashboard", "Employee");
                }
            }

            ModelState.AddModelError("", "Invalid login credentials");
            return View("Index", model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}