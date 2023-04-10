
using Repository.Models;

namespace Repository.Interfaces;

public interface IUserRepository
{
    Task<int> AddUserAsync(User newUser);
    Task<List<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task<User?> GetFullUserByIdAsync(int id);
    Task<bool> UpdateUserAsync(User newUser);
    Task<bool> DeleteUserAsync(User user);
    Task SaveChangesAsync();
}
