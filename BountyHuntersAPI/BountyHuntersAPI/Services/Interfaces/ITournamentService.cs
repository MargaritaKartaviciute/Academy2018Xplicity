using System.Collections.Generic;
using System.Threading.Tasks;
using BountyHuntersAPI.Dtos.Tournaments;
using BountyHuntersAPI.Models;

namespace BountyHuntersAPI.Services.Interfaces
{
    public interface ITournamentService
    {
        Task<ICollection<AllTournamentsDto>> GetAll();

        Task<TournamentDto> Create(NewTournamentDto newItem);
        Task<TournamentDto> GetById(int id);
        Task<Tournament> UpdateRounds(int id);
        Task<Tournament> UpdatePlayerScore(int id, int matchId, int entryId, bool increment);
        Task Update(int id, NewTournamentDto updateItem);
        Task<Tournament> CreateBracket(int id);
        Task<Tournament> UpdateBracket(int id);
    }
}
