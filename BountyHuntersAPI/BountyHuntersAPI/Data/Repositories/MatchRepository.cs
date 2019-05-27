using System.Collections.Generic;
using System.Threading.Tasks;
using BountyHuntersAPI.Data.Interfaces;
using BountyHuntersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BountyHuntersAPI.Data.Repositories
{

    public class MatchRepository :IMatchRepository
    {
        private readonly DataContext _dataContext;


        public MatchRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Match> Add(Match match)
        {
            await _dataContext.AddAsync(match);
            await _dataContext.SaveChangesAsync();
            return match;
        }

        public async Task<ICollection<Match>> GetAll()
        {
            var values = await _dataContext.Matches.ToListAsync();
            return values;
        }
    }
}
