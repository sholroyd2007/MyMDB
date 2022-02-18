using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMDB.Data.Migrations
{
    public partial class updateModelLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Ratings_EpisodeId",
                table: "Ratings",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_CharacterId",
                table: "Quotes",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_EpisodeId",
                table: "Quotes",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_MovieId",
                table: "Quotes",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_EpisodeId",
                table: "Characters",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_MovieId",
                table: "Characters",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Episodes_EpisodeId",
                table: "Characters",
                column: "EpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Movies_MovieId",
                table: "Characters",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Characters_CharacterId",
                table: "Quotes",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Episodes_EpisodeId",
                table: "Quotes",
                column: "EpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Movies_MovieId",
                table: "Quotes",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Episodes_EpisodeId",
                table: "Ratings",
                column: "EpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Episodes_EpisodeId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Movies_MovieId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Characters_CharacterId",
                table: "Quotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Episodes_EpisodeId",
                table: "Quotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Movies_MovieId",
                table: "Quotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Episodes_EpisodeId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_EpisodeId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_CharacterId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_EpisodeId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_MovieId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Characters_EpisodeId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_MovieId",
                table: "Characters");
        }
    }
}
