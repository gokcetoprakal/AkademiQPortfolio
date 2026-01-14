using AkademiQPortfolio.Data;
using AkademiQPortfolio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQPortfolio.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult SendMessage(
            [Bind("SenderName,SenderEmail,MessageSubject,MessageText")] Message model)
        {
            // Sadece formdan gelen alanlar bind edilir
            // MessageId kesinlikle gelmez

            model.SendDate = DateTime.Now;
            model.IsRead = false;

            _context.Messages.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index", "Default");
        }
    }
}
