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
        var badges = await _context.Badges.ToListAsync();
        return badges;
    }
    public async Task<Badge?> GetBadgeByIdAsync(int BadgeId)
    {
        var badge = await _context.Badges.FindAsync(BadgeId);
        return badge;
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

    public async Task<List<Badge>> GetBadgesByPointsAsync(int currentUserPoints)
    {
        return await _context.Badges.Where(x => x.RequiredPoints <= currentUserPoints).ToListAsync();
    }
}

