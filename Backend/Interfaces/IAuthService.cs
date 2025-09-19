using Backend.Dto;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto request);
        Task<LoginResponseDto> LoginAsync(UserDto request);
    }
}
