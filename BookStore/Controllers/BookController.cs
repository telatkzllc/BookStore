using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        BookManager bm = new BookManager(new EfBookRepository());
        public IActionResult Index()
        {
            var values = bm.GetBookListWithPublisherAndWriter();
            return View(values);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                bm.BookAdd(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var book = bm.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        public IActionResult Update(Book book)
        {
            if (ModelState.IsValid)
            {
                bm.BookUpdate(book);
                return RedirectToAction("Index");
            }

            return View(book);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            // İlgili kitabı veritabanından bul
            var book = bm.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            // Kitabı sil
            bm.BookRemove(book);

            // Silme işlemi başarılı oldu, Index sayfasına yönlendir
            return RedirectToAction("Index");
        }
    }
}
