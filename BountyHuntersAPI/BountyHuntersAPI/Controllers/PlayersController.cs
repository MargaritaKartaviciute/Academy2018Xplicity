using System.Threading.Tasks;
using BountyHuntersAPI.Dtos.Players;
using BountyHuntersAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BountyHuntersAPI.Controllers
{
    /// <summary>
    /// depracated :)
    /// </summary>
    [Route("api/players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var players = await _playerService.GetAll();
            return Ok(players);
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayer([FromBody] NewPlayerDto newplayerDto)
        {
            var createPlayer = await _playerService.Create(newplayerDto);

            return Ok(createPlayer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePlayer(int id, [FromBody] UpdatePlayerUsername newPlayerDto)
        {
            _playerService.Update(id, newPlayerDto);
            return NoContent();
        }
    }
}
