using Microsoft.EntityFrameworkCore.Migrations;

namespace LookAndRate.API_Angular.Migrations
{
    public partial class mg9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BirthYear",
                table: "tblActors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CountFilms",
                table: "tblActors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "tblActors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "tblActors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthYear",
                table: "tblActors");

            migrationBuilder.DropColumn(
                name: "CountFilms",
                table: "tblActors");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "tblActors");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "tblActors");
        }
    }
}
