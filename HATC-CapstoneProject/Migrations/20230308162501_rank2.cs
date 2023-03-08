using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HATC_CapstoneProject.Migrations
{
    public partial class rank2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Achievements",
                newName: "IsUnlocked");

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Achievements",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Achievements");

            migrationBuilder.RenameColumn(
                name: "IsUnlocked",
                table: "Achievements",
                newName: "Status");
        }
    }
}
