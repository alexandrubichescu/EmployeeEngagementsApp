﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(BlueDbContext))]
    [Migration("20230411195207_AddEntities")]
    partial class AddEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BadgeUser", b =>
                {
                    b.Property<int>("BadgesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("BadgesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UserBadges", (string)null);
                });

            modelBuilder.Entity("Repository.Models.Badge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RequiredPoints")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Badges", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Awarded for collaborating well with others",
                            Name = "Team Player",
                            RequiredPoints = 0
                        },
                        new
                        {
                            Id = 2,
                            Description = "Awarded for contributing innovative ideas",
                            Name = "Innovator",
                            RequiredPoints = 0
                        },
                        new
                        {
                            Id = 3,
                            Description = "Awarded for exceptional performance",
                            Name = "Top Performer",
                            RequiredPoints = 0
                        });
                });

            modelBuilder.Entity("Repository.Models.Quest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApprovedBy")
                        .HasColumnType("int");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Quests", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApprovedBy = 1,
                            CreatorId = 2,
                            Description = "Complete 10 push-ups",
                            Points = 50,
                            Status = 0,
                            Title = "Gym Quest"
                        },
                        new
                        {
                            Id = 2,
                            ApprovedBy = 1,
                            CreatorId = 2,
                            Description = "Walk 10,000 steps",
                            Points = 50,
                            Status = 0,
                            Title = "Maraton"
                        },
                        new
                        {
                            Id = 3,
                            ApprovedBy = 1,
                            CreatorId = 3,
                            Description = "Read a book for 1 hour",
                            Points = 50,
                            Status = 1,
                            Title = "Brain training"
                        });
                });

            modelBuilder.Entity("Repository.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasAnnotation("RegularExpression", "[^@]+@[^\\.]+\\..+");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@test.com",
                            FirstName = "John",
                            LastName = "Doe",
                            Password = "123",
                            Points = 0,
                            Role = 0
                        },
                        new
                        {
                            Id = 2,
                            Email = "user@test.com",
                            FirstName = "Jane",
                            LastName = "Smith",
                            Password = "123",
                            Points = 0,
                            Role = 1
                        },
                        new
                        {
                            Id = 3,
                            Email = "markjohnson@example.com",
                            FirstName = "Mark",
                            LastName = "Johnson",
                            Password = "password",
                            Points = 0,
                            Role = 1
                        },
                        new
                        {
                            Id = 4,
                            Email = "sarahlee@example.com",
                            FirstName = "Sarah",
                            LastName = "Lee",
                            Password = "password",
                            Points = 0,
                            Role = 0
                        });
                });

            modelBuilder.Entity("Repository.Models.UserQuest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProofOfCompletion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserQuests");
                });

            modelBuilder.Entity("BadgeUser", b =>
                {
                    b.HasOne("Repository.Models.Badge", null)
                        .WithMany()
                        .HasForeignKey("BadgesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repository.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
