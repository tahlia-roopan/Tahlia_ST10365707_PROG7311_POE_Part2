using Agri_Energy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agri_Energy.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddFarmer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFarmer(Farmer farmer)
        {
            if (ModelState.IsValid)
            {
                _context.Farmers.Add(farmer);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View(farmer);
        }

        public IActionResult ViewProducts(string categoryFilter, int? yearFilter, int? monthFilter)
        {
            IQueryable<Product> productsQuery = _context.Products.Include(p => p.Farmer);

            if (!string.IsNullOrWhiteSpace(categoryFilter))
            {
                productsQuery = productsQuery.Where(p => p.Category.ToLower().Contains(categoryFilter.Trim().ToLower()));
            }

            if (yearFilter.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.ProductionDate.Year == yearFilter.Value);
            }

            if (monthFilter.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.ProductionDate.Month == monthFilter.Value);
            }

            var products = productsQuery.ToList();
            return View(products);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}