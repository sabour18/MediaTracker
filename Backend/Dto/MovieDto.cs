using Microsoft.AspNetCore.Mvc;

namespace Backend.Dto
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public string ReleaseDate { get; set; }
    }
}
