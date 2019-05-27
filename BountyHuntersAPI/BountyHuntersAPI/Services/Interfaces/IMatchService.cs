using System.Collections.Generic;
using System.Threading.Tasks;
using BountyHuntersAPI.Dtos.Matches;

namespace BountyHuntersAPI.Services.Interfaces
{
    public interface IMatchService
    {
        Task<ICollection<AllMatchesDto>> GetAll();
        Task<MatchDto> Create(NewMatchDto newItem);
    }
}
