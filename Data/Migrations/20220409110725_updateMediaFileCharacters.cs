using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMDB.Data.Migrations
{
    public partial class updateMediaFileCharacters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_CastCrewMember_CastCrewMemberId",
                table: "MediaFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_Characters_CharacterId",
                table: "MediaFiles");

            migrationBuilder.DropIndex(
                name: "IX_MediaFiles_CastCrewMemberId",
                table: "MediaFiles");

            migrationBuilder.DropIndex(
                name: "IX_MediaFiles_CharacterId",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "CastCrewMemberId",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "MediaFiles");

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
                name: "IX_CastCrewMemberMediaFile_MediaFilesId",
                table: "CastCrewMemberMediaFile",
                column: "MediaFilesId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMediaFile_MediaFilesId",
                table: "CharacterMediaFile",
                column: "MediaFilesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CastCrewMemberMediaFile");

            migrationBuilder.DropTable(
                name: "CharacterMediaFile");

            migrationBuilder.AddColumn<int>(
                name: "CastCrewMemberId",
                table: "MediaFiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "MediaFiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_CastCrewMemberId",
                table: "MediaFiles",
                column: "CastCrewMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_CharacterId",
                table: "MediaFiles",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_CastCrewMember_CastCrewMemberId",
                table: "MediaFiles",
                column: "CastCrewMemberId",
                principalTable: "CastCrewMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_Characters_CharacterId",
                table: "MediaFiles",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
