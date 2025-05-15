using Agri_Energy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Agri_Energy.Controllers
{
    public class FarmerController : Controller
    {
        private readonly AppDbContext _context;

        public FarmerController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            var farmerId = HttpContext.Session.GetInt32("FarmerId");
            var products = _context.Products
                .Where(p => p.FarmerId == farmerId)
                .ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            product.FarmerId = (int)HttpContext.Session.GetInt32("FarmerId");
            product.ProductionDate = DateTime.Now;

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}