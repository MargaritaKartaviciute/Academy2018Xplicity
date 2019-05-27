using System.Collections.Generic;
using System.Threading.Tasks;
using BountyHuntersAPI.Dtos.Players;

namespace BountyHuntersAPI.Services.Interfaces
{
    public interface IPlayerService
    {
        Task<ICollection<AllPlayersDto>> GetAll();
        Task<PlayerDto> Create(NewPlayerDto newItem);

        void Update(int id, UpdatePlayerUsername updateItem);
    }
}
