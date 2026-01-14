using Microsoft.AspNetCore.Mvc;

namespace AkademiQPortfolio.ViewComponents
{
    public class _DefaultBlogComponentPartial : ViewComponent
    {
       public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
