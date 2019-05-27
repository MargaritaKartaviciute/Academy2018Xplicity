using System.Collections.Generic;
using System.Threading.Tasks;
using BountyHuntersAPI.Models;

namespace BountyHuntersAPI.Data.Interfaces
{
    public interface ITournamentRepository
    {
        Task<ICollection<Tournament>> GetAll();
        Task<Tournament> Add(Tournament tournament);
        Task<Tournament> GetById(int id);

        bool Update(Tournament tournament);
        bool UpdateTournament(Tournament tournament);
    }
}
