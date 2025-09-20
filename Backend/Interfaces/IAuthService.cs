using Backend.Dto;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IAuthService
    {
        Task<Users?> RegisterAsync(UserDto request);
        Task<LoginResponseDto> LoginAsync(UserDto request);
    }
}
