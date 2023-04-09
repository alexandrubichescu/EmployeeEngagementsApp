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

        user.Property(u => u.Password)
            .IsRequired();

        user.Property(u => u.Points)
            .IsRequired();

        //user.HasMany(u => u.Badges);
    }
}
