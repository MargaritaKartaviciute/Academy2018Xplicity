using System.Collections.Generic;
using System.Threading.Tasks;
using BountyHuntersAPI.Dtos.Players;
using BountyHuntersAPI.Models;

namespace BountyHuntersAPI.Data.Interfaces
{
    public interface IPlayerRepository
    {
        Task<ICollection<Player>> GetAll();
        Task<Player> Add(Player player);
        Player GetById(int id);
        bool Update(Player player, UpdatePlayerUsername updatePlayerUsername);

    }
}
