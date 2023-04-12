using Services.Auth;
using Services.DTO;

namespace Services.Interfaces;

public interface IUserService
{
    Task<List<UpdateUserDTO>> GetAllUsersAsync();
    Task<UpdateUserDTO> GetUserByIdAsync(int id);
    Task<int> AddUserAsync(AddUserDTO user);
    Task UpdateUserAsync(UpdateUserDTO user);
    Task<bool> DeleteUserAsync(int id);
    Task AddUserPointsAsync(int id, int points);
    Task AddUserBadgeAsync(int id, int badgeId);
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
}
