using Backend.Dto;
using Backend.Interfaces;
using Backend.Models;
using Backend.Models.TMDb;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly MediaTrackerContext _dbContext;
        private readonly IMediaService _mediaService;

        public MediaController(MediaTrackerContext dbContext, IMediaService mediaService)
        {
            this._dbContext = dbContext;
            _mediaService = mediaService;
        }


        [HttpPost("SaveFavourite")]
        [Authorize]
        public async Task<IActionResult> SaveFavourite([FromBody] FavouriteDto favourite)
        {
            if (favourite.Title == null) 
            {
                return BadRequest(new { message = "Title is null" });
            }
            if (favourite.UserId == null)
            {
                return BadRequest(new { message = "User is null" });
            }

            var result = await _mediaService.SaveFavourite(favourite);

            return Ok(result);
        }
    }
}
