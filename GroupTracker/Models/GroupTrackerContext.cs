using Microsoft.EntityFrameworkCore;

namespace GroupTracker.Models
{
    public class GroupTrackerContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        public GroupTrackerContext(DbContextOptions options) : base(options) { }
    }
}