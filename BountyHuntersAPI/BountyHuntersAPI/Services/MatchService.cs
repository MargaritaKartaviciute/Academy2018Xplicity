using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BountyHuntersAPI.Data.Interfaces;
using BountyHuntersAPI.Dtos.Matches;
using BountyHuntersAPI.Models;
using BountyHuntersAPI.Services.Interfaces;

namespace BountyHuntersAPI.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _repository;
        private readonly IMapper _mapper;

        public MatchService(IMatchRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MatchDto> Create(NewMatchDto newItem)
        {
            if (newItem == null)
                throw new ArgumentNullException();

            var match = _mapper.Map<Match>(newItem);
            await _repository.Add(match);

            var matchDto = _mapper.Map<MatchDto>(newItem);
            return matchDto;
        }

        public async Task<ICollection<AllMatchesDto>> GetAll()
        {
            var matches = await _repository.GetAll();
            var matchesDtos = _mapper.Map<AllMatchesDto[]>(matches);
            return matchesDtos;
        }

    }
}
