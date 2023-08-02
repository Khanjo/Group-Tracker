namespace GroupTracker.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public List<Character> Characters { get; set; }
        public List<CampaignPlayer> JoinEntities { get; }
    }
}