using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HATC_CapstoneProject.Migrations
{
    public partial class tablelistitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StringListItem_DowntimeTableRow_DowntimeTableRowId",
                table: "StringListItem");

            migrationBuilder.DropIndex(
                name: "IX_StringListItem_DowntimeTableRowId",
                table: "StringListItem");

            migrationBuilder.DropColumn(
                name: "DowntimeTableRowId",
                table: "StringListItem");

            migrationBuilder.CreateTable(
                name: "TableListItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Item = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TableListItem_DowntimeTableRowId",
                table: "TableListItem",
                column: "DowntimeTableRowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableListItem");

            migrationBuilder.AddColumn<int>(
                name: "DowntimeTableRowId",
                table: "StringListItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StringListItem_DowntimeTableRowId",
                table: "StringListItem",
                column: "DowntimeTableRowId");

            migrationBuilder.AddForeignKey(
                name: "FK_StringListItem_DowntimeTableRow_DowntimeTableRowId",
                table: "StringListItem",
                column: "DowntimeTableRowId",
                principalTable: "DowntimeTableRow",
                principalColumn: "Id");
        }
    }
}
