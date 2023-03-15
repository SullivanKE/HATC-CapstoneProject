using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HATC_CapstoneProject.Migrations
{
    public partial class cleanerdowntime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DowntimeTable_Downtime_DowntimeParentId",
                table: "DowntimeTable");

            migrationBuilder.DropIndex(
                name: "IX_DowntimeTable_DowntimeParentId",
                table: "DowntimeTable");

            migrationBuilder.DropColumn(
                name: "DowntimeParentId",
                table: "DowntimeTable");

            migrationBuilder.AddColumn<int>(
                name: "DowntimeId",
                table: "DowntimeTable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DowntimeTable_DowntimeId",
                table: "DowntimeTable",
                column: "DowntimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DowntimeTable_Downtime_DowntimeId",
                table: "DowntimeTable",
                column: "DowntimeId",
                principalTable: "Downtime",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DowntimeTable_Downtime_DowntimeId",
                table: "DowntimeTable");

            migrationBuilder.DropIndex(
                name: "IX_DowntimeTable_DowntimeId",
                table: "DowntimeTable");

            migrationBuilder.DropColumn(
                name: "DowntimeId",
                table: "DowntimeTable");

            migrationBuilder.AddColumn<int>(
                name: "DowntimeParentId",
                table: "DowntimeTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DowntimeTable_DowntimeParentId",
                table: "DowntimeTable",
                column: "DowntimeParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DowntimeTable_Downtime_DowntimeParentId",
                table: "DowntimeTable",
                column: "DowntimeParentId",
                principalTable: "Downtime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
