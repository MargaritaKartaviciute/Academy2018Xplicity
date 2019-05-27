using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BountyHuntersAPI.Data.Interfaces;
using BountyHuntersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BountyHuntersAPI.Data.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly DataContext _dataContext;

        public TournamentRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ICollection<Tournament>> GetAll()
        {
            var orderTournaments =  await _dataContext.Tournaments
                .Include(x => x.Players)
                .Include(y => y.Matches)
                .ThenInclude(z => z.Entries)
                .ToListAsync();
            return orderTournaments;
        }

        public async Task<Tournament> Add(Tournament tournament)
        {
            await _dataContext.AddAsync(tournament);
            await _dataContext.SaveChangesAsync();
            return tournament;
        }

        public async Task<Tournament> GetById(int id)
        {
            return await _dataContext.Tournaments.Include(z => z.Players)
                .Include(y => y.Matches).ThenInclude(z => z.Entries)
                .SingleOrDefaultAsync(x => x.TournamentId == id);
        }

        public bool UpdateTournament(Tournament tournament)
        {
            var findTournament = _dataContext.Tournaments.FirstOrDefault(x => x.TournamentId == tournament.TournamentId);
            if (findTournament == null)
            {
                throw new InvalidOperationException($"Item {tournament.TournamentId} was not found");
            }

            findTournament.CurrentMatch = tournament.CurrentMatch;
            findTournament.GoalsToWin = tournament.GoalsToWin;
            findTournament.Matches = tournament.Matches;
            findTournament.MatchesCount = tournament.MatchesCount;
            findTournament.Name = tournament.Name;
            findTournament.NumberGoals = tournament.NumberGoals;
            findTournament.Players = tournament.Players;
            findTournament.PlayersInKnockout = tournament.PlayersInKnockout;
            findTournament.PlayersInTeam = tournament.PlayersInTeam;

            _dataContext.Tournaments.Update(findTournament);

            return _dataContext.SaveChanges() > 0;
        }

        public bool Update(Tournament tournament)
        {
            _dataContext.Tournaments.Update(tournament);
            _dataContext.SaveChanges();

            return true;
        }

    }
}
