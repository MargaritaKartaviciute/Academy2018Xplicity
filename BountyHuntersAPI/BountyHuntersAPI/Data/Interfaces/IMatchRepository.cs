using System.Collections.Generic;
using System.Threading.Tasks;
using BountyHuntersAPI.Models;

namespace BountyHuntersAPI.Data.Interfaces
{
    public interface IMatchRepository
    {
        Task<ICollection<Match>> GetAll();
        Task<Match> Add(Match match);       
    }
}
