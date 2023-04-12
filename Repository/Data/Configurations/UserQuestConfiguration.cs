using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Models;

namespace Repository.Data.Configurations;

public class UserQuestConfiguration : IEntityTypeConfiguration<UserQuest>
{
    public void Configure(EntityTypeBuilder<UserQuest> builder)
    {
        builder.HasKey(q => q.Id);

        builder.Property(q => q.UserId)
        .IsRequired();

        builder.Property(q => q.QuestId)
        .IsRequired();
    }
}
