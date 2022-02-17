using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMDB.Data.Migrations
{
    public partial class UpdateEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Awards_ActorAwards_AwardRecipientId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_Awards_AwardCategories_AwardCategoryId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_Awards_Awards_AwardId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_Awards_CastCrewMember_CastCrewMemberId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_Awards_Characters_CharacterId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_Awards_Episodes_EpisodeId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_Awards_Genres_GenreId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_Awards_JobRoles_JobRoleId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_Awards_Movies_MovieId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_Awards_MovieSeries_MovieSeriesId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_Awards_MovieStudios_MovieStudioId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_Awards_ProductionRoles_ProductionRoleId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_Awards_Quotes_QuoteId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_Awards_Ratings_RatingId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_Awards_TVShows_TVShowId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_ActorAwards_AwardRecipientId",
                table: "MediaFiles");

            migrationBuilder.DropTable(
                name: "AwardMediaFile");

            migrationBuilder.DropIndex(
                name: "IX_MediaFiles_AwardRecipientId",
                table: "MediaFiles");

            migrationBuilder.DropIndex(
                name: "IX_Awards_AwardCategoryId",
                table: "Awards");

            migrationBuilder.DropIndex(
                name: "IX_Awards_AwardId",
                table: "Awards");

            migrationBuilder.DropIndex(
                name: "IX_Awards_AwardRecipientId",
                table: "Awards");

            migrationBuilder.DropIndex(
                name: "IX_Awards_CastCrewMemberId",
                table: "Awards");

            migrationBuilder.DropIndex(
                name: "IX_Awards_CharacterId",
                table: "Awards");

            migrationBuilder.DropIndex(
                name: "IX_Awards_EpisodeId",
                table: "Awards");

            migrationBuilder.DropIndex(
                name: "IX_Awards_GenreId",
                table: "Awards");

            migrationBuilder.DropIndex(
                name: "IX_Awards_JobRoleId",
                table: "Awards");

            migrationBuilder.DropIndex(
                name: "IX_Awards_MovieId",
                table: "Awards");

            migrationBuilder.DropIndex(
                name: "IX_Awards_MovieSeriesId",
                table: "Awards");

            migrationBuilder.DropIndex(
                name: "IX_Awards_MovieStudioId",
                table: "Awards");

            migrationBuilder.DropIndex(
                name: "IX_Awards_ProductionRoleId",
                table: "Awards");

            migrationBuilder.DropIndex(
                name: "IX_Awards_QuoteId",
                table: "Awards");

            migrationBuilder.DropIndex(
                name: "IX_Awards_RatingId",
                table: "Awards");

            migrationBuilder.DropIndex(
                name: "IX_Awards_TVShowId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "AwardRecipientId",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "AwardCategoryId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "AwardId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "AwardRecipientId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "CastCrewMemberId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "EpisodeId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "JobRoleId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "MovieSeriesId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "MovieStudioId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "ProductionRoleId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "QuoteId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "TVShowId",
                table: "Awards");

            migrationBuilder.AddColumn<int>(
                name: "AwardRecipientId",
                table: "ActorAwards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "ActorAwards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "ActorAwards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobRoleId",
                table: "ActorAwards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieSeriesId",
                table: "ActorAwards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieStudioId",
                table: "ActorAwards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductionRoleId",
                table: "ActorAwards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuoteId",
                table: "ActorAwards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "ActorAwards",
                type: "int",
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
                        name: "FK_AwardRecipientMediaFile_ActorAwards_AwardRecipientsId",
                        column: x => x.AwardRecipientsId,
                        principalTable: "ActorAwards",
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
                name: "IX_MediaFiles_AwardId",
                table: "MediaFiles",
                column: "AwardId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorAwards_AwardRecipientId",
                table: "ActorAwards",
                column: "AwardRecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorAwards_CastCrewMemberId",
                table: "ActorAwards",
                column: "CastCrewMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorAwards_CharacterId",
                table: "ActorAwards",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorAwards_EpisodeId",
                table: "ActorAwards",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorAwards_GenreId",
                table: "ActorAwards",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorAwards_JobRoleId",
                table: "ActorAwards",
                column: "JobRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorAwards_MovieId",
                table: "ActorAwards",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorAwards_MovieSeriesId",
                table: "ActorAwards",
                column: "MovieSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorAwards_MovieStudioId",
                table: "ActorAwards",
                column: "MovieStudioId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorAwards_ProductionRoleId",
                table: "ActorAwards",
                column: "ProductionRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorAwards_QuoteId",
                table: "ActorAwards",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorAwards_RatingId",
                table: "ActorAwards",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorAwards_TVShowId",
                table: "ActorAwards",
                column: "TVShowId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardRecipientMediaFile_MediaFilesId",
                table: "AwardRecipientMediaFile",
                column: "MediaFilesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorAwards_ActorAwards_AwardRecipientId",
                table: "ActorAwards",
                column: "AwardRecipientId",
                principalTable: "ActorAwards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorAwards_CastCrewMember_CastCrewMemberId",
                table: "ActorAwards",
                column: "CastCrewMemberId",
                principalTable: "CastCrewMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorAwards_Characters_CharacterId",
                table: "ActorAwards",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorAwards_Episodes_EpisodeId",
                table: "ActorAwards",
                column: "EpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorAwards_Genres_GenreId",
                table: "ActorAwards",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorAwards_JobRoles_JobRoleId",
                table: "ActorAwards",
                column: "JobRoleId",
                principalTable: "JobRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorAwards_Movies_MovieId",
                table: "ActorAwards",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorAwards_MovieSeries_MovieSeriesId",
                table: "ActorAwards",
                column: "MovieSeriesId",
                principalTable: "MovieSeries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorAwards_MovieStudios_MovieStudioId",
                table: "ActorAwards",
                column: "MovieStudioId",
                principalTable: "MovieStudios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorAwards_ProductionRoles_ProductionRoleId",
                table: "ActorAwards",
                column: "ProductionRoleId",
                principalTable: "ProductionRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorAwards_Quotes_QuoteId",
                table: "ActorAwards",
                column: "QuoteId",
                principalTable: "Quotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorAwards_Ratings_RatingId",
                table: "ActorAwards",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorAwards_TVShows_TVShowId",
                table: "ActorAwards",
                column: "TVShowId",
                principalTable: "TVShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_Awards_AwardId",
                table: "MediaFiles",
                column: "AwardId",
                principalTable: "Awards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorAwards_ActorAwards_AwardRecipientId",
                table: "ActorAwards");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorAwards_CastCrewMember_CastCrewMemberId",
                table: "ActorAwards");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorAwards_Characters_CharacterId",
                table: "ActorAwards");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorAwards_Episodes_EpisodeId",
                table: "ActorAwards");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorAwards_Genres_GenreId",
                table: "ActorAwards");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorAwards_JobRoles_JobRoleId",
                table: "ActorAwards");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorAwards_Movies_MovieId",
                table: "ActorAwards");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorAwards_MovieSeries_MovieSeriesId",
                table: "ActorAwards");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorAwards_MovieStudios_MovieStudioId",
                table: "ActorAwards");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorAwards_ProductionRoles_ProductionRoleId",
                table: "ActorAwards");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorAwards_Quotes_QuoteId",
                table: "ActorAwards");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorAwards_Ratings_RatingId",
                table: "ActorAwards");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorAwards_TVShows_TVShowId",
                table: "ActorAwards");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_Awards_AwardId",
                table: "MediaFiles");

            migrationBuilder.DropTable(
                name: "AwardRecipientMediaFile");

            migrationBuilder.DropIndex(
                name: "IX_MediaFiles_AwardId",
                table: "MediaFiles");

            migrationBuilder.DropIndex(
                name: "IX_ActorAwards_AwardRecipientId",
                table: "ActorAwards");

            migrationBuilder.DropIndex(
                name: "IX_ActorAwards_CastCrewMemberId",
                table: "ActorAwards");

            migrationBuilder.DropIndex(
                name: "IX_ActorAwards_CharacterId",
                table: "ActorAwards");

            migrationBuilder.DropIndex(
                name: "IX_ActorAwards_EpisodeId",
                table: "ActorAwards");

            migrationBuilder.DropIndex(
                name: "IX_ActorAwards_GenreId",
                table: "ActorAwards");

            migrationBuilder.DropIndex(
                name: "IX_ActorAwards_JobRoleId",
                table: "ActorAwards");

            migrationBuilder.DropIndex(
                name: "IX_ActorAwards_MovieId",
                table: "ActorAwards");

            migrationBuilder.DropIndex(
                name: "IX_ActorAwards_MovieSeriesId",
                table: "ActorAwards");

            migrationBuilder.DropIndex(
                name: "IX_ActorAwards_MovieStudioId",
                table: "ActorAwards");

            migrationBuilder.DropIndex(
                name: "IX_ActorAwards_ProductionRoleId",
                table: "ActorAwards");

            migrationBuilder.DropIndex(
                name: "IX_ActorAwards_QuoteId",
                table: "ActorAwards");

            migrationBuilder.DropIndex(
                name: "IX_ActorAwards_RatingId",
                table: "ActorAwards");

            migrationBuilder.DropIndex(
                name: "IX_ActorAwards_TVShowId",
                table: "ActorAwards");

            migrationBuilder.DropColumn(
                name: "AwardRecipientId",
                table: "ActorAwards");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "ActorAwards");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "ActorAwards");

            migrationBuilder.DropColumn(
                name: "JobRoleId",
                table: "ActorAwards");

            migrationBuilder.DropColumn(
                name: "MovieSeriesId",
                table: "ActorAwards");

            migrationBuilder.DropColumn(
                name: "MovieStudioId",
                table: "ActorAwards");

            migrationBuilder.DropColumn(
                name: "ProductionRoleId",
                table: "ActorAwards");

            migrationBuilder.DropColumn(
                name: "QuoteId",
                table: "ActorAwards");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "ActorAwards");

            migrationBuilder.AddColumn<int>(
                name: "AwardRecipientId",
                table: "MediaFiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AwardCategoryId",
                table: "Awards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AwardId",
                table: "Awards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AwardRecipientId",
                table: "Awards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CastCrewMemberId",
                table: "Awards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Awards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EpisodeId",
                table: "Awards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Awards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobRoleId",
                table: "Awards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Awards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieSeriesId",
                table: "Awards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieStudioId",
                table: "Awards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductionRoleId",
                table: "Awards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuoteId",
                table: "Awards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "Awards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TVShowId",
                table: "Awards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AwardMediaFile",
                columns: table => new
                {
                    AwardsId = table.Column<int>(type: "int", nullable: false),
                    MediaFilesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwardMediaFile", x => new { x.AwardsId, x.MediaFilesId });
                    table.ForeignKey(
                        name: "FK_AwardMediaFile_Awards_AwardsId",
                        column: x => x.AwardsId,
                        principalTable: "Awards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AwardMediaFile_MediaFiles_MediaFilesId",
                        column: x => x.MediaFilesId,
                        principalTable: "MediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_AwardRecipientId",
                table: "MediaFiles",
                column: "AwardRecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_AwardCategoryId",
                table: "Awards",
                column: "AwardCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_AwardId",
                table: "Awards",
                column: "AwardId");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_AwardRecipientId",
                table: "Awards",
                column: "AwardRecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_CastCrewMemberId",
                table: "Awards",
                column: "CastCrewMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_CharacterId",
                table: "Awards",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_EpisodeId",
                table: "Awards",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_GenreId",
                table: "Awards",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_JobRoleId",
                table: "Awards",
                column: "JobRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_MovieId",
                table: "Awards",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_MovieSeriesId",
                table: "Awards",
                column: "MovieSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_MovieStudioId",
                table: "Awards",
                column: "MovieStudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_ProductionRoleId",
                table: "Awards",
                column: "ProductionRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_QuoteId",
                table: "Awards",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_RatingId",
                table: "Awards",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_TVShowId",
                table: "Awards",
                column: "TVShowId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardMediaFile_MediaFilesId",
                table: "AwardMediaFile",
                column: "MediaFilesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_ActorAwards_AwardRecipientId",
                table: "Awards",
                column: "AwardRecipientId",
                principalTable: "ActorAwards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_AwardCategories_AwardCategoryId",
                table: "Awards",
                column: "AwardCategoryId",
                principalTable: "AwardCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_Awards_AwardId",
                table: "Awards",
                column: "AwardId",
                principalTable: "Awards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_CastCrewMember_CastCrewMemberId",
                table: "Awards",
                column: "CastCrewMemberId",
                principalTable: "CastCrewMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_Characters_CharacterId",
                table: "Awards",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_Episodes_EpisodeId",
                table: "Awards",
                column: "EpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_Genres_GenreId",
                table: "Awards",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_JobRoles_JobRoleId",
                table: "Awards",
                column: "JobRoleId",
                principalTable: "JobRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_Movies_MovieId",
                table: "Awards",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_MovieSeries_MovieSeriesId",
                table: "Awards",
                column: "MovieSeriesId",
                principalTable: "MovieSeries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_MovieStudios_MovieStudioId",
                table: "Awards",
                column: "MovieStudioId",
                principalTable: "MovieStudios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_ProductionRoles_ProductionRoleId",
                table: "Awards",
                column: "ProductionRoleId",
                principalTable: "ProductionRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_Quotes_QuoteId",
                table: "Awards",
                column: "QuoteId",
                principalTable: "Quotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_Ratings_RatingId",
                table: "Awards",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_TVShows_TVShowId",
                table: "Awards",
                column: "TVShowId",
                principalTable: "TVShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_ActorAwards_AwardRecipientId",
                table: "MediaFiles",
                column: "AwardRecipientId",
                principalTable: "ActorAwards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
