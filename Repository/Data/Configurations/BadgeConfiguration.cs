using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Models;

namespace Repository.Configurations;

public class BadgeConfiguration : IEntityTypeConfiguration<Badge>
{
    public void Configure(EntityTypeBuilder<Badge> builder)
    {
        builder.ToTable("Badges");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.Name).IsRequired().HasMaxLength(50);
        builder.Property(b => b.Description).HasMaxLength(500);
        builder.Property(b => b.ImageUrl).HasMaxLength(100);
        builder.Property(b => b.RequiredPoints);

        //builder.HasMany(x => x.Users);

        builder.HasData(
            new Badge { Id = 1, Name = "Team Player", Description = "Awarded for collaborating well with others" },
            new Badge { Id = 2, Name = "Innovator", Description = "Awarded for contributing innovative ideas" },
            new Badge { Id = 3, Name = "Top Performer", Description = "Awarded for exceptional performance" }
        );
    }
}
