using Microsoft.AspNetCore.Mvc;
using GroupTracker.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GroupTracker.Controllers
{
    public class CampaignsController : Controller
    {
        private readonly GroupTrackerContext _db;

        public CampaignsController(GroupTrackerContext db)
        {
            _db = db;
        }

        public ActionResult Create()
        {
            ViewBag.PageTitle = "Add Campaign";
            return View();
        }

        [HttpPost]
        public ActionResult Create(Campaign campaign)
        {
            _db.Campaigns.Add(campaign);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}