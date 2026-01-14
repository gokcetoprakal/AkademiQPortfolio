using AkademiQPortfolio.Data;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQPortfolio.ViewComponents
{
    public class _SidebarMessageCountViewComponentPartial : ViewComponent
    {
        private readonly AppDbContext _context;

        public _SidebarMessageCountViewComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var unreadCount = _context.Messages.Count(x => x.IsRead == false);
            return View(unreadCount); // Sayıyı View'a gönderiyoruz
        }
    }
}
