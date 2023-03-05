using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HATC_CapstoneProject.Migrations
{
    public partial class timezone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trigger_AspNetUsers_AppUserId",
                table: "Trigger");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Trigger",
                newName: "PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Trigger_AppUserId",
                table: "Trigger",
                newName: "IX_Trigger_PlayerId");

            migrationBuilder.AddColumn<string>(
                name: "TimeZone",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Trigger_AspNetUsers_PlayerId",
                table: "Trigger",
                column: "PlayerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trigger_AspNetUsers_PlayerId",
                table: "Trigger");

            migrationBuilder.DropColumn(
                name: "TimeZone",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Trigger",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Trigger_PlayerId",
                table: "Trigger",
                newName: "IX_Trigger_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trigger_AspNetUsers_AppUserId",
                table: "Trigger",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
