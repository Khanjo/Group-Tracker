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

        public ActionResult AddPlayer(int id)
        {
            Campaign thisCampaign = _db.Campaigns.FirstOrDefault(campaign => campaign.CampaignId == id);
            ViewBag.PlayerId = new SelectList(_db.Players, "PlayerId", "Name");
            return View(thisCampaign);
        }

        [HttpPost]
        public ActionResult AddPlayer(Campaign campaign, int playerId)
        {
#nullable enable
            CampaignPlayer? joinEntity = _db.CampaignPlayers.FirstOrDefault(join => (join.PlayerId == playerId && join.CampaignId == campaign.CampaignId));
#nullable disable
            if (joinEntity == null && playerId != 0)
            {
                _db.CampaignPlayers.Add(new CampaignPlayer() { PlayerId = playerId, CampaignId = campaign.CampaignId });
                _db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = campaign.CampaignId });
        }

        public ActionResult Details(int id)
        {
            Campaign thisCampaign = _db.Campaigns.Include(campaign => campaign.JoinEntities).ThenInclude(join => join.Player).FirstOrDefault(campaign => campaign.CampaignId == id);
            ViewBag.PageTitle = "Campaign Details";
            return View(thisCampaign);
        }

        public ActionResult Edit(int id)
        {
            Campaign thisCampaign = _db.Campaigns.FirstOrDefault(campaign => campaign.CampaignId == id);
            ViewBag.PageTitle = "Edit Campaign";
            return View(thisCampaign);
        }

        [HttpPost]
        public ActionResult Edit(Campaign campaign)
        {
            _db.Campaigns.Update(campaign);
            _db.SaveChanges();
            return RedirectToAction("Details", new { id = campaign.CampaignId });
        }

        public ActionResult Delete(int id)
        {
            Campaign thisCampaign = _db.Campaigns.FirstOrDefault(campaign => campaign.CampaignId == id);
            ViewBag.PageTitle = "Delete Campaign";
            return View(thisCampaign);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Campaign thisCampaign = _db.Campaigns.FirstOrDefault(campaign => campaign.CampaignId == id);
            _db.Campaigns.Remove(thisCampaign);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult DeleteJoin(int joinId)
        {
            CampaignPlayer joinEntry = _db.CampaignPlayers.FirstOrDefault(entry => entry.CampaignPlayerId == joinId);
            _db.CampaignPlayers.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}