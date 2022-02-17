using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMDB.Data.Migrations
{
    public partial class UpdateDBContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorAwards_ActorAwards_AwardRecipientId",
                table: "ActorAwards");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorAwards_AwardCategories_AwardCategoryId",
                table: "ActorAwards");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorAwards_Awards_AwardId",
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
                name: "FK_AwardRecipientMediaFile_ActorAwards_AwardRecipientsId",
                table: "AwardRecipientMediaFile");

            migrationBuilder.DropForeignKey(
                name: "FK_Facts_ActorAwards_AwardRecipientId",
                table: "Facts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorAwards",
                table: "ActorAwards");

            migrationBuilder.RenameTable(
                name: "ActorAwards",
                newName: "AwardRecipient");

            migrationBuilder.RenameIndex(
                name: "IX_ActorAwards_TVShowId",
                table: "AwardRecipient",
                newName: "IX_AwardRecipient_TVShowId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorAwards_RatingId",
                table: "AwardRecipient",
                newName: "IX_AwardRecipient_RatingId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorAwards_QuoteId",
                table: "AwardRecipient",
                newName: "IX_AwardRecipient_QuoteId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorAwards_ProductionRoleId",
                table: "AwardRecipient",
                newName: "IX_AwardRecipient_ProductionRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorAwards_MovieStudioId",
                table: "AwardRecipient",
                newName: "IX_AwardRecipient_MovieStudioId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorAwards_MovieSeriesId",
                table: "AwardRecipient",
                newName: "IX_AwardRecipient_MovieSeriesId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorAwards_MovieId",
                table: "AwardRecipient",
                newName: "IX_AwardRecipient_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorAwards_JobRoleId",
                table: "AwardRecipient",
                newName: "IX_AwardRecipient_JobRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorAwards_GenreId",
                table: "AwardRecipient",
                newName: "IX_AwardRecipient_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorAwards_EpisodeId",
                table: "AwardRecipient",
                newName: "IX_AwardRecipient_EpisodeId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorAwards_CharacterId",
                table: "AwardRecipient",
                newName: "IX_AwardRecipient_CharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorAwards_CastCrewMemberId",
                table: "AwardRecipient",
                newName: "IX_AwardRecipient_CastCrewMemberId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorAwards_AwardRecipientId",
                table: "AwardRecipient",
                newName: "IX_AwardRecipient_AwardRecipientId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorAwards_AwardId",
                table: "AwardRecipient",
                newName: "IX_AwardRecipient_AwardId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorAwards_AwardCategoryId",
                table: "AwardRecipient",
                newName: "IX_AwardRecipient_AwardCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AwardRecipient",
                table: "AwardRecipient",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AwardRecipient_AwardCategories_AwardCategoryId",
                table: "AwardRecipient",
                column: "AwardCategoryId",
                principalTable: "AwardCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AwardRecipient_AwardRecipient_AwardRecipientId",
                table: "AwardRecipient",
                column: "AwardRecipientId",
                principalTable: "AwardRecipient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AwardRecipient_Awards_AwardId",
                table: "AwardRecipient",
                column: "AwardId",
                principalTable: "Awards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AwardRecipient_CastCrewMember_CastCrewMemberId",
                table: "AwardRecipient",
                column: "CastCrewMemberId",
                principalTable: "CastCrewMember",
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
                name: "FK_AwardRecipient_Episodes_EpisodeId",
                table: "AwardRecipient",
                column: "EpisodeId",
                principalTable: "Episodes",
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
                name: "FK_AwardRecipient_Movies_MovieId",
                table: "AwardRecipient",
                column: "MovieId",
                principalTable: "Movies",
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
                name: "FK_AwardRecipient_TVShows_TVShowId",
                table: "AwardRecipient",
                column: "TVShowId",
                principalTable: "TVShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AwardRecipientMediaFile_AwardRecipient_AwardRecipientsId",
                table: "AwardRecipientMediaFile",
                column: "AwardRecipientsId",
                principalTable: "AwardRecipient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facts_AwardRecipient_AwardRecipientId",
                table: "Facts",
                column: "AwardRecipientId",
                principalTable: "AwardRecipient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AwardRecipient_AwardCategories_AwardCategoryId",
                table: "AwardRecipient");

            migrationBuilder.DropForeignKey(
                name: "FK_AwardRecipient_AwardRecipient_AwardRecipientId",
                table: "AwardRecipient");

            migrationBuilder.DropForeignKey(
                name: "FK_AwardRecipient_Awards_AwardId",
                table: "AwardRecipient");

            migrationBuilder.DropForeignKey(
                name: "FK_AwardRecipient_CastCrewMember_CastCrewMemberId",
                table: "AwardRecipient");

            migrationBuilder.DropForeignKey(
                name: "FK_AwardRecipient_Characters_CharacterId",
                table: "AwardRecipient");

            migrationBuilder.DropForeignKey(
                name: "FK_AwardRecipient_Episodes_EpisodeId",
                table: "AwardRecipient");

            migrationBuilder.DropForeignKey(
                name: "FK_AwardRecipient_Genres_GenreId",
                table: "AwardRecipient");

            migrationBuilder.DropForeignKey(
                name: "FK_AwardRecipient_JobRoles_JobRoleId",
                table: "AwardRecipient");

            migrationBuilder.DropForeignKey(
                name: "FK_AwardRecipient_Movies_MovieId",
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
                name: "FK_AwardRecipient_TVShows_TVShowId",
                table: "AwardRecipient");

            migrationBuilder.DropForeignKey(
                name: "FK_AwardRecipientMediaFile_AwardRecipient_AwardRecipientsId",
                table: "AwardRecipientMediaFile");

            migrationBuilder.DropForeignKey(
                name: "FK_Facts_AwardRecipient_AwardRecipientId",
                table: "Facts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AwardRecipient",
                table: "AwardRecipient");

            migrationBuilder.RenameTable(
                name: "AwardRecipient",
                newName: "ActorAwards");

            migrationBuilder.RenameIndex(
                name: "IX_AwardRecipient_TVShowId",
                table: "ActorAwards",
                newName: "IX_ActorAwards_TVShowId");

            migrationBuilder.RenameIndex(
                name: "IX_AwardRecipient_RatingId",
                table: "ActorAwards",
                newName: "IX_ActorAwards_RatingId");

            migrationBuilder.RenameIndex(
                name: "IX_AwardRecipient_QuoteId",
                table: "ActorAwards",
                newName: "IX_ActorAwards_QuoteId");

            migrationBuilder.RenameIndex(
                name: "IX_AwardRecipient_ProductionRoleId",
                table: "ActorAwards",
                newName: "IX_ActorAwards_ProductionRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AwardRecipient_MovieStudioId",
                table: "ActorAwards",
                newName: "IX_ActorAwards_MovieStudioId");

            migrationBuilder.RenameIndex(
                name: "IX_AwardRecipient_MovieSeriesId",
                table: "ActorAwards",
                newName: "IX_ActorAwards_MovieSeriesId");

            migrationBuilder.RenameIndex(
                name: "IX_AwardRecipient_MovieId",
                table: "ActorAwards",
                newName: "IX_ActorAwards_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_AwardRecipient_JobRoleId",
                table: "ActorAwards",
                newName: "IX_ActorAwards_JobRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AwardRecipient_GenreId",
                table: "ActorAwards",
                newName: "IX_ActorAwards_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_AwardRecipient_EpisodeId",
                table: "ActorAwards",
                newName: "IX_ActorAwards_EpisodeId");

            migrationBuilder.RenameIndex(
                name: "IX_AwardRecipient_CharacterId",
                table: "ActorAwards",
                newName: "IX_ActorAwards_CharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_AwardRecipient_CastCrewMemberId",
                table: "ActorAwards",
                newName: "IX_ActorAwards_CastCrewMemberId");

            migrationBuilder.RenameIndex(
                name: "IX_AwardRecipient_AwardRecipientId",
                table: "ActorAwards",
                newName: "IX_ActorAwards_AwardRecipientId");

            migrationBuilder.RenameIndex(
                name: "IX_AwardRecipient_AwardId",
                table: "ActorAwards",
                newName: "IX_ActorAwards_AwardId");

            migrationBuilder.RenameIndex(
                name: "IX_AwardRecipient_AwardCategoryId",
                table: "ActorAwards",
                newName: "IX_ActorAwards_AwardCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorAwards",
                table: "ActorAwards",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorAwards_ActorAwards_AwardRecipientId",
                table: "ActorAwards",
                column: "AwardRecipientId",
                principalTable: "ActorAwards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorAwards_AwardCategories_AwardCategoryId",
                table: "ActorAwards",
                column: "AwardCategoryId",
                principalTable: "AwardCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorAwards_Awards_AwardId",
                table: "ActorAwards",
                column: "AwardId",
                principalTable: "Awards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_AwardRecipientMediaFile_ActorAwards_AwardRecipientsId",
                table: "AwardRecipientMediaFile",
                column: "AwardRecipientsId",
                principalTable: "ActorAwards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facts_ActorAwards_AwardRecipientId",
                table: "Facts",
                column: "AwardRecipientId",
                principalTable: "ActorAwards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
