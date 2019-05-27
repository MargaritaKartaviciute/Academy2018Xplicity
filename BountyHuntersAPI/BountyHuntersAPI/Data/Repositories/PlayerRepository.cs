using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BountyHuntersAPI.Data.Interfaces;
using BountyHuntersAPI.Dtos.Players;
using BountyHuntersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BountyHuntersAPI.Data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly DataContext _dataContext;

        public PlayerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ICollection<Player>> GetAll()
        {
            var values = await _dataContext.Players.ToListAsync();
            return values;
        }

        public async Task<Player> Add(Player player)
        {
            await _dataContext.AddAsync(player);
            await _dataContext.SaveChangesAsync();
            return player;
        }

        public Player GetById(int id)
        {
            return _dataContext.Players.SingleOrDefault(x => x.PlayerId == id);
        }

        public bool Update(Player player, UpdatePlayerUsername updatePlayerUsername)
        {
            var findPlayer = _dataContext.Players.FirstOrDefault(x => x.PlayerId == player.PlayerId);
            if (findPlayer == null)
            {
                throw new InvalidOperationException($"Item {player.PlayerId} was not found");
            }

            findPlayer.Username = updatePlayerUsername.Username;
            //findPlayer.DefeatsCount = player.DefeatsCount;
            //findPlayer.MatchsCount = player.MatchsCount;
            //findPlayer.WinningsCount = player.WinningsCount;

            _dataContext.Update(findPlayer);
            _dataContext.SaveChanges();

            return true;
        }
    }
}
