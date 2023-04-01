using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HATC_CapstoneProject.Migrations
{
    public partial class characters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiscordName",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscordName",
                table: "AspNetUsers");
        }
    }
}
