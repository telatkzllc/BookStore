using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
	public class WriterController : Controller
	{
		WriterManager wm = new WriterManager(new EfWriterRepository());
		public IActionResult Index()
		{
			var values = wm.GetList();
			return View(values);
		}
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Writer writer)
        {
            if (ModelState.IsValid)
            {
                wm.WriterAdd(writer);
                return RedirectToAction("Index");
            }
            return View(writer);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var writer = wm.GetById(id);
            if (writer == null)
            {
                return NotFound();
            }
            return View(writer);
        }
        [HttpPost]
        public IActionResult Update(Writer writer)
        {
            if (ModelState.IsValid)
            {
                wm.WriterUpdate(writer);
                return RedirectToAction("Index");
            }
            return View(writer);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            // İlgili kitabı veritabanından bul
            var writer = wm.GetById(id);
            if (writer == null)
            {
                return NotFound();
            }

            // Kitabı sil
            wm.WriterRemove(writer);

            // Silme işlemi başarılı oldu, Index sayfasına yönlendir
            return RedirectToAction("Index");
        }
    }
}
