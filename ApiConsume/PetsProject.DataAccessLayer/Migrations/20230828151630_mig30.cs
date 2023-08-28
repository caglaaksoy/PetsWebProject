using Microsoft.EntityFrameworkCore.Migrations;

namespace PetsProject.DataAccessLayer.Migrations
{
    public partial class mig30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Petss_Breed_BreedID",
                table: "Petss");

            migrationBuilder.DropForeignKey(
                name: "FK_Petss_Type_TypeID",
                table: "Petss");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Breed",
                table: "Breed");

            migrationBuilder.RenameTable(
                name: "Breed",
                newName: "Breeds");

            migrationBuilder.RenameColumn(
                name: "TypeID",
                table: "Petss",
                newName: "PetTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Petss_TypeID",
                table: "Petss",
                newName: "IX_Petss_PetTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Breeds",
                table: "Breeds",
                column: "BreedID");

            migrationBuilder.CreateTable(
                name: "PetTypes",
                columns: table => new
                {
                    PetTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetTypes", x => x.PetTypeID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Petss_Breeds_BreedID",
                table: "Petss",
                column: "BreedID",
                principalTable: "Breeds",
                principalColumn: "BreedID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Petss_PetTypes_PetTypeID",
                table: "Petss",
                column: "PetTypeID",
                principalTable: "PetTypes",
                principalColumn: "PetTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Petss_Breeds_BreedID",
                table: "Petss");

            migrationBuilder.DropForeignKey(
                name: "FK_Petss_PetTypes_PetTypeID",
                table: "Petss");

            migrationBuilder.DropTable(
                name: "PetTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Breeds",
                table: "Breeds");

            migrationBuilder.RenameTable(
                name: "Breeds",
                newName: "Breed");

            migrationBuilder.RenameColumn(
                name: "PetTypeID",
                table: "Petss",
                newName: "TypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Petss_PetTypeID",
                table: "Petss",
                newName: "IX_Petss_TypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Breed",
                table: "Breed",
                column: "BreedID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Petss_Breed_BreedID",
                table: "Petss",
                column: "BreedID",
                principalTable: "Breed",
                principalColumn: "BreedID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Petss_Type_TypeID",
                table: "Petss",
                column: "TypeID",
                principalTable: "Type",
                principalColumn: "TypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
