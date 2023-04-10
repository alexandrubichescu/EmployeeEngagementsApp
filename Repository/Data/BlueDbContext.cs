using System;
using Microsoft.EntityFrameworkCore;
using Repository.Configurations;
using Repository.Models;

public class BlueDbContext : DbContext
{
    public BlueDbContext(DbContextOptions<BlueDbContext> options)
        : base(options)
    {
    }
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Badge> Badges { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new BadgeConfiguration());
    }
}
