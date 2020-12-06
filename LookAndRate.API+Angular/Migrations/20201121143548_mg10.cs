using Microsoft.EntityFrameworkCore.Migrations;

namespace LookAndRate.API_Angular.Migrations
{
    public partial class mg10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblPhotos_tblActors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "tblActors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblPhotos_ActorId",
                table: "tblPhotos",
                column: "ActorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblPhotos");
        }
    }
}
