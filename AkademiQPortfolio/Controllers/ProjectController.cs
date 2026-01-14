using AkademiQPortfolio.Data;
using AkademiQPortfolio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        private readonly AppDbContext _context;

        public ProjectController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var projects = _context.Projects.ToList();

            return View(projects);
        }
        // ➕ ADD (GET)
        public IActionResult Create()
        {
            return View();
        }

        // ➕ ADD (POST)
        [HttpPost]
        public IActionResult Create(Project model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.PublishDate = DateTime.Now;

            _context.Projects.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Project/Edit/5
        public IActionResult Edit(int id)
        {
            var project = _context.Projects.Find(id);
            return View(project); 
        }

        // POST: Project/Edit
        [HttpPost]
        public IActionResult Edit(Project model)
        {
            if (ModelState.IsValid)
            {
                _context.Projects.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            // Veritabanından o id'ye sahip projeyi bul
            var project = _context.Projects.Find(id);

            if (project != null)
            {
                _context.Projects.Remove(project); // Projeyi silme listesine ekle
                _context.SaveChanges();           // Değişiklikleri veritabanına işle
            }

            // Silme işleminden sonra listeye geri dön
            return RedirectToAction("Index");
        }
    }
}
