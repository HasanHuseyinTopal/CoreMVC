using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mg6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dateTime",
                table: "contacts",
                newName: "ContactDateTime");

            migrationBuilder.AddColumn<int>(
                name: "BlogScore",
                table: "comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogScore",
                table: "comments");

            migrationBuilder.RenameColumn(
                name: "ContactDateTime",
                table: "contacts",
                newName: "dateTime");
        }
    }
}
