using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Backend.Interfaces;
using Backend.Models.TMDb;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Identity.Client;

namespace Backend.Services
{
    public class TMDbService : ITMDbService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        // Cache
        private readonly IMemoryCache _cache;
        private const string CacheKey = "TrendingMoviesCache";
        private static readonly TimeSpan CacheDuration = TimeSpan.FromDays(1);

        public TMDbService(IHttpClientFactory httpClientFactory, IConfiguration config, IMemoryCache cache)
        {
            _httpClient = httpClientFactory.CreateClient("TMDbClient");
            _config = config;
            _apiKey = _config["TMDbSettings:ApiKey"];
            _baseUrl = _config["TMDbSettings:BaseUrl"];
            _cache = cache;
        }

        public async Task<List<TMDbMovie>> GetTrendingMoviesAsync()
        {
            // Check if the cache contains the data
            if (_cache.TryGetValue(CacheKey, out List<TMDbMovie>? cachedMovies) && cachedMovies != null)
            {
                return cachedMovies;
            }

            // If not cache, make TMDb api call
            var response = await _httpClient.GetAsync($"{_baseUrl}trending/movie/week?api_key={_apiKey}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to fetch trending movies: {response.ReasonPhrase}");
            }

            var content = await response.Content.ReadAsStringAsync();
            var movies = JsonConvert.DeserializeObject<TrendingMoviesResponse>(content);

            if (movies?.Results == null)
            {
                throw new Exception("No movies found in the API response.");
            }

            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = CacheDuration // Cache expires in 1 day
            };

            _cache.Set(CacheKey, movies.Results, cacheOptions);



            return movies.Results;
        }
    }
}
