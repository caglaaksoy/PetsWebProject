using Microsoft.EntityFrameworkCore.Migrations;

namespace PetsProject.DataAccessLayer.Migrations
{
    public partial class breedaddpet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BreedID",
                table: "Petss",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Breed",
                columns: table => new
                {
                    BreedID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreedName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breed", x => x.BreedID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Petss_BreedID",
                table: "Petss",
                column: "BreedID");

            migrationBuilder.AddForeignKey(
                name: "FK_Petss_Breed_BreedID",
                table: "Petss",
                column: "BreedID",
                principalTable: "Breed",
                principalColumn: "BreedID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Petss_Breed_BreedID",
                table: "Petss");

            migrationBuilder.DropTable(
                name: "Breed");

            migrationBuilder.DropIndex(
                name: "IX_Petss_BreedID",
                table: "Petss");

            migrationBuilder.DropColumn(
                name: "BreedID",
                table: "Petss");
        }
    }
}
