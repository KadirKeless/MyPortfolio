using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents.LoginViewComponents
{
    public class _LoginScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
