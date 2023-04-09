using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Implementations;

public class BadgeRepository : IBadgeRepository
{
    private readonly BlueDbContext _context;
    public BadgeRepository(BlueDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddBadgeAsync(Badge newBadge)
    {
        _context.Badges.Add(newBadge);
        await _context.SaveChangesAsync();
        return newBadge.Id;
    }
    public async Task<List<Badge>> GetAllBadgesAsync()
    {
        var Badges = await _context.Badges.ToListAsync();
        return Badges;
    }
    public async Task<Badge?> GetBadgeByIdAsync(int BadgeId)
    {
        var Badge = await _context.Badges.FindAsync(BadgeId);
        return Badge;
    }
    public async Task<bool> UpdateBadgeAsync(Badge updatedBadge)
    {
        _context.Badges.Update(updatedBadge);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteBadgeAsync(Badge Badge)
    {
        _context.Badges.Remove(Badge);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}

