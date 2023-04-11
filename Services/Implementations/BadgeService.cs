using Repository.Interfaces;
using Repository.Models;
using Services.Interfaces;

namespace Services.Implementations;

public class BadgeService : IBadgeService
{
    private readonly IBadgeRepository _badgeRepository;

    public BadgeService(IBadgeRepository badgeRepository)
    {
        _badgeRepository = badgeRepository;
    }

    public async Task<List<Badge>> GetLatestUserBadges(User user, int currentUserPoints)
    {
        var userBadgeIds = user.Badges?.Select(x => x.Id).ToList();

        var badgesByPoints = await _badgeRepository.GetBadgesByPointsAsync(currentUserPoints);

        var latestBadges = badgesByPoints.Where(x => !userBadgeIds!.Contains(x.Id)).ToList();

        return latestBadges;
    }
}