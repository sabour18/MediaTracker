using Backend.Interfaces;
using Backend.Models.TMDb;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("TMDb")]
    [AllowAnonymous]
    [ApiController]
    public class TMDbController : ControllerBase
    {
        private readonly ITMDbService _tmdbService;

        public TMDbController(ITMDbService tmdbService)
        {
            _tmdbService = tmdbService;
        }

        [HttpGet("movie/trending")]
        public async Task<IActionResult> GetTrending()
        {
            try
            {
                var movies = await _tmdbService.GetTrendingMoviesAsync();
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
