using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize(Roles = "Admin")]

    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
