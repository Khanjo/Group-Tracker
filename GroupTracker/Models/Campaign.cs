namespace GroupTracker.Models
{
    public class Campaign
    {
        public int CampaignId { get; set; }
        public string Title { get; set; }
        public string World { get; set; }
        public string Summary { get; set; }
        public List<Player> Players { get; set; }
    }
}