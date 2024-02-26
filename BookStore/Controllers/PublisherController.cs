using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class PublisherController : Controller
    {
        PublisherManager pm = new PublisherManager(new EfPublisherRepository());
        public IActionResult Index()
        {
            var values = pm.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                pm.PublisherAdd(publisher);
                return RedirectToAction("Index");
            }
            return View(publisher);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var publisher = pm.GetById(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }
        [HttpPost]
        public IActionResult Update(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                pm.PublisherUpdate(publisher);
                return RedirectToAction("Index");
            }
            return View(publisher);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            // İlgili kitabı veritabanından bul
            var publisher = pm.GetById(id);
            if (publisher == null)
            {
                return NotFound();
            }

            // Kitabı sil
            pm.PublisherRemove(publisher);

            // Silme işlemi başarılı oldu, Index sayfasına yönlendir
            return RedirectToAction("Index");
        }
    }
}
