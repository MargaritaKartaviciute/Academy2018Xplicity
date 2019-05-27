using System.Threading.Tasks;
using BountyHuntersAPI.Dtos.Matches;
using BountyHuntersAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BountyHuntersAPI.Controllers
{
    [Route("api/matches")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public MatchesController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var matches = await _matchService.GetAll();
            return Ok(matches);
        }

        [HttpPost]
        public async Task<IActionResult> AddMatch([FromBody] NewMatchDto newMatchDto)
        {
            var createMatch = await _matchService.Create(newMatchDto);

            return Ok(createMatch);
        }


    }
}