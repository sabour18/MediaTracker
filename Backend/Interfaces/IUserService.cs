using Backend.Dto;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IUserService
    {
        Task<List<Media>> GetFavourites(Guid userId);
    }
}
