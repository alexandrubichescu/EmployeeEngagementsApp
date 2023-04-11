using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Models;

namespace Repository.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> user)
    {
        user.HasKey(u => u.Id);

        user.Property(u => u.FirstName)
            .IsRequired();

        user.Property(u => u.LastName)
            .IsRequired();

        user.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(256)
            .HasAnnotation("RegularExpression", "[^@]+@[^\\.]+\\..+");

        user.Property(u => u.Role)
            .IsRequired();

        user.Property(u => u.Points)
            .IsRequired();

        user.HasMany(u => u.Badges)
            .WithMany(b => b.Users)
            .UsingEntity(j => j.ToTable("UserBadges"));

        user.HasData(
            new User {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "admin@test.com",
                Role = Role.Admin,
                Points = 0,
                PasswordHash = "123"
            },
            new User {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Email = "user@test.com",
                Role = Role.User,
                Points = 0,
                PasswordHash = "123"
            },
            new User {
                Id = 3,
                FirstName = "Mark",
                LastName = "Johnson",
                Email = "markjohnson@example.com",
                Role = Role.User,
                Points = 0,
                PasswordHash = "password"
            },
            new User {
                Id = 4,
                FirstName = "Sarah",
                LastName = "Lee",
                Email = "sarahlee@example.com",
                Role = Role.Admin,
                Points = 0,
                PasswordHash = "password"
            }
        );
    }
}
