using System.Threading.Tasks;
using BountyHuntersAPI.Dtos.Tournaments;
using BountyHuntersAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BountyHuntersAPI.Controllers
{
    [Route("api/tournaments")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;

        public TournamentsController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tournaments = await _tournamentService.GetAll();
            return Ok(tournaments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tournament = await _tournamentService.GetById(id);
            if (tournament == null)
            {
                return NotFound();
            }

            return Ok(tournament);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRounds(int id)
        {
            var updateRounds = await _tournamentService.UpdateRounds(id);
            return Ok(updateRounds);
        }

        [HttpPut("{id}/brackets/create")]
        public async Task<IActionResult> CreateBracket(int id)
        {
            var createBracket = await _tournamentService.CreateBracket(id);
            return Ok(createBracket);
        }

        [HttpPut("{id}/brackets/update")]
        public async Task<IActionResult> UpdateBracket(int id)
        {
            var updateBracket = await _tournamentService.UpdateBracket(id);
            return Ok(updateBracket);
        }

        [HttpPut("{id}/match/{matchId}/entry/{entryId}/increment/{increment}")]
        public async Task<IActionResult> UpdatePlayerScores(int id, int matchId, int entryId, bool increment)
        {
            var updateScores = await _tournamentService.UpdatePlayerScore(id, matchId, entryId, increment);
            return Ok(updateScores);
        }

        [HttpPost]
        public async Task<IActionResult> Add(NewTournamentDto newTournamentDto)
        {
            var createPlayer = await _tournamentService.Create(newTournamentDto);
            return Ok(createPlayer);
        }

        [HttpPut("{id}/rules")]
        public async Task<IActionResult> Update(int id, [FromBody] NewTournamentDto newTournamentDto)
        {
            await _tournamentService.Update(id, newTournamentDto);
            return NoContent();
        }
    }
}