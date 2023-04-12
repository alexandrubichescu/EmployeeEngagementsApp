using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository.Configurations;
using Repository.Data.Configurations;
using Repository.Models;

public class BlueDbContext : DbContext
{
    public BlueDbContext(DbContextOptions<BlueDbContext> options)
        : base(options)
    {
    }
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Quest> Quests { get; set; } = null!;
    public DbSet<Badge> Badges { get; set; } = null!;
    public DbSet<UserQuest> UserQuests { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new QuestConfiguration());
        modelBuilder.ApplyConfiguration(new BadgeConfiguration());
        modelBuilder.ApplyConfiguration(new UserQuestConfiguration());
    }
}
