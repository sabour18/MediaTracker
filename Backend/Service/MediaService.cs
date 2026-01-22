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
    public class MediaService: IMediaService
    {
        private readonly MediaTrackerContext _dbContext;
        private readonly IUserService _userService;

        public MediaService(MediaTrackerContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public async Task<object> SaveFavourite(FavouriteDto favouriteDto)
        {
            var media = favouriteDto.Title;
            var mediaEntity = new Media
            {
                MediaId = media.Id,
                Title = media.Title ?? media.OriginalTitle,
                OriginalTitle = media.OriginalTitle,
                Overview = media.Overview,
                PosterPath = media.PosterPath,
                BackdropPath = media.BackdropPath,
                MediaType = media.MediaType,
                OriginalLanguage = media.OriginalLanguage,
                Popularity = media.Popularity,
                ReleaseDate = string.IsNullOrEmpty(media.ReleaseDate) ? (DateTime?)null : DateTime.Parse(media.ReleaseDate),
                Video = media.Video,
                VoteAverage = media.VoteAverage,
                VoteCount = media.VoteCount,
                GenreIds = JsonConvert.SerializeObject(media.GenreIds),
                TypeId = null //TODO
            };

            

            // Check if this title is in media. If not, then add the media
            var isInMedia = await _dbContext.Media.AnyAsync(m => m.MediaId == mediaEntity.MediaId);

            if (!isInMedia) 
            {
                var newMedia = this.AddToMedia(mediaEntity).Result;
            }

            // If lists are getting too large. Change to checking database for efficiency.
            var favouriteTitles = await _userService.GetFavourites(favouriteDto.UserId);
            var hasFavourites = favouriteTitles.Any(t => t.MediaId == favouriteDto.Title.Id);

            // First Check if the user has a favourite list or not
            if (favouriteTitles == null || !favouriteTitles.Any())
            {
                var favourite = new FavouriteList
                {
                    FavouritesId = Guid.NewGuid(),
                    UserId = favouriteDto.UserId,
                    MediaId = mediaEntity.MediaId,
                    TypeId = null
                };


                _dbContext.FavouriteList.Add(favourite);
                _dbContext.SaveChanges();

                return new { Message = "Created favourites list and added first title.", Favourite = favourite };
            }
            else
            {
                var favouriteEntry = await _dbContext.FavouriteList
                    .FirstOrDefaultAsync(f =>
                        f.UserId == favouriteDto.UserId &&
                        f.MediaId == favouriteDto.Title.Id
                    );

                // TODO: Unfavourite the Title
                if (favouriteEntry != null)
                {
                    _dbContext.FavouriteList.Remove(favouriteEntry);
                    _dbContext.SaveChanges();

                    return new { Message = "Title already in favourites." };
                }
                else
                {
                    // Add the title to favourites list
                    var newFavourite = new FavouriteList
                    {
                        FavouritesId = Guid.NewGuid(),
                        UserId = favouriteDto.UserId,
                        MediaId = mediaEntity.MediaId,
                        TypeId = null
                    };

                    _dbContext.FavouriteList.Add(newFavourite);
                }
                   
                _dbContext.SaveChanges();
            }
                
            return new { Message = "Added title to existing favourites."};
        }

        public async Task<object> AddToMedia(Media media)
        {           
            _dbContext.Media.Add(media);
            await _dbContext.SaveChangesAsync();

            return new { message = "Title added to media table.", Media = media };
        }
    }
}
