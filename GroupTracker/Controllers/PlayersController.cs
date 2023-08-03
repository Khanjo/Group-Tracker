using Microsoft.AspNetCore.Mvc;
using GroupTracker.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GroupTracker.Controllers
{
    public class PlayersController : Controller
    {
        private readonly GroupTrackerContext _db;

        public PlayersController(GroupTrackerContext db)
        {
            _db = db;
        }

        public ActionResult Create()
        {
            ViewBag.PageTitle = "Add Player";
            return View();
        }

        [HttpPost]
        public ActionResult Create(Player player)
        {
            _db.Players.Add(player);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Details(int id)
        {
            Player thisPlayer = _db.Players.Include(player => player.JoinEntities).ThenInclude(join => join.Player).FirstOrDefault(player => player.PlayerId == id);
            ViewBag.PageTitle = "Player Details";
            return View(thisPlayer);
        }
    }
}