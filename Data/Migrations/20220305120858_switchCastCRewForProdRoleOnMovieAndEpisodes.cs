using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMDB.Data.Migrations
{
    public partial class switchCastCRewForProdRoleOnMovieAndEpisodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CastCrewMember_Episodes_EpisodeId",
                table: "CastCrewMember");

            migrationBuilder.DropForeignKey(
                name: "FK_CastCrewMember_Movies_MovieId",
                table: "CastCrewMember");

            migrationBuilder.DropIndex(
                name: "IX_CastCrewMember_EpisodeId",
                table: "CastCrewMember");

            migrationBuilder.DropIndex(
                name: "IX_CastCrewMember_MovieId",
                table: "CastCrewMember");

            migrationBuilder.DropColumn(
                name: "EpisodeId",
                table: "CastCrewMember");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "CastCrewMember");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EpisodeId",
                table: "CastCrewMember",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "CastCrewMember",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CastCrewMember_EpisodeId",
                table: "CastCrewMember",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CastCrewMember_MovieId",
                table: "CastCrewMember",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_CastCrewMember_Episodes_EpisodeId",
                table: "CastCrewMember",
                column: "EpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CastCrewMember_Movies_MovieId",
                table: "CastCrewMember",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
