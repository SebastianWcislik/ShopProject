using Microsoft.AspNetCore.Mvc;
using ShopProjectInfrastructure.Attributes;
using ShopProjectInfrastructure.Interfaces;

namespace ShopProjectGamesAPI.Controllers
{
    [ApiController]
    [Bearer]
    [Route("[controller]/[action]")]
    public class GamesController : ControllerBase
    {
        public IGamesRepository gamesRepository;

        public GamesController(IGamesRepository gamesRepository)
        {
            this.gamesRepository = gamesRepository;
        }

        [HttpGet]
        public IActionResult GetGames()
        {
            var result = gamesRepository.GetGames();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetGame([FromQuery] int id)
        {
            var result = gamesRepository.GetGame(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetGameCategories()
        {
            var result = gamesRepository.GetGameCategories();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetGamesByCategory([FromQuery] int categoryId)
        {
            var result = gamesRepository.GetGamesByCategory(categoryId);
            return Ok(result);
        }
    }
}
