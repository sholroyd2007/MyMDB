using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMDB.Data.Migrations
{
    public partial class addCategoriesToArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ListArticleId",
                table: "MovieStudios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListArticleId",
                table: "MovieSeries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListArticleId",
                table: "Awards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AwardId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CastCrewMemberId",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EpisodeId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieSeriesId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieStudioId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TVShowId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieStudios_ListArticleId",
                table: "MovieStudios",
                column: "ListArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSeries_ListArticleId",
                table: "MovieSeries",
                column: "ListArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_ListArticleId",
                table: "Awards",
                column: "ListArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AwardId",
                table: "Articles",
                column: "AwardId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CastCrewMemberId",
                table: "Articles",
                column: "CastCrewMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CharacterId",
                table: "Articles",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_EpisodeId",
                table: "Articles",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_MovieId",
                table: "Articles",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_MovieSeriesId",
                table: "Articles",
                column: "MovieSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_MovieStudioId",
                table: "Articles",
                column: "MovieStudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_TVShowId",
                table: "Articles",
                column: "TVShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Awards_AwardId",
                table: "Articles",
                column: "AwardId",
                principalTable: "Awards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_CastCrewMember_CastCrewMemberId",
                table: "Articles",
                column: "CastCrewMemberId",
                principalTable: "CastCrewMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Characters_CharacterId",
                table: "Articles",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Episodes_EpisodeId",
                table: "Articles",
                column: "EpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Movies_MovieId",
                table: "Articles",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_MovieSeries_MovieSeriesId",
                table: "Articles",
                column: "MovieSeriesId",
                principalTable: "MovieSeries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_MovieStudios_MovieStudioId",
                table: "Articles",
                column: "MovieStudioId",
                principalTable: "MovieStudios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_TVShows_TVShowId",
                table: "Articles",
                column: "TVShowId",
                principalTable: "TVShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_ListArticles_ListArticleId",
                table: "Awards",
                column: "ListArticleId",
                principalTable: "ListArticles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSeries_ListArticles_ListArticleId",
                table: "MovieSeries",
                column: "ListArticleId",
                principalTable: "ListArticles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieStudios_ListArticles_ListArticleId",
                table: "MovieStudios",
                column: "ListArticleId",
                principalTable: "ListArticles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Awards_AwardId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_CastCrewMember_CastCrewMemberId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Characters_CharacterId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Episodes_EpisodeId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Movies_MovieId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_MovieSeries_MovieSeriesId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_MovieStudios_MovieStudioId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_TVShows_TVShowId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Awards_ListArticles_ListArticleId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieSeries_ListArticles_ListArticleId",
                table: "MovieSeries");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieStudios_ListArticles_ListArticleId",
                table: "MovieStudios");

            migrationBuilder.DropIndex(
                name: "IX_MovieStudios_ListArticleId",
                table: "MovieStudios");

            migrationBuilder.DropIndex(
                name: "IX_MovieSeries_ListArticleId",
                table: "MovieSeries");

            migrationBuilder.DropIndex(
                name: "IX_Awards_ListArticleId",
                table: "Awards");

            migrationBuilder.DropIndex(
                name: "IX_Articles_AwardId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_CastCrewMemberId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_CharacterId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_EpisodeId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_MovieId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_MovieSeriesId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_MovieStudioId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_TVShowId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ListArticleId",
                table: "MovieStudios");

            migrationBuilder.DropColumn(
                name: "ListArticleId",
                table: "MovieSeries");

            migrationBuilder.DropColumn(
                name: "ListArticleId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "AwardId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "CastCrewMemberId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "EpisodeId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "MovieSeriesId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "MovieStudioId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "TVShowId",
                table: "Articles");
        }
    }
}
