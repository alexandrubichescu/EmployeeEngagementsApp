using Repository.Models;
using Services.Auth;
using Services.DTO;

namespace Services.Interfaces;

public interface IUserService
{
    Task<List<UserDTO>> GetAllUsersAsync();
    Task<UserDTO> GetUserByIdAsync(int id);
    Task<int> AddUserAsync(UserDTO user);
    Task<bool> UpdateUserAsync(UserDTO user);
    Task<bool> DeleteUserAsync(int id);
    Task AddUserPointsAsync(int id, int points);
    Task AddUserBadgeAsync(int id, int badgeId);
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
}
