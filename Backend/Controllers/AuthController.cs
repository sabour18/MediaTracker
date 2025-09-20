using Backend.Dto;
using Backend.Interfaces;
using Backend.Models;
using Backend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly MediaTrackerContext _dbContext;
        private readonly IAuthService _authService;

        public AuthController(MediaTrackerContext dbContext, IAuthService authService) 
        {
            this._authService = authService;
            this._dbContext = dbContext;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Users>> Register(UserDto request)
        {
            var user = await _authService.RegisterAsync(request);

            if (user is null)
            {
                return BadRequest("User already exists.");
            }

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login(UserDto request)
        {
            var response = await _authService.LoginAsync(request);

            if (response is null)
            {
                return BadRequest("Invalid username and/or password.");
            }

            return Ok(response);
        }
    }
}
