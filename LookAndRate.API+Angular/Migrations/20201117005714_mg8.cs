using Microsoft.EntityFrameworkCore.Migrations;

namespace LookAndRate.API_Angular.Migrations
{
    public partial class mg8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "tblReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblReviews_MovieId",
                table: "tblReviews",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblReviews_tblMovies_MovieId",
                table: "tblReviews",
                column: "MovieId",
                principalTable: "tblMovies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblReviews_tblMovies_MovieId",
                table: "tblReviews");

            migrationBuilder.DropIndex(
                name: "IX_tblReviews_MovieId",
                table: "tblReviews");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "tblReviews");
        }
    }
}
