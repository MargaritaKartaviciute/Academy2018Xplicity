using System.Threading.Tasks;
using BountyHuntersAPI.Dtos.Players;

namespace BountyHuntersAPI.Services.Interfaces
{
    public interface ITournamentPlayerService
    {
        Task<PlayerDto> Create(int tournamentId, NewPlayerDto newItem);
        Task Update(int tournamentId, int playerId, NewPlayerDto updateItem);
    }
}
