using Microsoft.EntityFrameworkCore.Migrations;

namespace PetsProject.DataAccessLayer.Migrations
{
    public partial class typeaddpetss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_AspNetUsers_AppUserId",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Owners_AppUserId",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Owners");

            migrationBuilder.AddColumn<int>(
                name: "TypeID",
                table: "Petss",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    TypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.TypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Petss_TypeID",
                table: "Petss",
                column: "TypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Petss_Type_TypeID",
                table: "Petss",
                column: "TypeID",
                principalTable: "Type",
                principalColumn: "TypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Petss_Type_TypeID",
                table: "Petss");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Petss_TypeID",
                table: "Petss");

            migrationBuilder.DropColumn(
                name: "TypeID",
                table: "Petss");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Owners",
                type: "int",
                nullable: true);

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
        }
    }
}
