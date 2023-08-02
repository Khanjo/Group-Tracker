using Microsoft.EntityFrameworkCore;

namespace GroupTracker.Models
{
    public class GroupTrackerContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CampaignPlayer> CampaignPlayers { get; set; }

        public GroupTrackerContext(DbContextOptions options) : base(options) { }
    }
}