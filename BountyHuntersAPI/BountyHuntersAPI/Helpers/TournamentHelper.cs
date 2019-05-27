using System;
using System.Collections.Generic;
using System.Linq;
using BountyHuntersAPI.Helpers.Interfaces;
using BountyHuntersAPI.Models;

namespace BountyHuntersAPI.Helpers
{
    public class TournamentHelper : ITournamentHelper
    {
        private static readonly Random Rnd = new Random();

        public Tournament SortTournamentPlayersByWins(Tournament tournament)
        {
            tournament.Players = tournament.Players.OrderBy(y => y.DefeatsCount).ThenByDescending(x => x.WinningsCount).ToList();
            return tournament;
        }

        // dangerous code ahead
        public Tournament CheckForWinner(Tournament tournament, int matchId)
        {
            var maxGames = tournament.GoalsToWin; // maximum games played

            foreach (var match in tournament.Matches)
            {
                if (match.Id == matchId)
                {
                    if (match.Winner != null)
                        return tournament;
                    CheckIfWeHaveWinnerInEntries(match, tournament, maxGames);
                }
            }

            return tournament;
        }

        private void CheckIfWeHaveWinnerInEntries(Match match, Tournament tournament, int maxGames)
        {
            foreach (var entry in match.Entries)
            {
                if (entry.Score == maxGames)
                {
                    match.Winner = entry.MatchPlayer;
                    IncreasePlayerWinningcCount(tournament, match);
                }
            }

            if (match.Winner != null)
            {
                foreach (var entry in match.Entries)
                {
                    IncreasePlayerDefeatsCount(tournament, match, entry);
                }
            }
        }

        private void IncreasePlayerWinningcCount(Tournament tournament, Match match)
        {
            foreach (var player in tournament.Players)
            {
                if (player.PlayerId == match.Winner.PlayerId)
                {
                    player.WinningsCount += 1;
                }
            }
        }

        private void IncreasePlayerDefeatsCount(Tournament tournament, Match match, MatchEntry entry)
        {
            foreach (var player in tournament.Players)
            {
                if (player.PlayerId == entry.MatchPlayer.PlayerId && player.PlayerId != match.Winner.PlayerId)
                {
                    player.DefeatsCount += 1;
                }
            }
        }


        public Tournament UpdateScore(Tournament tournament, int matchId, int entryId, bool increment)
        {
            var maxGames = tournament.GoalsToWin; // maximum 3 games played
            foreach (var match in tournament.Matches)
            {
                // grab total score
                if (match.Id == matchId)
                {
                    FindPlayerAndUpdateScore(match, entryId, maxGames, increment);
                }
            }

            tournament = CheckForWinner(tournament, matchId);
            return tournament;
        }

        public void FindPlayerAndUpdateScore(Match match, int entryId, int maxGames, bool increment)
        {
                foreach (var entry in match.Entries)
                {
                    if (entry.Id == entryId && entry.Score < maxGames)
                        if (increment)
                        {
                           entry.Score += 1;
                         }
                         else if (entry.Score > 0)
                         {
                            entry.Score -= 1;
                         }
                }
        }


        public void RandomizeTeams(Tournament tournament)
        {
            var players = tournament.Players.OrderBy(a => Guid.NewGuid()).ToList();
            tournament.Players = players;
        }

        public void AddRandomPlayer(List<Player> source, List<Player> destination)
        {
            var randomPlayer = GetRandomPlayer(source);

            while (destination.Contains(randomPlayer))
            {
                randomPlayer = GetRandomPlayer(source);
            }

            destination.Add(randomPlayer);
        }

        public Player GetRandomPlayer(List<Player> players)
        {
            var nextVal = players[Rnd.Next(0, players.Count)];
            return nextVal;
        }

        public List<Player> RandomizeTeamsList(List<Player> players)
        {
            var playersRandomize = players.OrderBy(a => Guid.NewGuid()).ToList();
            return playersRandomize;
        }

        public int FindRoundsNumber(int playerCount)
        {
            var output = 1;
            var val = 2;

            while (val < playerCount)
            {
                output += 1;
                val = val * 2;
            }

            return output;
        }
    }
}
