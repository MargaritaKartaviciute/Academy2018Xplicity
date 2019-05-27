using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BountyHuntersAPI.Data.Interfaces;
using BountyHuntersAPI.Dtos.Players;
using BountyHuntersAPI.Models;
using BountyHuntersAPI.Services.Interfaces;

namespace BountyHuntersAPI.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _repository;
        private readonly IMapper _mapper;

        public PlayerService(
            IPlayerRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<AllPlayersDto>> GetAll()
        {
            var players = await _repository.GetAll();
            var playersDto = _mapper.Map<AllPlayersDto[]>(players);
            return playersDto;
        }

        public async Task<PlayerDto> Create(NewPlayerDto newItem)
        {
            if (newItem == null) 
                throw new ArgumentNullException();

            var player = _mapper.Map<Player>(newItem);
            await _repository.Add(player);

            var playerDto = _mapper.Map<PlayerDto>(newItem);
            return playerDto;
        }

        public void Update(int id, UpdatePlayerUsername updateItem)
        {
            if (updateItem == null)
                throw new ArgumentNullException();

            var itemToUpdate = _repository.GetById(id);
            if (itemToUpdate == null)
            {
                throw new InvalidOperationException($"Player with {id} id was not found");
            }

            _repository.Update(itemToUpdate, updateItem);
        }
    }
}
