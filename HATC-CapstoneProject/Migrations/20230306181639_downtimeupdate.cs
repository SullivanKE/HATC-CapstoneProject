using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HATC_CapstoneProject.Migrations
{
    public partial class downtimeupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DowntimeTableRowId",
                table: "StringListItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DowntimeTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DowntimeParentId = table.Column<int>(type: "int", nullable: false),
                    IsComplication = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HasHead = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DowntimeTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DowntimeTable_Downtime_DowntimeParentId",
                        column: x => x.DowntimeParentId,
                        principalTable: "Downtime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DowntimeTableRow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_StringListItem_DowntimeTableRowId",
                table: "StringListItem",
                column: "DowntimeTableRowId");

            migrationBuilder.CreateIndex(
                name: "IX_DowntimeTable_DowntimeParentId",
                table: "DowntimeTable",
                column: "DowntimeParentId");

            migrationBuilder.CreateIndex(
                name: "IX_DowntimeTableRow_DowntimeTableId",
                table: "DowntimeTableRow",
                column: "DowntimeTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_StringListItem_DowntimeTableRow_DowntimeTableRowId",
                table: "StringListItem",
                column: "DowntimeTableRowId",
                principalTable: "DowntimeTableRow",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StringListItem_DowntimeTableRow_DowntimeTableRowId",
                table: "StringListItem");

            migrationBuilder.DropTable(
                name: "DowntimeTableRow");

            migrationBuilder.DropTable(
                name: "DowntimeTable");

            migrationBuilder.DropIndex(
                name: "IX_StringListItem_DowntimeTableRowId",
                table: "StringListItem");

            migrationBuilder.DropColumn(
                name: "DowntimeTableRowId",
                table: "StringListItem");
        }
    }
}
