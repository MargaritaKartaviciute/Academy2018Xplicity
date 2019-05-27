using System.Collections.Generic;
using   System.ComponentModel.DataAnnotations;
namespace BountyHuntersAPI.Models
{
    public class Tournament
    {
        [Key]
        public int TournamentId { get; set; }
        public string Name { get; set; }
        public int MatchesCount { get; set; }
        public int CurrentMatch { get; set; }
        public int NumberGoals { get; set; }
        public int PlayersInTeam { get; set; }
        public int PlayersInKnockout { get; set; }
        public int GoalsToWin { get; set; }
        public ICollection<Player> Players { get; set; } = new List<Player>();
        public ICollection<Match> Matches { get; set; } = new List<Match>();
    }
}
