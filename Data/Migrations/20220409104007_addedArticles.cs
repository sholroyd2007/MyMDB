using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMDB.Data.Migrations
{
    public partial class addedArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AwardRecipient_AwardRecipient_AwardRecipientId",
                table: "AwardRecipient");

            migrationBuilder.DropForeignKey(
                name: "FK_AwardRecipient_Characters_CharacterId",
                table: "AwardRecipient");

            migrationBuilder.DropForeignKey(
                name: "FK_AwardRecipient_Genres_GenreId",
                table: "AwardRecipient");

            migrationBuilder.DropForeignKey(
                name: "FK_AwardRecipient_JobRoles_JobRoleId",
                table: "AwardRecipient");

            migrationBuilder.DropForeignKey(
                name: "FK_AwardRecipient_MovieSeries_MovieSeriesId",
                table: "AwardRecipient");

            migrationBuilder.DropForeignKey(
                name: "FK_AwardRecipient_MovieStudios_MovieStudioId",
                table: "AwardRecipient");

            migrationBuilder.DropForeignKey(
                name: "FK_AwardRecipient_ProductionRoles_ProductionRoleId",
                table: "AwardRecipient");

            migrationBuilder.DropForeignKey(
                name: "FK_AwardRecipient_Quotes_QuoteId",
                table: "AwardRecipient");

            migrationBuilder.DropForeignKey(
                name: "FK_AwardRecipient_Ratings_RatingId",
                table: "AwardRecipient");

            migrationBuilder.DropForeignKey(
                name: "FK_Facts_AwardCategories_AwardCategoryId",
                table: "Facts");

            migrationBuilder.DropForeignKey(
                name: "FK_Facts_AwardRecipient_AwardRecipientId",
                table: "Facts");

            migrationBuilder.DropForeignKey(
                name: "FK_Facts_Genres_GenreId",
                table: "Facts");

            migrationBuilder.DropForeignKey(
                name: "FK_Facts_JobRoles_JobRoleId",
                table: "Facts");

            migrationBuilder.DropForeignKey(
                name: "FK_Facts_MediaFiles_MediaFileId",
                table: "Facts");

            migrationBuilder.DropForeignKey(
                name: "FK_Facts_MovieStudios_MovieStudioId",
                table: "Facts");

            migrationBuilder.DropForeignKey(
                name: "FK_Facts_ProductionRoles_ProductionRoleId",
                table: "Facts");

            migrationBuilder.DropForeignKey(
                name: "FK_Facts_Quotes_QuoteId",
                table: "Facts");

            migrationBuilder.DropForeignKey(
                name: "FK_Facts_Ratings_RatingId",
                table: "Facts");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_AwardCategories_AwardCategoryId",
                table: "MediaFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_JobRoles_JobRoleId",
                table: "MediaFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_MediaFiles_MediaFileId",
                table: "MediaFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_ProductionRoles_ProductionRoleId",
                table: "MediaFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_Quotes_QuoteId",
                table: "MediaFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_Ratings_RatingId",
                table: "MediaFiles");

            migrationBuilder.DropTable(
                name: "AwardRecipientMediaFile");

            migrationBuilder.DropIndex(
                name: "IX_MediaFiles_AwardCategoryId",
                table: "MediaFiles");

            migrationBuilder.DropIndex(
                name: "IX_MediaFiles_JobRoleId",
                table: "MediaFiles");

            migrationBuilder.DropIndex(
                name: "IX_MediaFiles_MediaFileId",
                table: "MediaFiles");

            migrationBuilder.DropIndex(
                name: "IX_MediaFiles_ProductionRoleId",
                table: "MediaFiles");

            migrationBuilder.DropIndex(
                name: "IX_MediaFiles_QuoteId",
                table: "MediaFiles");

            migrationBuilder.DropIndex(
                name: "IX_Facts_AwardCategoryId",
                table: "Facts");

            migrationBuilder.DropIndex(
                name: "IX_Facts_AwardRecipientId",
                table: "Facts");

            migrationBuilder.DropIndex(
                name: "IX_Facts_GenreId",
                table: "Facts");

            migrationBuilder.DropIndex(
                name: "IX_Facts_JobRoleId",
                table: "Facts");

            migrationBuilder.DropIndex(
                name: "IX_Facts_MediaFileId",
                table: "Facts");

            migrationBuilder.DropIndex(
                name: "IX_Facts_MovieStudioId",
                table: "Facts");

            migrationBuilder.DropIndex(
                name: "IX_Facts_ProductionRoleId",
                table: "Facts");

            migrationBuilder.DropIndex(
                name: "IX_Facts_QuoteId",
                table: "Facts");

            migrationBuilder.DropIndex(
                name: "IX_Facts_RatingId",
                table: "Facts");

            migrationBuilder.DropIndex(
                name: "IX_AwardRecipient_AwardRecipientId",
                table: "AwardRecipient");

            migrationBuilder.DropIndex(
                name: "IX_AwardRecipient_CharacterId",
                table: "AwardRecipient");

            migrationBuilder.DropIndex(
                name: "IX_AwardRecipient_GenreId",
                table: "AwardRecipient");

            migrationBuilder.DropIndex(
                name: "IX_AwardRecipient_JobRoleId",
                table: "AwardRecipient");

            migrationBuilder.DropIndex(
                name: "IX_AwardRecipient_MovieSeriesId",
                table: "AwardRecipient");

            migrationBuilder.DropIndex(
                name: "IX_AwardRecipient_MovieStudioId",
                table: "AwardRecipient");

            migrationBuilder.DropIndex(
                name: "IX_AwardRecipient_ProductionRoleId",
                table: "AwardRecipient");

            migrationBuilder.DropIndex(
                name: "IX_AwardRecipient_QuoteId",
                table: "AwardRecipient");

            migrationBuilder.DropIndex(
                name: "IX_AwardRecipient_RatingId",
                table: "AwardRecipient");

            migrationBuilder.DropColumn(
                name: "Recommended",
                table: "TVShows");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "Recommended",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "Recommended",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "ProductionRoles");

            migrationBuilder.DropColumn(
                name: "Recommended",
                table: "ProductionRoles");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "ProductionRoles");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "MovieStudios");

            migrationBuilder.DropColumn(
                name: "Recommended",
                table: "MovieStudios");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "MovieStudios");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "MovieSeries");

            migrationBuilder.DropColumn(
                name: "Recommended",
                table: "MovieSeries");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "MovieSeries");

            migrationBuilder.DropColumn(
                name: "Recommended",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "AwardCategoryId",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "JobRoleId",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "MediaFileId",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "ProductionRoleId",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "QuoteId",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "Recommended",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "JobRoles");

            migrationBuilder.DropColumn(
                name: "Recommended",
                table: "JobRoles");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "JobRoles");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "Recommended",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "AwardCategoryId",
                table: "Facts");

            migrationBuilder.DropColumn(
                name: "AwardRecipientId",
                table: "Facts");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Facts");

            migrationBuilder.DropColumn(
                name: "JobRoleId",
                table: "Facts");

            migrationBuilder.DropColumn(
                name: "MediaFileId",
                table: "Facts");

            migrationBuilder.DropColumn(
                name: "MovieStudioId",
                table: "Facts");

            migrationBuilder.DropColumn(
                name: "ProductionRoleId",
                table: "Facts");

            migrationBuilder.DropColumn(
                name: "QuoteId",
                table: "Facts");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Facts");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "Recommended",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Recommended",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "CastCrewMember");

            migrationBuilder.DropColumn(
                name: "Recommended",
                table: "CastCrewMember");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "Recommended",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "AwardRecipientId",
                table: "AwardRecipient");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "AwardRecipient");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "AwardRecipient");

            migrationBuilder.DropColumn(
                name: "JobRoleId",
                table: "AwardRecipient");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "AwardRecipient");

            migrationBuilder.DropColumn(
                name: "MovieSeriesId",
                table: "AwardRecipient");

            migrationBuilder.DropColumn(
                name: "MovieStudioId",
                table: "AwardRecipient");

            migrationBuilder.DropColumn(
                name: "ProductionRoleId",
                table: "AwardRecipient");

            migrationBuilder.DropColumn(
                name: "QuoteId",
                table: "AwardRecipient");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "AwardRecipient");

            migrationBuilder.DropColumn(
                name: "Recommended",
                table: "AwardRecipient");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "AwardRecipient");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "AwardCategories");

            migrationBuilder.DropColumn(
                name: "Recommended",
                table: "AwardCategories");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "AwardCategories");

            migrationBuilder.RenameColumn(
                name: "RatingId",
                table: "MediaFiles",
                newName: "ListArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_MediaFiles_RatingId",
                table: "MediaFiles",
                newName: "IX_MediaFiles_ListArticleId");

            migrationBuilder.AddColumn<int>(
                name: "ListArticleId",
                table: "TVShows",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListArticleId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListArticleId",
                table: "Episodes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListArticleId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListArticleId",
                table: "CastCrewMember",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Edited = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListArticles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Edited = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListArticles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TVShows_ListArticleId",
                table: "TVShows",
                column: "ListArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ListArticleId",
                table: "Movies",
                column: "ListArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_ListArticleId",
                table: "Episodes",
                column: "ListArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ListArticleId",
                table: "Characters",
                column: "ListArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_CastCrewMember_ListArticleId",
                table: "CastCrewMember",
                column: "ListArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CastCrewMember_ListArticles_ListArticleId",
                table: "CastCrewMember",
                column: "ListArticleId",
                principalTable: "ListArticles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_ListArticles_ListArticleId",
                table: "Characters",
                column: "ListArticleId",
                principalTable: "ListArticles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_ListArticles_ListArticleId",
                table: "Episodes",
                column: "ListArticleId",
                principalTable: "ListArticles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_ListArticles_ListArticleId",
                table: "MediaFiles",
                column: "ListArticleId",
                principalTable: "ListArticles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_ListArticles_ListArticleId",
                table: "Movies",
                column: "ListArticleId",
                principalTable: "ListArticles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TVShows_ListArticles_ListArticleId",
                table: "TVShows",
                column: "ListArticleId",
                principalTable: "ListArticles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CastCrewMember_ListArticles_ListArticleId",
                table: "CastCrewMember");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_ListArticles_ListArticleId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_ListArticles_ListArticleId",
                table: "Episodes");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_ListArticles_ListArticleId",
                table: "MediaFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_ListArticles_ListArticleId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_TVShows_ListArticles_ListArticleId",
                table: "TVShows");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "ListArticles");

            migrationBuilder.DropIndex(
                name: "IX_TVShows_ListArticleId",
                table: "TVShows");

            migrationBuilder.DropIndex(
                name: "IX_Movies_ListArticleId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Episodes_ListArticleId",
                table: "Episodes");

            migrationBuilder.DropIndex(
                name: "IX_Characters_ListArticleId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_CastCrewMember_ListArticleId",
                table: "CastCrewMember");

            migrationBuilder.DropColumn(
                name: "ListArticleId",
                table: "TVShows");

            migrationBuilder.DropColumn(
                name: "ListArticleId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ListArticleId",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "ListArticleId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "ListArticleId",
                table: "CastCrewMember");

            migrationBuilder.RenameColumn(
                name: "ListArticleId",
                table: "MediaFiles",
                newName: "RatingId");

            migrationBuilder.RenameIndex(
                name: "IX_MediaFiles_ListArticleId",
                table: "MediaFiles",
                newName: "IX_MediaFiles_RatingId");

            migrationBuilder.AddColumn<bool>(
                name: "Recommended",
                table: "TVShows",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Recommended",
                table: "Ratings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Quotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Recommended",
                table: "Quotes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Quotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "ProductionRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Recommended",
                table: "ProductionRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "ProductionRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "MovieStudios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Recommended",
                table: "MovieStudios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "MovieStudios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "MovieSeries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Recommended",
                table: "MovieSeries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "MovieSeries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Recommended",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AwardCategoryId",
                table: "MediaFiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobRoleId",
                table: "MediaFiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "MediaFiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MediaFileId",
                table: "MediaFiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductionRoleId",
                table: "MediaFiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuoteId",
                table: "MediaFiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Recommended",
                table: "MediaFiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "MediaFiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "JobRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Recommended",
                table: "JobRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "JobRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Recommended",
                table: "Genres",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AwardCategoryId",
                table: "Facts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AwardRecipientId",
                table: "Facts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Facts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobRoleId",
                table: "Facts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MediaFileId",
                table: "Facts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieStudioId",
                table: "Facts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductionRoleId",
                table: "Facts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuoteId",
                table: "Facts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "Facts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Episodes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Recommended",
                table: "Episodes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Episodes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Recommended",
                table: "Characters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "CastCrewMember",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Recommended",
                table: "CastCrewMember",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Awards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Recommended",
                table: "Awards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Awards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AwardRecipientId",
                table: "AwardRecipient",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "AwardRecipient",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "AwardRecipient",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobRoleId",
                table: "AwardRecipient",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "AwardRecipient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieSeriesId",
                table: "AwardRecipient",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieStudioId",
                table: "AwardRecipient",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductionRoleId",
                table: "AwardRecipient",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuoteId",
                table: "AwardRecipient",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "AwardRecipient",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Recommended",
                table: "AwardRecipient",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "AwardRecipient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "AwardCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Recommended",
                table: "AwardCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "AwardCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AwardRecipientMediaFile",
                columns: table => new
                {
                    AwardRecipientsId = table.Column<int>(type: "int", nullable: false),
                    MediaFilesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwardRecipientMediaFile", x => new { x.AwardRecipientsId, x.MediaFilesId });
                    table.ForeignKey(
                        name: "FK_AwardRecipientMediaFile_AwardRecipient_AwardRecipientsId",
                        column: x => x.AwardRecipientsId,
                        principalTable: "AwardRecipient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AwardRecipientMediaFile_MediaFiles_MediaFilesId",
                        column: x => x.MediaFilesId,
                        principalTable: "MediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_AwardCategoryId",
                table: "MediaFiles",
                column: "AwardCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_JobRoleId",
                table: "MediaFiles",
                column: "JobRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_MediaFileId",
                table: "MediaFiles",
                column: "MediaFileId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_ProductionRoleId",
                table: "MediaFiles",
                column: "ProductionRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_QuoteId",
                table: "MediaFiles",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_AwardCategoryId",
                table: "Facts",
                column: "AwardCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_AwardRecipientId",
                table: "Facts",
                column: "AwardRecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_GenreId",
                table: "Facts",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_JobRoleId",
                table: "Facts",
                column: "JobRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_MediaFileId",
                table: "Facts",
                column: "MediaFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_MovieStudioId",
                table: "Facts",
                column: "MovieStudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_ProductionRoleId",
                table: "Facts",
                column: "ProductionRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_QuoteId",
                table: "Facts",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_RatingId",
                table: "Facts",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardRecipient_AwardRecipientId",
                table: "AwardRecipient",
                column: "AwardRecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardRecipient_CharacterId",
                table: "AwardRecipient",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardRecipient_GenreId",
                table: "AwardRecipient",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardRecipient_JobRoleId",
                table: "AwardRecipient",
                column: "JobRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardRecipient_MovieSeriesId",
                table: "AwardRecipient",
                column: "MovieSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardRecipient_MovieStudioId",
                table: "AwardRecipient",
                column: "MovieStudioId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardRecipient_ProductionRoleId",
                table: "AwardRecipient",
                column: "ProductionRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardRecipient_QuoteId",
                table: "AwardRecipient",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardRecipient_RatingId",
                table: "AwardRecipient",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardRecipientMediaFile_MediaFilesId",
                table: "AwardRecipientMediaFile",
                column: "MediaFilesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AwardRecipient_AwardRecipient_AwardRecipientId",
                table: "AwardRecipient",
                column: "AwardRecipientId",
                principalTable: "AwardRecipient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AwardRecipient_Characters_CharacterId",
                table: "AwardRecipient",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AwardRecipient_Genres_GenreId",
                table: "AwardRecipient",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AwardRecipient_JobRoles_JobRoleId",
                table: "AwardRecipient",
                column: "JobRoleId",
                principalTable: "JobRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AwardRecipient_MovieSeries_MovieSeriesId",
                table: "AwardRecipient",
                column: "MovieSeriesId",
                principalTable: "MovieSeries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AwardRecipient_MovieStudios_MovieStudioId",
                table: "AwardRecipient",
                column: "MovieStudioId",
                principalTable: "MovieStudios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AwardRecipient_ProductionRoles_ProductionRoleId",
                table: "AwardRecipient",
                column: "ProductionRoleId",
                principalTable: "ProductionRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AwardRecipient_Quotes_QuoteId",
                table: "AwardRecipient",
                column: "QuoteId",
                principalTable: "Quotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AwardRecipient_Ratings_RatingId",
                table: "AwardRecipient",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facts_AwardCategories_AwardCategoryId",
                table: "Facts",
                column: "AwardCategoryId",
                principalTable: "AwardCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facts_AwardRecipient_AwardRecipientId",
                table: "Facts",
                column: "AwardRecipientId",
                principalTable: "AwardRecipient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facts_Genres_GenreId",
                table: "Facts",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facts_JobRoles_JobRoleId",
                table: "Facts",
                column: "JobRoleId",
                principalTable: "JobRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facts_MediaFiles_MediaFileId",
                table: "Facts",
                column: "MediaFileId",
                principalTable: "MediaFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facts_MovieStudios_MovieStudioId",
                table: "Facts",
                column: "MovieStudioId",
                principalTable: "MovieStudios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facts_ProductionRoles_ProductionRoleId",
                table: "Facts",
                column: "ProductionRoleId",
                principalTable: "ProductionRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facts_Quotes_QuoteId",
                table: "Facts",
                column: "QuoteId",
                principalTable: "Quotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facts_Ratings_RatingId",
                table: "Facts",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_AwardCategories_AwardCategoryId",
                table: "MediaFiles",
                column: "AwardCategoryId",
                principalTable: "AwardCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_JobRoles_JobRoleId",
                table: "MediaFiles",
                column: "JobRoleId",
                principalTable: "JobRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_MediaFiles_MediaFileId",
                table: "MediaFiles",
                column: "MediaFileId",
                principalTable: "MediaFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_ProductionRoles_ProductionRoleId",
                table: "MediaFiles",
                column: "ProductionRoleId",
                principalTable: "ProductionRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_Quotes_QuoteId",
                table: "MediaFiles",
                column: "QuoteId",
                principalTable: "Quotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_Ratings_RatingId",
                table: "MediaFiles",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
