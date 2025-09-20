using Backend.Models.TMDb;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Backend.Dto
{
    public class FavouriteDto
    {
        public Guid UserId { get; set; }
        public TMDbMovie Title { get; set; }
    }
}
