using AkademiQPortfolio.Data;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQPortfolio.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Dashboard için örnek sayılar (sonradan veritabanından çekeceğiz)
            ViewBag.TotalProjects = _context.Projects.Count();
            ViewBag.TotalSkills = _context.Skills.Count();
            ViewBag.UnreadMessages = _context.Messages.Count(m => (bool)!m.IsRead);
            ViewBag.TotalExperiences = _context.Experiences.Count();

            var recentMessages = _context.Messages
           .OrderByDescending(m => m.SendDate)
           .Take(3)
           .ToList();
            ViewBag.RecentMessages = recentMessages;

            return View();
        }
    }
}
