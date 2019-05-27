namespace BountyHuntersAPI.Dtos.Players
{
    public class AllPlayersDto
    {
        public int PlayerId { get; set; } // for testing purposes
        public string Username { get; set; }
        public int MatchsCount { get; set; }
        public int WinningsCount { get; set; }
        public int DefeatsCount { get; set; }
    }
}
