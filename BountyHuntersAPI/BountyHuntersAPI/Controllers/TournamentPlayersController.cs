using System.Threading.Tasks;
using BountyHuntersAPI.Dtos.Players;
using BountyHuntersAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BountyHuntersAPI.Controllers
{
    // this controller will help to edit existing users
    // Todo: implement edit player method
    [Route("api/tournaments/{tournamentId}/players")]
    [ApiController]
    public class TournamentPlayersController : ControllerBase
    {
        private readonly ITournamentPlayerService _tournamentPlayerService;

        public TournamentPlayersController(ITournamentPlayerService tournamentPlayerService)
        {
            _tournamentPlayerService = tournamentPlayerService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(int tournamentId, [FromBody] NewPlayerDto newPlayerDto)
        {
            var createPlayer = await _tournamentPlayerService.Create(tournamentId, newPlayerDto);
            return Ok(createPlayer);
        }
        [HttpPut("{playerId}")]
        public async Task<IActionResult> Put(int tournamentId, int playerId, [FromBody] NewPlayerDto newPlayerDto)
        {
            await _tournamentPlayerService.Update(tournamentId, playerId, newPlayerDto);
            return NoContent();
        }



    }
}