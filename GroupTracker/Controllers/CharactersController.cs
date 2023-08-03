using Microsoft.AspNetCore.Mvc;
using GroupTracker.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GroupTracker.Controllers
{
    public class CharactersController : Controller
    {
        private readonly GroupTrackerContext _db;

        public CharactersController(GroupTrackerContext db)
        {
            _db = db;
        }

        public ActionResult Create()
        {
            ViewBag.PageTitle = "Create Character";
            ViewBag.PlayerId = new SelectList(_db.Players, "PlayerId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Character character)
        {
            _db.Characters.Add(character);
            _db.SaveChanges();
            return RedirectToAction("Details", "Players", new { id = player.PlayerId })
        }
    }
}