using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Backend.Dto
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
