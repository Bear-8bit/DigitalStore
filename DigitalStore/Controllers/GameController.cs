using DigitalStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalStore.Controllers
{
    public class GameController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Game
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Partail_ItemsByGenreID()
        {
            var items = db.Games.Where(x => x.IsActive && x.IsHome).Take(12).ToList();
            return PartialView(items);
        }

        public ActionResult Partical_GameSale()
        {
            var items = db.Games.Where(x => x.IsHome && x.IsActive && x.IsSale).Take(12).ToList();
            return PartialView(items);
        }
    }
}