using Microsoft.AspNetCore.Mvc;

namespace BookStore.Models
{
    public class BookList: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
           return View();
        }

    }
}
