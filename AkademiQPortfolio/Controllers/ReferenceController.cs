using AkademiQPortfolio.Data;
using AkademiQPortfolio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQPortfolio.Controllers
{
    public class ReferenceController : Controller
    {
        private readonly AppDbContext _context;

        public ReferenceController(AppDbContext context)
        {
            _context = context;
        }

        // LIST
        public IActionResult Index()
        {
            var values = _context.References.ToList();
            return View(values);
        }

        // CREATE - GET
        [HttpGet]
        public IActionResult AddReference()
        {
            return View();
        }

        // CREATE - POST
        [HttpPost]
        public IActionResult AddReference(Reference reference)
        {
            // 🔒 ID’ye dokunmuyoruz
            _context.References.Add(reference);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // UPDATE - GET
        [HttpGet]
        public IActionResult UpdateReference(int id)
        {
            var value = _context.References.FirstOrDefault(x => x.Id == id);
            if (value == null)
                return NotFound();

            return View(value);
        }

        // UPDATE - POST
        [HttpPost]
        [HttpPost]
        public IActionResult UpdateReference(Reference reference)
        {
            var value = _context.References.FirstOrDefault(x => x.Id == reference.Id);

            if (value != null)
            {
                value.ReferenceName = reference.ReferenceName;
                value.Description = reference.Description;
                value.Mail = reference.Mail;
                value.Phone = reference.Phone;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reference);
        }

        // DELETE
        public IActionResult DeleteReference(int id)
        {
            var value = _context.References.Find(id);
            if (value != null)
            {
                _context.References.Remove(value);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
