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

        public ActionResult AddCampaign(int id)
        {
            Player thisPlayer = _db.Players.FirstOrDefault(player => player.playerId == id);
            ViewBag.CampaignId = new SelectList(_db.Campaigns, "CampaignId", "Title");
            return View(thisPlayer)
        }

        [HttpPost]
        public ActionResult AddCampaign(Player player, int campaignId)
        {
#nullable enable
            CampaignPlayer? joinEntity = _db.CampaignPlayers.FirstOrDefault(join => (join.CampaignId == campaignId && join.PlayerId == player.PlayerId));
#nullable disable
            if (joinEntity == null && campaignId != 0)
            {
                _db.CampaignPlayers.Add(new CampaignPlayer() { CampaignId = campaignId, PlayerId = player.PlayerId });
                _db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = player.PlayerId });
        }
        public ActionResult Details(int id)
        {
            Player thisPlayer = _db.Players.Include(player => player.JoinEntities).ThenInclude(join => join.Player).FirstOrDefault(player => player.PlayerId == id);
            ViewBag.PageTitle = "Player Details";
            return View(thisPlayer);
        }

        public ActionResult Edit(int id)
        {
            Player thisPlayer = _db.Players.FirstOrDefault(player => player.playerId == id);
            ViewBag.PageTitle = "Edit Player";
            return View(thisPlayer);
        }

        [HttpPost]
        public ActionResult Edit(Player player)
        {
            _db.Players.Update(player);
            _db.SaveChanges();
            return RedirectToAction("Details", new { id = player.PlayerId });
        }

        public ActionResult Delete(int id)
        {
            Player thisPlayer = _db.Players.FirstOrDefault(player => player.playerId == id);
            ViewBag.PageTitle = "Delete Player";
            return View(thisPlayer);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Player thisPlayer = _db.Players.FirstOrDefault(player => player.playerId == id);
            _db.Players.Remove(thisPlayer);
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