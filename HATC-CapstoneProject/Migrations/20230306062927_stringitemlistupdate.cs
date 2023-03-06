using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HATC_CapstoneProject.Migrations
{
    public partial class stringitemlistupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "StringListItem");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "StringListItem",
                newName: "Item");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Item",
                table: "StringListItem",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "StringListItem",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
