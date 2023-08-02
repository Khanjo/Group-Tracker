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
    }
}