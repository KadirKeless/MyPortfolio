using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Models
{
	public class NavBarCombinedViewModel
	{
		public List<Message> Messages { get; set; } = new List<Message>();
		public List<ToDoList> ToDoLists { get; set; } = new List<ToDoList>();
	}
}
