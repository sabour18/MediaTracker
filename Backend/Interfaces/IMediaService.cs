using Backend.Dto;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IMediaService
    {
        Task<object> SaveFavourite(FavouriteDto favouriteDto);
        Task<object> AddToMedia(Media media);
    }
}
