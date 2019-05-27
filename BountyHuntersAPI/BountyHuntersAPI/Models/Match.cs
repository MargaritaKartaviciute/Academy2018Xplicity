using System.Collections.Generic;

namespace BountyHuntersAPI.Models
{
    public class Match
    {
        public int Id { get; set; }

        public int WhichMatch { get; set; }

        public ICollection<MatchEntry> Entries { get; set; } = new List<MatchEntry>();

        public Player Winner { get; set; }
    }
}
