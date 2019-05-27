using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BountyHuntersAPI.Data.Interfaces;
using BountyHuntersAPI.Dtos.Tournaments;
using BountyHuntersAPI.Helpers.Interfaces;
using BountyHuntersAPI.Models;
using BountyHuntersAPI.Services.Interfaces;

namespace BountyHuntersAPI.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _repository;
        private readonly ITournamentGroupHelper _tournamentGroupHelper;
        private readonly ITournamentBracketHelper _tournamentBracketHelper;
        private readonly ITournamentHelper _tournamentHelper;
        private readonly IMapper _mapper;


        public TournamentService(ITournamentRepository repository,
            IMapper mapper,
            ITournamentGroupHelper tournamentGroupHelper,
            ITournamentBracketHelper tournamentBracketHelper,
            ITournamentHelper tournamentHelper)
        {
            _repository = repository;
            _mapper = mapper;
            _tournamentGroupHelper = tournamentGroupHelper;
            _tournamentBracketHelper = tournamentBracketHelper;
            _tournamentHelper = tournamentHelper;
        }

        public async Task<ICollection<AllTournamentsDto>> GetAll()
        {
            var tournaments = await _repository.GetAll();
            var sortedTournaments = tournaments.OrderByDescending(x => x.TournamentId);
            var tournamentsDto = _mapper.Map<AllTournamentsDto[]>(sortedTournaments);
            return tournamentsDto;
        }
  
        public async Task<TournamentDto> Create(NewTournamentDto newItem)
        {
            if (newItem == null)
                throw new ArgumentNullException();

            var tournament = _mapper.Map<Tournament>(newItem);

            await _repository.Add(tournament);

            var tournamentDto = _mapper.Map<TournamentDto>(tournament);
            return tournamentDto;
        }

        public async Task<Tournament> CreateBracket(int id)
        {
            var tournament = await _repository.GetById(id);

            tournament = _tournamentBracketHelper.CreateBracket(tournament);

            _repository.Update(tournament);
            return tournament;
        }

        public async Task<Tournament> UpdateBracket(int id)
        {
            var tournament = await _repository.GetById(id);

            tournament = _tournamentBracketHelper.UpdateBracket(tournament);

            _repository.Update(tournament);
            return tournament;
        }

        public async Task<TournamentDto> GetById(int id)
        {
            var tournament = await _repository.GetById(id);

            // sort list
            // tournament = TournamentHelper.SortTournamentPlayersByWins(tournament);
            tournament = _tournamentHelper.SortTournamentPlayersByWins(tournament);

            var tournamentDto = _mapper.Map<TournamentDto>(tournament);
            return tournamentDto;
        }

        public async Task<Tournament> UpdateRounds(int id)
        {
            var tournament = await _repository.GetById(id);

            tournament = _tournamentGroupHelper.OtherGroupRounds(tournament);

            _repository.Update(tournament);
            return tournament;
        }


        public async Task<Tournament> UpdatePlayerScore(int id, int matchId, int entryId, bool increment)
        {
            var tournament = await _repository.GetById(id);
            if (tournament == null)
            {
                throw new InvalidOperationException($"Player with {id} id was not found");
            }

            //tournament = TournamentHelper.UpdateScore(tournament, matchId, entryId, increment);
            tournament = _tournamentHelper.UpdateScore(tournament, matchId, entryId, increment);


            _repository.Update(tournament);

            return tournament;
        }

        public async Task Update(int id, NewTournamentDto updateItem)
        {
            if (updateItem == null)
                throw new ArgumentNullException();

            var itemToUpdate = await _repository.GetById(id);
            if (itemToUpdate == null)
            {
                throw new InvalidOperationException($"Player with {id} id was not found");
            }

            _mapper.Map(updateItem, itemToUpdate);
            _repository.UpdateTournament(itemToUpdate);
        }
    }
}
