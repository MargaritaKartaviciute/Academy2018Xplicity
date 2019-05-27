using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BountyHuntersAPI.Data.Interfaces;
using BountyHuntersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BountyHuntersAPI.Data.Repositories
{
    public class TournamentPlayerRepository : ITournamentPlayerRepository
    {
        private readonly DataContext _dataContext;

        public TournamentPlayerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Tournament> GetTournamentbyId(int tournamentId)
        {
            return await _dataContext.Tournaments.FirstOrDefaultAsync(x => x.TournamentId == tournamentId);
        }

        public async Task<ICollection<Player>> GetTournamentPlayersbyId(int tournamentId)
        {
            var players = await _dataContext.Players.Where(x => x.TournamentId == tournamentId).ToListAsync();
            return players;
        }

        public async Task<Player> Add(Tournament tournament, Player player)
        {
            var tournamentStuff = _dataContext.Tournaments.Include(x => x.Players)
                .First(z => z.TournamentId == tournament.TournamentId);

             tournamentStuff.Players.Add(player);
            await _dataContext.SaveChangesAsync();

            return player;
        }

       public bool Update( int tournamentId, Player player)
       {
           var findTournament = _dataContext.Tournaments.FirstOrDefault(x => x.TournamentId == tournamentId);
           if (findTournament == null)
           {
               throw new InvalidOperationException($"Item {player.PlayerId} was not found");
           }

           var tournamentPlayers = findTournament.Players;

            var findPlayer = tournamentPlayers.FirstOrDefault(x => x.PlayerId == player.PlayerId);
            if (findPlayer == null)
            {
                throw new InvalidOperationException($"Item {player.PlayerId} was not found");
            }

            findPlayer.DefeatsCount = player.DefeatsCount;
            findPlayer.WinningsCount = player.WinningsCount;
            findPlayer.Username = player.Username;
            findPlayer.MatchsCount = player.MatchsCount;
            findPlayer.Score = player.Score;

            _dataContext.Players.Update(findPlayer);
            _dataContext.SaveChanges();

            return true;
        }

        public async Task<Player> GetById(int id)
        {
            return await _dataContext.Players.SingleOrDefaultAsync(x => x.PlayerId == id);
        }
    }
}
