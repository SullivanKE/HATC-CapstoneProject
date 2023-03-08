using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HATC_CapstoneProject.Migrations
{
    public partial class ranks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionItem_Rank_RarityId",
                table: "SessionItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rank",
                table: "Rank");

            migrationBuilder.RenameTable(
                name: "Rank",
                newName: "Ranks");

            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "Achievements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BgColor",
                table: "Ranks",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ranks",
                table: "Ranks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_LevelId",
                table: "Achievements",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_Ranks_LevelId",
                table: "Achievements",
                column: "LevelId",
                principalTable: "Ranks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionItem_Ranks_RarityId",
                table: "SessionItem",
                column: "RarityId",
                principalTable: "Ranks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_Ranks_LevelId",
                table: "Achievements");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionItem_Ranks_RarityId",
                table: "SessionItem");

            migrationBuilder.DropIndex(
                name: "IX_Achievements_LevelId",
                table: "Achievements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ranks",
                table: "Ranks");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "BgColor",
                table: "Ranks");

            migrationBuilder.RenameTable(
                name: "Ranks",
                newName: "Rank");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rank",
                table: "Rank",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionItem_Rank_RarityId",
                table: "SessionItem",
                column: "RarityId",
                principalTable: "Rank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
