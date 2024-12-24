using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.ViewComponents.LayoutViewComponents
{
    public class _LayoutSidebarComponentPartial : ViewComponent
    {
        MyPortfolioContext _context = new MyPortfolioContext();
		public IViewComponentResult Invoke()
		{
			ViewBag.UnreadMessagesCount = _context.Messages.Where(x => x.IsRead == false).Count();
			ViewBag.IncompleteTasksCount = _context.ToDoLists.Where(x => x.Status == false).Count();
			return View();
		}
	}
}
