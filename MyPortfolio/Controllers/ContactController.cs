using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
    [Authorize(Roles = "Admin")]

    public class ContactController : Controller
    {
        MyPortfolioContext _context = new MyPortfolioContext();
        public IActionResult ContactList()
        {
            var values = _context.Contacts.ToList();
            return View(values);
        }
		[HttpGet]
		public IActionResult CreateContact()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateContact(Contact contact)
		{
			_context.Contacts.Add(contact);
			_context.SaveChanges();
			return RedirectToAction("ContactList");
		}

		public IActionResult DeleteContact(int id)
		{
			var value = _context.Contacts.Find(id);
			_context.Contacts.Remove(value);
			_context.SaveChanges();
			return RedirectToAction("ContactList");
		}
		[HttpGet]
        public IActionResult UpdateContact(int id)
        {
            var value = _context.Contacts.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateContact(Contact contact)
        {
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return RedirectToAction("ContactList");
        }
    }
}
