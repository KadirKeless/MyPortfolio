using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents.LoginViewComponents
{
    public class _LoginBodyComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
