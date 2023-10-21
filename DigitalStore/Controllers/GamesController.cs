﻿using DigitalStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalStore.Controllers
{
    public class GamesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Game
        public ActionResult Index(int? id)
        {

            var items = db.Games.ToList();
            if (id != null)
            {
                items = items.Where(x => x.GameGenreId == id).ToList();
            }
            return View(items);
        }
        public ActionResult GameGenre(string alias, int? id)
        {
            var items = db.Games.ToList();
            if (id > 0)
            {
                items = items.Where(x => x.GameGenreId == id).ToList();
            }
            var genre = db.GameGenres.Find(id);
            if (genre != null)
            {
                ViewBag.GenreName = genre.Name;
            }
            ViewBag.Genre_ID = id;
            return View(items);
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