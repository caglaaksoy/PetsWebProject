using Microsoft.EntityFrameworkCore.Migrations;

namespace PetsProject.DataAccessLayer.Migrations
{
    public partial class mig28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Petss",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Owners",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Petss_AppUserId",
                table: "Petss",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_AppUserId",
                table: "Owners",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_AspNetUsers_AppUserId",
                table: "Owners",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Petss_AspNetUsers_AppUserId",
                table: "Petss",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_AspNetUsers_AppUserId",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_Petss_AspNetUsers_AppUserId",
                table: "Petss");

            migrationBuilder.DropIndex(
                name: "IX_Petss_AppUserId",
                table: "Petss");

            migrationBuilder.DropIndex(
                name: "IX_Owners_AppUserId",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Petss");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Owners");
        }
    }
}
