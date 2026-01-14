using AkademiQPortfolio.Data;
using AkademiQPortfolio.Entities;
using AkademiQPortfolio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq; // MUTLAKA OLMALI

namespace AkademiQPortfolio.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // LINQ hatası almamak için yukarıya using System.Linq ekledik
            var value = _context.Abouts.FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public IActionResult Index(About about)
        {
            // Güncelleme mantığı...
            _context.Abouts.Update(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}