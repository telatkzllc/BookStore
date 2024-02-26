using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
