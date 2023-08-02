namespace GroupTracker.Models
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}