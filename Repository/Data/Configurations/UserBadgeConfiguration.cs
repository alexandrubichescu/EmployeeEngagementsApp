using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Models;

namespace Repository.Configurations;

public class UserBadgeConfiguration : IEntityTypeConfiguration<UserBadge>
{
    public void Configure(EntityTypeBuilder<UserBadge> userBadge)
    {
        userBadge.HasKey(ub => new { ub.UserId, ub.BadgeId });
    }
}
