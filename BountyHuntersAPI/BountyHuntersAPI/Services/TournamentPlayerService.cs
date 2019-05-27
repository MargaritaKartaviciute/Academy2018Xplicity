using System;
using System.Threading.Tasks;
using AutoMapper;
using BountyHuntersAPI.Data.Interfaces;
using BountyHuntersAPI.Dtos.Players;
using BountyHuntersAPI.Models;
using BountyHuntersAPI.Services.Interfaces;

namespace BountyHuntersAPI.Services
{
    public class TournamentPlayerService : ITournamentPlayerService
    {

        private readonly ITournamentPlayerRepository _repository;
        private readonly IMapper _mapper;

        public TournamentPlayerService(ITournamentPlayerRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

 
        public async Task<PlayerDto> Create(int tournamentId, NewPlayerDto newItem)
        {
            if (newItem == null)
                throw new ArgumentNullException();

            var getTournament = await _repository.GetTournamentbyId(tournamentId);
            if (getTournament == null)
            {
                throw new InvalidOperationException($"Tournament with {tournamentId} id was not found");
            }

            var tournametPlayer = _mapper.Map<Player>(newItem);
            await _repository.Add(getTournament, tournametPlayer);

            var tournamentPlayerDto = _mapper.Map<PlayerDto>(newItem);
            return tournamentPlayerDto;
        }

        public async Task Update(int tournamentId, int playerId, NewPlayerDto updateItem)
        {
            if (updateItem == null)
                throw new ArgumentNullException();

            var getTournamentPlayers = await _repository.GetTournamentPlayersbyId(tournamentId);
            if (getTournamentPlayers == null)
            {
                throw new InvalidOperationException($"Tournament with {tournamentId} id was not found");
            }

            if (getTournamentPlayers.Count == 0)
            {
                throw new InvalidOperationException($"Tournament with {tournamentId} id don't have players");
            }

            var itemToUpdate = await _repository.GetById(playerId);
            if (itemToUpdate == null)
            {
                throw new InvalidOperationException($"Player with {playerId} id was not found");
            }

            _mapper.Map(updateItem, itemToUpdate);
            _repository.Update(tournamentId, itemToUpdate);
        }
    }
}
