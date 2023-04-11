using Repository.Models;

namespace Services.Interfaces;

public interface IBadgeService
{
    Task<List<Badge>> GetLatestUserBadges(User user, int currentUserPoints);
}
