using System.Collections.Generic;
using BountyHuntersAPI.Models;

namespace BountyHuntersAPI.Dtos.Tournaments
{
    public class NewTournamentDto
    {
        public string Name { get; set; }
        public int PlayersInTeam { get; set; }
        public int CurrentMatch { get; set; }
        public int PlayersInKnockout { get; set; }
        public int GoalsToWin { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}
