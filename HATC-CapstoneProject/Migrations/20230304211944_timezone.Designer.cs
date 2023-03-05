﻿// <auto-generated />
using System;
using HATC_CapstoneProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HATC_CapstoneProject.Migrations
{
    [DbContext(typeof(HavenDbContext))]
    [Migration("20230304211944_timezone")]
    partial class timezone
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HATC_CapstoneProject.Models.Achievement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Benefit")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Criteria")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("DowntimeId")
                        .HasColumnType("int");

                    b.Property<int>("Goal")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Progress")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("DowntimeId");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.AchievementAdvancement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AchieveId")
                        .HasColumnType("int");

                    b.Property<int>("Advancement")
                        .HasColumnType("int");

                    b.Property<int?>("SessionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AchieveId");

                    b.HasIndex("SessionId");

                    b.ToTable("AchievementAdvancement");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("Downtime")
                        .HasColumnType("int");

                    b.Property<int>("Exp")
                        .HasColumnType("int");

                    b.Property<int>("FactionPointsId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<string>("PlayerId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("SessionId")
                        .HasColumnType("int");

                    b.Property<bool>("isRetired")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("FactionPointsId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("SessionId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.Downtime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Downtime");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.Faction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Factions");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.FactionCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("SessionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("FactionCard");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.FactionCardEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FacId")
                        .HasColumnType("int");

                    b.Property<int?>("FactionCardId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FacId");

                    b.HasIndex("FactionCardId");

                    b.ToTable("FactionCardEntry");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.NPC", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apperance")
                        .HasColumnType("longtext");

                    b.Property<string>("Background")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int?>("FactionId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<string>("Interactions")
                        .HasColumnType("longtext");

                    b.Property<string>("Motivation")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Notes")
                        .HasColumnType("longtext");

                    b.Property<string>("Personality")
                        .HasColumnType("longtext");

                    b.Property<string>("Quirk")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("FactionId");

                    b.ToTable("NPC");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.Rank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Rank");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.RPEXP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CharId")
                        .HasColumnType("int");

                    b.Property<int?>("SessionId")
                        .HasColumnType("int");

                    b.Property<int>("TraitResolved")
                        .HasColumnType("int");

                    b.Property<bool>("isResolved")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("CharId");

                    b.HasIndex("SessionId");

                    b.ToTable("RPEXP");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DowntimeReward")
                        .HasColumnType("int");

                    b.Property<int>("GMCharacterId")
                        .HasColumnType("int");

                    b.Property<string>("InGameDate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("RealDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("GMCharacterId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.SessionItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("SessionId")
                        .HasColumnType("int");

                    b.Property<int?>("SessionId1")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.HasIndex("SessionId1");

                    b.ToTable("SessionItem");

                    b.HasDiscriminator<string>("Discriminator").HasValue("SessionItem");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.StringListItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("DowntimeId")
                        .HasColumnType("int");

                    b.Property<int?>("DowntimeId1")
                        .HasColumnType("int");

                    b.Property<int?>("NPCId")
                        .HasColumnType("int");

                    b.Property<int?>("NPCId1")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DowntimeId");

                    b.HasIndex("DowntimeId1");

                    b.HasIndex("NPCId");

                    b.HasIndex("NPCId1");

                    b.ToTable("StringListItem");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.Trigger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Accomidation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PlayerId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Trigger");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.Item", b =>
                {
                    b.HasBaseType("HATC_CapstoneProject.Models.SessionItem");

                    b.Property<string>("Fate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("SessionId2")
                        .HasColumnType("int")
                        .HasColumnName("Item_SessionId2");

                    b.HasIndex("SessionId2");

                    b.HasDiscriminator().HasValue("Item");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.Monster", b =>
                {
                    b.HasBaseType("HATC_CapstoneProject.Models.SessionItem");

                    b.Property<int?>("SessionId2")
                        .HasColumnType("int");

                    b.HasIndex("SessionId2");

                    b.HasDiscriminator().HasValue("Monster");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.Player", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("PreferedName")
                        .HasColumnType("longtext");

                    b.Property<string>("Pronouns")
                        .HasColumnType("longtext");

                    b.Property<string>("TimeZone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("Player");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.ShopItem", b =>
                {
                    b.HasBaseType("HATC_CapstoneProject.Models.SessionItem");

                    b.Property<string>("BanReason")
                        .HasColumnType("longtext");

                    b.Property<int>("ManualWeight")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("longtext");

                    b.Property<string>("PriceAdjustment")
                        .HasColumnType("longtext");

                    b.Property<int>("RarityId")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .HasColumnType("longtext");

                    b.Property<bool>("isAttunement")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isCraftable")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isShoppable")
                        .HasColumnType("tinyint(1)");

                    b.HasIndex("RarityId");

                    b.HasDiscriminator().HasValue("ShopItem");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.Achievement", b =>
                {
                    b.HasOne("HATC_CapstoneProject.Models.Downtime", null)
                        .WithMany("Achievements")
                        .HasForeignKey("DowntimeId");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.AchievementAdvancement", b =>
                {
                    b.HasOne("HATC_CapstoneProject.Models.Achievement", "Achieve")
                        .WithMany()
                        .HasForeignKey("AchieveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HATC_CapstoneProject.Models.Session", null)
                        .WithMany("Achievements")
                        .HasForeignKey("SessionId");

                    b.Navigation("Achieve");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.Character", b =>
                {
                    b.HasOne("HATC_CapstoneProject.Models.FactionCard", "FactionPoints")
                        .WithMany()
                        .HasForeignKey("FactionPointsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HATC_CapstoneProject.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HATC_CapstoneProject.Models.Session", null)
                        .WithMany("Characters")
                        .HasForeignKey("SessionId");

                    b.Navigation("FactionPoints");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.FactionCard", b =>
                {
                    b.HasOne("HATC_CapstoneProject.Models.Session", null)
                        .WithMany("FactionRenown")
                        .HasForeignKey("SessionId");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.FactionCardEntry", b =>
                {
                    b.HasOne("HATC_CapstoneProject.Models.Faction", "Fac")
                        .WithMany()
                        .HasForeignKey("FacId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HATC_CapstoneProject.Models.FactionCard", null)
                        .WithMany("FactionPoints")
                        .HasForeignKey("FactionCardId");

                    b.Navigation("Fac");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.NPC", b =>
                {
                    b.HasOne("HATC_CapstoneProject.Models.Faction", null)
                        .WithMany("Members")
                        .HasForeignKey("FactionId");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.RPEXP", b =>
                {
                    b.HasOne("HATC_CapstoneProject.Models.Character", "Char")
                        .WithMany()
                        .HasForeignKey("CharId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HATC_CapstoneProject.Models.Session", null)
                        .WithMany("RolePlayExp")
                        .HasForeignKey("SessionId");

                    b.Navigation("Char");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.Session", b =>
                {
                    b.HasOne("HATC_CapstoneProject.Models.Character", "GMCharacter")
                        .WithMany()
                        .HasForeignKey("GMCharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GMCharacter");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.SessionItem", b =>
                {
                    b.HasOne("HATC_CapstoneProject.Models.Session", null)
                        .WithMany("AdHocItems")
                        .HasForeignKey("SessionId");

                    b.HasOne("HATC_CapstoneProject.Models.Session", null)
                        .WithMany("TreasureList")
                        .HasForeignKey("SessionId1");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.StringListItem", b =>
                {
                    b.HasOne("HATC_CapstoneProject.Models.Downtime", null)
                        .WithMany("Resolution")
                        .HasForeignKey("DowntimeId");

                    b.HasOne("HATC_CapstoneProject.Models.Downtime", null)
                        .WithMany("Resources")
                        .HasForeignKey("DowntimeId1");

                    b.HasOne("HATC_CapstoneProject.Models.NPC", null)
                        .WithMany("AdventureHooks")
                        .HasForeignKey("NPCId");

                    b.HasOne("HATC_CapstoneProject.Models.NPC", null)
                        .WithMany("Stats")
                        .HasForeignKey("NPCId1");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.Trigger", b =>
                {
                    b.HasOne("HATC_CapstoneProject.Models.Player", null)
                        .WithMany("Triggers")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.Item", b =>
                {
                    b.HasOne("HATC_CapstoneProject.Models.Session", null)
                        .WithMany("Loot")
                        .HasForeignKey("SessionId2");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.Monster", b =>
                {
                    b.HasOne("HATC_CapstoneProject.Models.Session", null)
                        .WithMany("CombatItems")
                        .HasForeignKey("SessionId2");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.ShopItem", b =>
                {
                    b.HasOne("HATC_CapstoneProject.Models.Rank", "Rarity")
                        .WithMany()
                        .HasForeignKey("RarityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rarity");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.Downtime", b =>
                {
                    b.Navigation("Achievements");

                    b.Navigation("Resolution");

                    b.Navigation("Resources");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.Faction", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.FactionCard", b =>
                {
                    b.Navigation("FactionPoints");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.NPC", b =>
                {
                    b.Navigation("AdventureHooks");

                    b.Navigation("Stats");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.Session", b =>
                {
                    b.Navigation("Achievements");

                    b.Navigation("AdHocItems");

                    b.Navigation("Characters");

                    b.Navigation("CombatItems");

                    b.Navigation("FactionRenown");

                    b.Navigation("Loot");

                    b.Navigation("RolePlayExp");

                    b.Navigation("TreasureList");
                });

            modelBuilder.Entity("HATC_CapstoneProject.Models.Player", b =>
                {
                    b.Navigation("Triggers");
                });
#pragma warning restore 612, 618
        }
    }
}
