using AkademiQPortfolio.Data;
using AkademiQPortfolio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQPortfolio.Controllers
{
    public class EducationController : Controller
    {
        private readonly AppDbContext _context;

        public EducationController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Educations.ToList();
            return View(values);
        }
        // Sayfayı boş bir formla açar
        [HttpGet]
        public IActionResult AddEducation()
        {
            return View();
        }

        // Form gönderildiğinde veriyi kaydeder
        [HttpPost]
        public IActionResult AddEducation(Education education)
        {
            if (ModelState.IsValid)
            {
                _context.Educations.Add(education);
                _context.SaveChanges();
                return RedirectToAction("Index"); // Listeleme sayfasına geri döner
            }
            return View(education); // Hata varsa verileri silmeden formu tekrar açar
        }

        [HttpPost] // AJAX isteği için POST daha güvenlidir
        public IActionResult DeleteEducation(int id)
        {
            var value = _context.Educations.Find(id);
            if (value != null)
            {
                _context.Educations.Remove(value);
                _context.SaveChanges();
                return Json(new { success = true }); // Başarılı mesajı dön
            }
            return Json(new { success = false });
        }

        [HttpGet]
        [Route("Education/UpdateEducation/{id}")] // Bu satırı ekle!
        public IActionResult UpdateEducation(int id)
        {
            var value = _context.Educations.Find(id);
            if (value == null) return NotFound();
            return View(value);
        }
        // Güncellenmiş veriyi kaydeder
        [HttpPost]
        public IActionResult UpdateEducation(Education education)
        {
            if (ModelState.IsValid)
            {
                _context.Educations.Update(education);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(education);
        }
    }
}
