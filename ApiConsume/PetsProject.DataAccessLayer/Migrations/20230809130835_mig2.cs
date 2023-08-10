using Microsoft.EntityFrameworkCore.Migrations;

namespace PetsProject.DataAccessLayer.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Owners");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Owners",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
