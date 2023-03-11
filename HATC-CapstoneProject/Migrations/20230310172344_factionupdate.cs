using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HATC_CapstoneProject.Migrations
{
    public partial class factionupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Interactions",
                table: "NPC");

            migrationBuilder.AddColumn<int>(
                name: "FactionShopId",
                table: "StringListItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FactionPerk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Renown = table.Column<int>(type: "int", nullable: false),
                    Item = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FactionShop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_StringListItem_FactionShopId",
                table: "StringListItem",
                column: "FactionShopId");

            migrationBuilder.CreateIndex(
                name: "IX_FactionPerk_FactionId",
                table: "FactionPerk",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_FactionShop_FactionId",
                table: "FactionShop",
                column: "FactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_StringListItem_FactionShop_FactionShopId",
                table: "StringListItem",
                column: "FactionShopId",
                principalTable: "FactionShop",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StringListItem_FactionShop_FactionShopId",
                table: "StringListItem");

            migrationBuilder.DropTable(
                name: "FactionPerk");

            migrationBuilder.DropTable(
                name: "FactionShop");

            migrationBuilder.DropIndex(
                name: "IX_StringListItem_FactionShopId",
                table: "StringListItem");

            migrationBuilder.DropColumn(
                name: "FactionShopId",
                table: "StringListItem");

            migrationBuilder.AddColumn<string>(
                name: "Interactions",
                table: "NPC",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
