using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Models;

namespace Repository.Data.Configurations;

public class QuestConfiguration : IEntityTypeConfiguration<Quest>
{
    public void Configure(EntityTypeBuilder<Quest> builder)
    {
        builder.ToTable("Quests");

        builder.HasKey(q => q.Id);

        builder.Property(q => q.Title)
            .IsRequired()
        .HasMaxLength(200);

        builder.Property(q => q.Description)
            .IsRequired()
        .HasMaxLength(500);

        builder.Property(q => q.Points)
        .IsRequired();

        builder.Property(q => q.CreatorId)
        .IsRequired();

        builder.Property(q => q.Status)
        .IsRequired();

        builder.Property(q => q.ApprovedBy)
        .IsRequired();


        builder.HasData(
            new Quest
            {
                Id = 1,
                Title= "Gym Quest",
                Description = "Complete 10 push-ups",
                Points = 50,
                CreatorId=2,
                Status=QuestStatus.Approved,
                ApprovedBy=1,
            },
            new Quest
            {
                Id = 2,
                Title = "Maraton",
                Description = "Walk 10,000 steps",
                Points = 50,
                CreatorId = 2,
                Status = QuestStatus.Approved,
                ApprovedBy = 1,
            },
            new Quest
            {
                Id = 3,
                Title = "Brain training",
                Description = "Read a book for 1 hour",
                Points = 50,
                CreatorId = 3,
                Status = QuestStatus.Rejected,
                ApprovedBy = 1,
            }
        );
    }
}
