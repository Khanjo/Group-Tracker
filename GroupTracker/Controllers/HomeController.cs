using Microsoft.AspNetCore.Mvc;
using GroupTracker.Models;
using System.Linq;
using System.Collections.Generic;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly GroupTrackerContext _db;

        public HomeController(GroupTrackerContext db)
        {
            _db = db;
        }

        [HttpGet("/")]
        public ActionResult Index()
        {
            Campaign[] campaigns = _db.Campaigns.ToArray();
            Player[] players = _db.Players.ToArray();
            Dictionary<string, object[]> model = new Dictionary<string, object[]>();
            model.Add("campaigns", campaigns);
            model.Add("players", players);
            ViewBag.PageTitle = "Group Tracker";
            return View(model);
        }

    }
}