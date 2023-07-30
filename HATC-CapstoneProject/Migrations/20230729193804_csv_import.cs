using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HATC_CapstoneProject.Migrations
{
    /// <inheritdoc />
    public partial class csv_import : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PreferedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscordName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pronouns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeZone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordReset = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Downtime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Downtime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BgColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ranking = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trigger",
                columns: table => new
                {
                    TriggerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accomidation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trigger", x => x.TriggerId);
                    table.ForeignKey(
                        name: "FK_Trigger_AspNetUsers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DowntimeTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsComplication = table.Column<bool>(type: "bit", nullable: false),
                    HasHead = table.Column<bool>(type: "bit", nullable: false),
                    DowntimeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DowntimeTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DowntimeTable_Downtime_DowntimeId",
                        column: x => x.DowntimeId,
                        principalTable: "Downtime",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FactionPerk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Renown = table.Column<int>(type: "int", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactionPerk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactionPerk_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FactionShop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    FactionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactionShop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactionShop_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NPC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Motivation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apperance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Background = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quirk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NPC_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    IsUnlocked = table.Column<bool>(type: "bit", nullable: false),
                    IsMasked = table.Column<bool>(type: "bit", nullable: false),
                    Benefit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DowntimeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Achievements_Downtime_DowntimeId",
                        column: x => x.DowntimeId,
                        principalTable: "Downtime",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Achievements_Ranks_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Ranks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DowntimeTableRow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DowntimeTableId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DowntimeTableRow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DowntimeTableRow_DowntimeTable_DowntimeTableId",
                        column: x => x.DowntimeTableId,
                        principalTable: "DowntimeTable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StringListItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DowntimeId = table.Column<int>(type: "int", nullable: true),
                    DowntimeId1 = table.Column<int>(type: "int", nullable: true),
                    FactionShopId = table.Column<int>(type: "int", nullable: true),
                    NPCId = table.Column<int>(type: "int", nullable: true),
                    NPCId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StringListItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StringListItem_Downtime_DowntimeId",
                        column: x => x.DowntimeId,
                        principalTable: "Downtime",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StringListItem_Downtime_DowntimeId1",
                        column: x => x.DowntimeId1,
                        principalTable: "Downtime",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StringListItem_FactionShop_FactionShopId",
                        column: x => x.FactionShopId,
                        principalTable: "FactionShop",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StringListItem_NPC_NPCId",
                        column: x => x.NPCId,
                        principalTable: "NPC",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StringListItem_NPC_NPCId1",
                        column: x => x.NPCId1,
                        principalTable: "NPC",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AchievementProgress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Criteria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Goal = table.Column<int>(type: "int", nullable: false),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    AchievementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AchievementProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AchievementProgress_Achievements_AchievementId",
                        column: x => x.AchievementId,
                        principalTable: "Achievements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TableListItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DowntimeTableRowId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableListItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableListItem_DowntimeTableRow_DowntimeTableRowId",
                        column: x => x.DowntimeTableRowId,
                        principalTable: "DowntimeTableRow",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AchievementAdvancement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AchieveId = table.Column<int>(type: "int", nullable: false),
                    Advancement = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AchievementAdvancement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AchievementAdvancement_Achievements_AchieveId",
                        column: x => x.AchieveId,
                        principalTable: "Achievements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exp = table.Column<int>(type: "int", nullable: false),
                    Downtime = table.Column<int>(type: "int", nullable: false),
                    FactionPointsId = table.Column<int>(type: "int", nullable: false),
                    isRetired = table.Column<bool>(type: "bit", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_AspNetUsers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RealDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InGameDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GMCharacterId = table.Column<int>(type: "int", nullable: false),
                    DowntimeReward = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Characters_GMCharacterId",
                        column: x => x.GMCharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactionCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactionCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactionCard_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RPEXP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharId = table.Column<int>(type: "int", nullable: false),
                    TraitResolved = table.Column<int>(type: "int", nullable: false),
                    isResolved = table.Column<bool>(type: "bit", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RPEXP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RPEXP_Characters_CharId",
                        column: x => x.CharId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RPEXP_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SessionItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: true),
                    SessionId1 = table.Column<int>(type: "int", nullable: true),
                    Fate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Item_SessionId2 = table.Column<int>(type: "int", nullable: true),
                    SessionId2 = table.Column<int>(type: "int", nullable: true),
                    PriceAdjustment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RarityId = table.Column<int>(type: "int", nullable: true),
                    BanReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManualWeight = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAttunement = table.Column<bool>(type: "bit", nullable: true),
                    IsShoppable = table.Column<bool>(type: "bit", nullable: true),
                    IsCraftable = table.Column<bool>(type: "bit", nullable: true),
                    LinkTo5eTools = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionItem_Ranks_RarityId",
                        column: x => x.RarityId,
                        principalTable: "Ranks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionItem_Sessions_Item_SessionId2",
                        column: x => x.Item_SessionId2,
                        principalTable: "Sessions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SessionItem_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SessionItem_Sessions_SessionId1",
                        column: x => x.SessionId1,
                        principalTable: "Sessions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SessionItem_Sessions_SessionId2",
                        column: x => x.SessionId2,
                        principalTable: "Sessions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FactionCardEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    FactionCardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactionCardEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactionCardEntry_FactionCard_FactionCardId",
                        column: x => x.FactionCardId,
                        principalTable: "FactionCard",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FactionCardEntry_Factions_FacId",
                        column: x => x.FacId,
                        principalTable: "Factions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AchievementAdvancement_AchieveId",
                table: "AchievementAdvancement",
                column: "AchieveId");

            migrationBuilder.CreateIndex(
                name: "IX_AchievementAdvancement_SessionId",
                table: "AchievementAdvancement",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AchievementProgress_AchievementId",
                table: "AchievementProgress",
                column: "AchievementId");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_DowntimeId",
                table: "Achievements",
                column: "DowntimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_LevelId",
                table: "Achievements",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_FactionPointsId",
                table: "Characters",
                column: "FactionPointsId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PlayerId",
                table: "Characters",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SessionId",
                table: "Characters",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_DowntimeTable_DowntimeId",
                table: "DowntimeTable",
                column: "DowntimeId");

            migrationBuilder.CreateIndex(
                name: "IX_DowntimeTableRow_DowntimeTableId",
                table: "DowntimeTableRow",
                column: "DowntimeTableId");

            migrationBuilder.CreateIndex(
                name: "IX_FactionCard_SessionId",
                table: "FactionCard",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_FactionCardEntry_FacId",
                table: "FactionCardEntry",
                column: "FacId");

            migrationBuilder.CreateIndex(
                name: "IX_FactionCardEntry_FactionCardId",
                table: "FactionCardEntry",
                column: "FactionCardId");

            migrationBuilder.CreateIndex(
                name: "IX_FactionPerk_FactionId",
                table: "FactionPerk",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_FactionShop_FactionId",
                table: "FactionShop",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_NPC_FactionId",
                table: "NPC",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_RPEXP_CharId",
                table: "RPEXP",
                column: "CharId");

            migrationBuilder.CreateIndex(
                name: "IX_RPEXP_SessionId",
                table: "RPEXP",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionItem_Item_SessionId2",
                table: "SessionItem",
                column: "Item_SessionId2");

            migrationBuilder.CreateIndex(
                name: "IX_SessionItem_RarityId",
                table: "SessionItem",
                column: "RarityId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionItem_SessionId",
                table: "SessionItem",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionItem_SessionId1",
                table: "SessionItem",
                column: "SessionId1");

            migrationBuilder.CreateIndex(
                name: "IX_SessionItem_SessionId2",
                table: "SessionItem",
                column: "SessionId2");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_GMCharacterId",
                table: "Sessions",
                column: "GMCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_StringListItem_DowntimeId",
                table: "StringListItem",
                column: "DowntimeId");

            migrationBuilder.CreateIndex(
                name: "IX_StringListItem_DowntimeId1",
                table: "StringListItem",
                column: "DowntimeId1");

            migrationBuilder.CreateIndex(
                name: "IX_StringListItem_FactionShopId",
                table: "StringListItem",
                column: "FactionShopId");

            migrationBuilder.CreateIndex(
                name: "IX_StringListItem_NPCId",
                table: "StringListItem",
                column: "NPCId");

            migrationBuilder.CreateIndex(
                name: "IX_StringListItem_NPCId1",
                table: "StringListItem",
                column: "NPCId1");

            migrationBuilder.CreateIndex(
                name: "IX_TableListItem_DowntimeTableRowId",
                table: "TableListItem",
                column: "DowntimeTableRowId");

            migrationBuilder.CreateIndex(
                name: "IX_Trigger_PlayerId",
                table: "Trigger",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AchievementAdvancement_Sessions_SessionId",
                table: "AchievementAdvancement",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_FactionCard_FactionPointsId",
                table: "Characters",
                column: "FactionPointsId",
                principalTable: "FactionCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Sessions_SessionId",
                table: "Characters",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Sessions_SessionId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_FactionCard_Sessions_SessionId",
                table: "FactionCard");

            migrationBuilder.DropTable(
                name: "AchievementAdvancement");

            migrationBuilder.DropTable(
                name: "AchievementProgress");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FactionCardEntry");

            migrationBuilder.DropTable(
                name: "FactionPerk");

            migrationBuilder.DropTable(
                name: "RPEXP");

            migrationBuilder.DropTable(
                name: "SessionItem");

            migrationBuilder.DropTable(
                name: "StringListItem");

            migrationBuilder.DropTable(
                name: "TableListItem");

            migrationBuilder.DropTable(
                name: "Trigger");

            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "FactionShop");

            migrationBuilder.DropTable(
                name: "NPC");

            migrationBuilder.DropTable(
                name: "DowntimeTableRow");

            migrationBuilder.DropTable(
                name: "Ranks");

            migrationBuilder.DropTable(
                name: "Factions");

            migrationBuilder.DropTable(
                name: "DowntimeTable");

            migrationBuilder.DropTable(
                name: "Downtime");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "FactionCard");
        }
    }
}
