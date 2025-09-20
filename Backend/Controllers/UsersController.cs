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
    public class UsersController : ControllerBase
    {
        private readonly MediaTrackerContext _dbContext;
        private readonly IUserService _userService;

        public UsersController(MediaTrackerContext dbContext, IUserService userService)
        {
            this._dbContext = dbContext;
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _dbContext.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("User")]
        public async Task<IActionResult> GetUser(string username)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
            {
                return BadRequest("User does not exist");
            }

            return Ok(user);
        }

        [HttpGet("favourites")]
        public async Task<IActionResult> GetFavourites(Guid userId)
        {
            if(userId == Guid.Empty)
            {
                return BadRequest();
            }

            var result = await _userService.GetFavourites(userId);

            return Ok(result);
        }
    }
}
