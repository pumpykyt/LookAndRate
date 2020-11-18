using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_P34.API_Angular.Migrations
{
    public partial class mg4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountEpisodes",
                table: "tblMovies");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "tblMovies",
                newName: "Slogan");

            migrationBuilder.AddColumn<string>(
                name: "Composer",
                table: "tblMovies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "tblMovies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "tblMovies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "tblMovies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Operator",
                table: "tblMovies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginalName",
                table: "tblMovies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Composer",
                table: "tblMovies");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "tblMovies");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "tblMovies");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "tblMovies");

            migrationBuilder.DropColumn(
                name: "Operator",
                table: "tblMovies");

            migrationBuilder.DropColumn(
                name: "OriginalName",
                table: "tblMovies");

            migrationBuilder.RenameColumn(
                name: "Slogan",
                table: "tblMovies",
                newName: "Type");

            migrationBuilder.AddColumn<int>(
                name: "CountEpisodes",
                table: "tblMovies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
