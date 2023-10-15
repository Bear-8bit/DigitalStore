using DigitalStore.Models;
using DigitalStore.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace DigitalStore.Areas.Admin.Controllers
{
    public class GameController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Game
        public ActionResult Index(int? page)
        {
            IEnumerable<Game> items = db.Games.OrderByDescending(x => x.Id);
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        public ActionResult Add()
        {
            ViewBag.GameGenre = new SelectList(db.GameGenres.ToList(), "Id", "Name");
            return View();
        }
    }
}