using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Implementations;

public class UserRepository : IUserRepository
{
    private readonly BlueDbContext _context;
    public UserRepository(BlueDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddUserAsync(User newUser)
    {
        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();
        return newUser.Id;
    }
    public async Task<List<User>> GetAllUsersAsync()
    {
        var users = await _context.Users.ToListAsync();
        return users;
    }
    public async Task<User?> GetUserByIdAsync(int userId)
    {
        var user = await _context.Users.FindAsync(userId);
        return user;
    }
    public async Task<bool> UpdateUserAsync(User updatedUser)
    {
        _context.Users.Update(updatedUser);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteUserAsync(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}

