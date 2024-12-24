using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortolioUdemy.Controllers
{
    [Authorize(Roles = "Admin")]

    public class MessageController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult Inbox()
        {
            var values = context.Messages.ToList();
            return View(values);
        }
        public IActionResult ChangeIsReadToTrue(int id)
        {
            var value = context.Messages.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public IActionResult ChangeIsReadToFalse(int id)
        {
            var value = context.Messages.Find(id);
            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public IActionResult DeleteMessage(int id)
        {
            var value = context.Messages.Find(id);
            context.Messages.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
        public IActionResult MessageDetail(int id)
        {
            var value = context.Messages.Find(id);
            return View(value);
        }
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult SendMessage(Message message)
		{
			if (!ModelState.IsValid)
			{
				TempData["Error"] = "Form verileri geçersiz. Lütfen tüm alanları doğru doldurun.";
                return Redirect("https://localhost:7066/Default/Index#contact");
            }

			var newMessage = new Message
			{
				NameSurname = message.NameSurname,
				Email = message.Email,
				Subject = message.Subject,
				MessageDetail = message.MessageDetail,
				SendDate = DateTime.Now,
				IsRead = false
			};

			context.Messages.Add(newMessage);
			context.SaveChanges();

			TempData["Success"] = "Mesajınız başarıyla gönderildi!";
            return Redirect("https://localhost:7066/Default/Index#contact");
        }
	}
}