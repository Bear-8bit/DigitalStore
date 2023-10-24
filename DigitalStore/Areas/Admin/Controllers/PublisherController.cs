using DigitalStore.Models;
using DigitalStore.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalStore.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PublisherController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Publisher
        public ActionResult Index()
        {
            var item = db.Publishers;
            return View(item);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Publisher model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                db.Publishers.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = db.Publishers.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Publisher model)
        {
            if (ModelState.IsValid)
            {
                db.Publishers.Attach(model);
                model.ModifiedDate = DateTime.Now;
                db.Entry(model).Property(x => x.Name).IsModified = true;
                db.Entry(model).Property(x => x.Description).IsModified = true;
                db.Entry(model).Property(x => x.ModifiedDate).IsModified = true;
                db.Entry(model).Property(x => x.ModifiedBy).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Publishers.Find(id);
            if (item != null)
            {
                db.Publishers.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}