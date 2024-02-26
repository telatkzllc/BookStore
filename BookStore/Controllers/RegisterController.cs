using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
	public class RegisterController : Controller
	{
		UserManager um = new UserManager(new EfUserRepository());
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(User user)
		{
			um.UserAdd(user);
			return RedirectToAction("Index","About");
		}
	}
}
