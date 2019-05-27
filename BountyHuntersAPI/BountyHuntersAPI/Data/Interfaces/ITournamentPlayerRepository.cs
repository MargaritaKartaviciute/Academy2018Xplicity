using System.Collections.Generic;
using System.Threading.Tasks;
using BountyHuntersAPI.Models;

namespace BountyHuntersAPI.Data.Interfaces
{
    public interface ITournamentPlayerRepository
    {
        Task<Tournament> GetTournamentbyId(int tournamentId);
        Task<Player> Add(Tournament tournament, Player player);
        Task<Player> GetById(int id);
        bool Update(int tournamentId, Player player);
        Task<ICollection<Player>> GetTournamentPlayersbyId(int tournamentId);
    }
}
