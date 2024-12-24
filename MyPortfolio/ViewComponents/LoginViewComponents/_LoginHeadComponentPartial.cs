using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents.LoginViewComponents
{
    public class _LoginHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
