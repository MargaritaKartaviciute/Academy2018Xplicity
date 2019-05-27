using System.Collections.Generic;
using BountyHuntersAPI.Models;

namespace BountyHuntersAPI.Helpers.Interfaces
{
    public interface ITournamentHelper
    {
        Tournament SortTournamentPlayersByWins(Tournament tournament);
        Tournament UpdateScore(Tournament tournament, int matchId, int entryId, bool increment);
        void AddRandomPlayer(List<Player> toList, List<Player> tournamentPlayers);
        List<Player> RandomizeTeamsList(List<Player> tournamentPlayers);
        int FindRoundsNumber(int winnersCount);
    }
}
