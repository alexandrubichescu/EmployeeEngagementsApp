using Repository.Models;

namespace Services.Interfaces;

public interface IBadgeService
{
    Task<List<Badge>> GetLatestUserBadgesAsync(User user, int currentUserPoints);
}
