using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.CodeAnalysis.Scripting;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;


namespace MyPortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        MyPortfolioContext _context = new MyPortfolioContext();

        [HttpGet]
        public IActionResult Profile(int id)
        {
            // Admin bilgilerini çekip view'e gönderir.
            var admin = _context.Admins.FirstOrDefault();
            ViewBag.UnreadMessagesCount = _context.Messages.Where(x => x.IsRead == false).Count();
            ViewBag.IncompleteTasksCount = _context.ToDoLists.Where(x => x.Status == false).Count();
            if (admin == null)
            {
                return NotFound("Admin bilgisi bulunamadı.");
            }
            return View(admin);
        }

        [HttpPost]
        public IActionResult UpdateProfile(Admin updatedAdmin)
        {
            var admin = _context.Admins.FirstOrDefault(); // Güncellenen admin bilgisini alın
            if (admin != null)
            {
                admin.AdminNameSurname = updatedAdmin.AdminNameSurname;
                admin.AdminMail = updatedAdmin.AdminMail;
                admin.AdminPassword = updatedAdmin.AdminPassword;

                _context.SaveChanges(); // Değişiklikleri kaydet
            }

            return RedirectToAction("Profile"); // Profil sayfasına dön
        }


    }
}