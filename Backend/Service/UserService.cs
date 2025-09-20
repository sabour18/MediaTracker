using Backend.Dto;
using Backend.Interfaces;
using Backend.Models;
using Backend.Models.TMDb;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Backend.Service
{
    public class UserService: IUserService
    {
        private readonly MediaTrackerContext _dbContext;

        public UserService(MediaTrackerContext dbContext)
        {
            _dbContext = dbContext;
        }
      
        public async Task<List<Media>> GetFavourites(Guid userId)
        {
            var favourites = await _dbContext.FavouriteList.Where(u => u.UserId == userId).Select(u => u.Media).ToListAsync();
            return favourites;
        }
    }
}
