using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.DAL.Context;
using MyPortfolio.Models;

namespace MyPortolioUdemy.ViewComponents.LayoutViewComponents
{
    public class _LayoutNavbarComponentPartial : ViewComponent
    {
        MyPortfolioContext _context = new MyPortfolioContext();
		public IViewComponentResult Invoke()
		{
			ViewBag.NotReadMessageCount = _context.Messages.Where(x => x.IsRead == false).Count();
			ViewBag.UnmadeToDoListCount = _context.ToDoLists.Where(x => x.Status == false).Count();

			// Son 3 okunmamış mesajı tarihe göre azalan sırayla alıyoruz
			var messages = _context.Messages
				.Where(x => x.IsRead == false)
				.OrderByDescending(x => x.SendDate) // Mesajları tarihe göre azalan sırayla sırala
				.Take(3) // İlk 3 mesajı al
				.ToList();

			// Son 3 okunmamış todolist tarihe göre azalan sırayla alıyoruz
			var todoLists = _context.ToDoLists
				.Where(x => x.Status == false)
				.OrderByDescending(x => x.Date)     // Todolistleri tarihe göre azalan sırayla sırala
				.Take(3)    // İlk 3 todolisti al
				.ToList();

			// ViewModel oluştur
			var viewModel = new NavBarCombinedViewModel
			{
				Messages = messages,
				ToDoLists = todoLists
			};

			return View(viewModel); // ViewModel döndür
		}
	}
}