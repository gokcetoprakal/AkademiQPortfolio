using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace AkademiQPortfolio.ViewComponents
{
    public class _DefaultContactsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
