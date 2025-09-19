using Backend.Dto;
using Backend.Models;
using Backend.Models.TMDb;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Interfaces
{
    public interface ITMDbService
    {
        Task<List<TMDbMovie>> GetTrendingMoviesAsync();
    }
}
