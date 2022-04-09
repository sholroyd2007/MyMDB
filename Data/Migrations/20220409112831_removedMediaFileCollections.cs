using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMDB.Data.Migrations
{
    public partial class removedMediaFileCollections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facts_Awards_AwardId",
                table: "Facts");

            migrationBuilder.DropForeignKey(
                name: "FK_Facts_Characters_CharacterId",
                table: "Facts");

            migrationBuilder.DropForeignKey(
                name: "FK_Facts_MovieSeries_MovieSeriesId",
                table: "Facts");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_ListArticles_ListArticleId",
                table: "MediaFiles");

            migrationBuilder.DropTable(
                name: "CastCrewMemberMediaFile");

            migrationBuilder.DropTable(
                name: "CharacterMediaFile");

            migrationBuilder.DropIndex(
                name: "IX_MediaFiles_ListArticleId",
                table: "MediaFiles");

            migrationBuilder.DropIndex(
                name: "IX_Facts_AwardId",
                table: "Facts");

            migrationBuilder.DropIndex(
                name: "IX_Facts_CharacterId",
                table: "Facts");

            migrationBuilder.DropIndex(
                name: "IX_Facts_MovieSeriesId",
                table: "Facts");

            migrationBuilder.DropColumn(
                name: "ListArticleId",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "AwardId",
                table: "Facts");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Facts");

            migrationBuilder.DropColumn(
                name: "MovieSeriesId",
                table: "Facts");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "FactTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FactTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MediaFileId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MediaFileId",
                table: "CastCrewMember",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_MediaFileId",
                table: "Characters",
                column: "MediaFileId");

            migrationBuilder.CreateIndex(
                name: "IX_CastCrewMember_MediaFileId",
                table: "CastCrewMember",
                column: "MediaFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_CastCrewMember_MediaFiles_MediaFileId",
                table: "CastCrewMember",
                column: "MediaFileId",
                principalTable: "MediaFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_MediaFiles_MediaFileId",
                table: "Characters",
                column: "MediaFileId",
                principalTable: "MediaFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CastCrewMember_MediaFiles_MediaFileId",
                table: "CastCrewMember");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_MediaFiles_MediaFileId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_MediaFileId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_CastCrewMember_MediaFileId",
                table: "CastCrewMember");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "FactTypes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FactTypes");

            migrationBuilder.DropColumn(
                name: "MediaFileId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "MediaFileId",
                table: "CastCrewMember");

            migrationBuilder.AddColumn<int>(
                name: "ListArticleId",
                table: "MediaFiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AwardId",
                table: "Facts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Facts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieSeriesId",
                table: "Facts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CastCrewMemberMediaFile",
                columns: table => new
                {
                    CastCrewMembersId = table.Column<int>(type: "int", nullable: false),
                    MediaFilesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastCrewMemberMediaFile", x => new { x.CastCrewMembersId, x.MediaFilesId });
                    table.ForeignKey(
                        name: "FK_CastCrewMemberMediaFile_CastCrewMember_CastCrewMembersId",
                        column: x => x.CastCrewMembersId,
                        principalTable: "CastCrewMember",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CastCrewMemberMediaFile_MediaFiles_MediaFilesId",
                        column: x => x.MediaFilesId,
                        principalTable: "MediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterMediaFile",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "int", nullable: false),
                    MediaFilesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMediaFile", x => new { x.CharactersId, x.MediaFilesId });
                    table.ForeignKey(
                        name: "FK_CharacterMediaFile_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterMediaFile_MediaFiles_MediaFilesId",
                        column: x => x.MediaFilesId,
                        principalTable: "MediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_ListArticleId",
                table: "MediaFiles",
                column: "ListArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_AwardId",
                table: "Facts",
                column: "AwardId");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_CharacterId",
                table: "Facts",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_MovieSeriesId",
                table: "Facts",
                column: "MovieSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_CastCrewMemberMediaFile_MediaFilesId",
                table: "CastCrewMemberMediaFile",
                column: "MediaFilesId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMediaFile_MediaFilesId",
                table: "CharacterMediaFile",
                column: "MediaFilesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facts_Awards_AwardId",
                table: "Facts",
                column: "AwardId",
                principalTable: "Awards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facts_Characters_CharacterId",
                table: "Facts",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facts_MovieSeries_MovieSeriesId",
                table: "Facts",
                column: "MovieSeriesId",
                principalTable: "MovieSeries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_ListArticles_ListArticleId",
                table: "MediaFiles",
                column: "ListArticleId",
                principalTable: "ListArticles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
