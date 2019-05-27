namespace BountyHuntersAPI.Models
{
    public class MatchEntry
    {
        public int Id { get; set; }
        public int Score { get; set; }

        public Player MatchPlayer { get; set; }

        public Match ParentMatch { get; set; }
    }
}
