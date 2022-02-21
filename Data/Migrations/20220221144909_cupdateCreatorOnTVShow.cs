using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMDB.Data.Migrations
{
    public partial class cupdateCreatorOnTVShow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creator",
                table: "TVShows");

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "TVShows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TVShows_CreatorId",
                table: "TVShows",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TVShows_CastCrewMember_CreatorId",
                table: "TVShows",
                column: "CreatorId",
                principalTable: "CastCrewMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TVShows_CastCrewMember_CreatorId",
                table: "TVShows");

            migrationBuilder.DropIndex(
                name: "IX_TVShows_CreatorId",
                table: "TVShows");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "TVShows");

            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "TVShows",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
