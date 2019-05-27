using System.Collections.Generic;
using System.Linq;
using BountyHuntersAPI.Helpers.Interfaces;
using BountyHuntersAPI.Models;

namespace BountyHuntersAPI.Helpers
{
    public class TournamentBracketHelper : ITournamentBracketHelper
    {
        private readonly ITournamentHelper _tournamentHelper;

        public TournamentBracketHelper(ITournamentHelper tournamentHelper)
        {
            _tournamentHelper = tournamentHelper;
        }

        public Tournament CreateBracket(Tournament tournament)
        {
            var currentMatch = new Match();

            // get the first players when groups are completed
            var tempWinners = new List<Player>();
            tempWinners = GetFirstPlayersForBracket(tempWinners, tournament);

            // mixed players
            var winners = new List<Player>();
            winners = MixPlayers(tempWinners, winners, tournament.PlayersInKnockout);

            // how much there will be matches
            tournament.MatchesCount = _tournamentHelper.FindRoundsNumber(winners.Count);

            AddPlayersToMatches(winners, currentMatch, tournament);

            return tournament;

        }

        public void AddPlayersToMatches(List<Player> winners, Match currentMatch, Tournament tournament)
        {
            foreach (var player in winners)
            {
                currentMatch.Entries.Add(new MatchEntry { MatchPlayer = player });

                if (currentMatch.Entries.Count > 1)
                {
                    currentMatch.WhichMatch = 1;
                    tournament.Matches.Add(currentMatch);
                    currentMatch = new Match();
                }
            }

            // first round
            tournament.CurrentMatch = 1;
        }

        public List<Player> MixPlayers(List<Player> tempWinners, List<Player> winners, int playersInKnockout)
        {
            var lastIndex = tempWinners.Count - 1;
            for (var i = 0; i < playersInKnockout; i++)
            {
                if (i < lastIndex)
                {
                    winners.Add(tempWinners.ElementAt(i));
                    winners.Add(tempWinners.ElementAt(lastIndex));
                    lastIndex -= 1;
                }
            }

            return winners;
        }

        public List<Player> GetFirstPlayersForBracket(List<Player> tempWinners, Tournament tournament)
        {
            tournament.Players = tournament.Players.OrderByDescending(x => x.WinningsCount)
                .ToList();

            for (var i = 0; i < tournament.PlayersInKnockout; i++)
            {
                tempWinners.Add(tournament.Players.ElementAt(i));
            }

            return tempWinners;
        }

        private List<Match> GetPreviousRoundMatches( Tournament tournament, List<Match> previousRoundMatches)
        {
            var previousRound = tournament.Matches.ToList();
            foreach (var previousMatch in previousRound)
            {
                if (previousMatch.WhichMatch == tournament.CurrentMatch)
                {
                    previousRoundMatches.Add(previousMatch);
                }
            }

            return previousRoundMatches;
        }

        // todo: refactor
        public Tournament UpdateBracket(Tournament tournament)
        {
            var round = tournament.CurrentMatch + 1;
            var checkIfRoundIsCreated = false;

            // chech if there are more rounds left
            if (round <= tournament.MatchesCount)
            {
                var previousRoundMatches = new List<Match>();

                previousRoundMatches =  GetPreviousRoundMatches(tournament, previousRoundMatches);

                var currentRound = new List<Match>();
                var currentMatchup = new Match();

                // create round for third place
                if (round == tournament.MatchesCount)
                {
                    var currentRoundForThirdPlace = new List<Match>();
                    var currentMatchupForThirdPlace = new Match();
                    // check players if lost and add them to match for 3rd place
                    PreparePlayerForThirdPlaceRound(currentMatchupForThirdPlace, previousRoundMatches, round, currentRoundForThirdPlace);

                    tournament = AddMatchesToTournament(tournament, currentRoundForThirdPlace);
                }

                // check players if they won add them to current round
                PreparePlayerForNextRound(currentMatchup, previousRoundMatches, round, currentRound, ref checkIfRoundIsCreated);

                var competingPlayers = new List<Player>();
                var nextRoundPlayers = new List<Player>();


                competingPlayers =  AddCompetinngPlayers(currentRound, competingPlayers);
                // mix players for another round
                nextRoundPlayers = MixPlayers(competingPlayers, nextRoundPlayers, competingPlayers.Count);

                // add matches to next round
                AddPlayersToNextRound(currentRound, nextRoundPlayers, tournament, ref checkIfRoundIsCreated);
            }

            return tournament;
        }

        private List<Player> AddCompetinngPlayers(List<Match> currentRound, List<Player> competingPlayers)
        {
            foreach (var current in currentRound)
            {
                foreach (var entry in current.Entries)
                {
                    competingPlayers.Add(entry.MatchPlayer);
                }
            }

            return competingPlayers;
        } 

        public void AddPlayersToNextRound(List<Match> currentRound, List<Player> nextRoundPlayers,
            Tournament tournament, ref bool checkIfRoundIsCreated)
        {

            foreach (var current in currentRound)
            {
                AddEntriesPlayersToMatch(current, nextRoundPlayers);
            }

            tournament = AddMatchesToTournament(tournament, currentRound);

            if (checkIfRoundIsCreated)
                tournament.CurrentMatch += 1;
        }

        private void AddEntriesPlayersToMatch(Match current, List<Player> nextRoundPlayers)
        {
            foreach (var entry in current.Entries)
            {
                entry.MatchPlayer = nextRoundPlayers.First();
                nextRoundPlayers.RemoveAt(0);
            }
        }

        private Tournament AddMatchesToTournament( Tournament tournament, List<Match> currentRound)
        {
            foreach (var current in currentRound)
            {
                tournament.Matches.Add(current);
            }

            return tournament;
        }

        public void PreparePlayerForNextRound(Match currentMatchup, List<Match> previousRoundMatches,
            int round, List<Match> currentRound,ref bool checkIfRoundIsCreated)
        {
            foreach (var match in previousRoundMatches)
            {
                // check if there exists match winer
                if (match.Winner != null)
                {
                    foreach (var previousPlayer in match.Entries)
                    {
                        if (previousPlayer.MatchPlayer.PlayerId == match.Winner.PlayerId)
                        {
                            currentMatchup.Entries.Add(new MatchEntry
                            {
                                Score = 0,
                                ParentMatch = match,
                                MatchPlayer = match.Winner
                            });
                        }
                    }

                }

                // if there are two players, add them into match
                if (currentMatchup.Entries.Count > 1)
                {
                    currentMatchup.WhichMatch = round;
                    currentRound.Add(currentMatchup);
                    checkIfRoundIsCreated = true;
                    currentMatchup = new Match();
                }
            }
        }

        public void PreparePlayerForThirdPlaceRound(Match currentMatchup, List<Match> previousRoundMatches,
            int round, List<Match> currentRound)
        {
            foreach (var match in previousRoundMatches)
            {
                // check if there exists match winer
                if (match.Winner != null)
                {
                    foreach (var previousPlayer in match.Entries)
                    {
                        if (previousPlayer.MatchPlayer.PlayerId != match.Winner.PlayerId)
                        {
                            currentMatchup.Entries.Add(new MatchEntry
                            {
                                Score = 0,
                                ParentMatch = match,
                                MatchPlayer = previousPlayer.MatchPlayer
                            });
                        }
                    }

                }

                // if there are two players, add them into match
                if (currentMatchup.Entries.Count > 1)
                {
                    currentMatchup.WhichMatch = round + 1;
                    currentRound.Add(currentMatchup);
                    currentMatchup = new Match();
                }
            }
        }
    }

   
}
