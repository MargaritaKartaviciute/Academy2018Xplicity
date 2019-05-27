using System.Collections.Generic;
using System.Linq;
using BountyHuntersAPI.Helpers.Interfaces;
using BountyHuntersAPI.Models;

namespace BountyHuntersAPI.Helpers
{
    public class TournamentGroupsHelper : ITournamentGroupHelper
    {
        private readonly ITournamentHelper _tournamentHelper;

        public TournamentGroupsHelper(ITournamentHelper tournamentHelper)
        {
            _tournamentHelper = tournamentHelper;
        }

        // find players that played least matches
        public int FindLeastMatches(Tournament tournament)
        {
            var minMatches = tournament.Players.First().MatchsCount;
            foreach (var player in tournament.Players)
            {
                if (player.MatchsCount <= minMatches)
                {
                    minMatches = player.MatchsCount;
                }
            }
            return minMatches;
        }

        // increase current entry player matches count by 1
        public void IncreasePlayersMatchsCount(Tournament tournament, Match currentMatch)
        {
            foreach (var tournamentPlayer in tournament.Players)
            {
                foreach (var entry in currentMatch.Entries)
                {
                    if (entry.MatchPlayer.PlayerId == tournamentPlayer.PlayerId)
                        tournamentPlayer.MatchsCount += 1;
                }
            }
        }


        public Tournament OtherGroupRounds(Tournament tournament)
        {
            var currentMatch = new Match();
            var tournamentPlayers = new List<Player>();

            
            var minMatches = FindLeastMatches(tournament);

            tournamentPlayers.AddRange(tournament.Players.Where(player => player.MatchsCount == minMatches));


            if (tournamentPlayers.Count == 1)
            {
                _tournamentHelper.AddRandomPlayer(tournament.Players.ToList(), tournamentPlayers);
            }

            tournamentPlayers = _tournamentHelper.RandomizeTeamsList(tournamentPlayers);

            foreach (var player in tournamentPlayers)
            {
                currentMatch.Entries.Add(new MatchEntry { MatchPlayer = player });

                if (currentMatch.Entries.Count > 1)
                {
                    currentMatch.WhichMatch = 0;

                    //method which increase player match count
                    IncreasePlayersMatchsCount(tournament, currentMatch);

                    tournament.Matches.Add(currentMatch);
                    return tournament;
                }
            }

            return tournament;

        }

    }
}
