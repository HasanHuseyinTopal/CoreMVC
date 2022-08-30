using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mg3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_writers_City_CityID",
                table: "writers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "cities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cities",
                table: "cities",
                column: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_writers_cities_CityID",
                table: "writers",
                column: "CityID",
                principalTable: "cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_writers_cities_CityID",
                table: "writers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cities",
                table: "cities");

            migrationBuilder.RenameTable(
                name: "cities",
                newName: "City");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_writers_City_CityID",
                table: "writers",
                column: "CityID",
                principalTable: "City",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
