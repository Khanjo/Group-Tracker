namespace GroupTracker.Models
{
    public class CampaignPlayer
    {
        public int CampaignPlayerId { get; set; }
        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}