
using Repository.Models;

namespace Repository.Interfaces;

public interface IBadgeRepository
{
    Task<int> AddBadgeAsync(Badge newBadge);
    Task<List<Badge>> GetAllBadgesAsync();
    Task<Badge?> GetBadgeByIdAsync(int id);
    Task<bool> UpdateBadgeAsync(Badge newBadge);
    Task<bool> DeleteBadgeAsync(Badge badge);
    Task SaveChangesAsync();
    Task<List<Badge>> GetBadgesByPointsAsync(int currentUserPoints);
}
