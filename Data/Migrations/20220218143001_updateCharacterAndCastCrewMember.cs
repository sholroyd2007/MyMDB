using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMDB.Data.Migrations
{
    public partial class updateCharacterAndCastCrewMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CastCrewMember_ActorId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionRoles_CastCrewMember_CastCrewMemberId1",
                table: "ProductionRoles");

            migrationBuilder.DropIndex(
                name: "IX_ProductionRoles_CastCrewMemberId1",
                table: "ProductionRoles");

            migrationBuilder.DropIndex(
                name: "IX_Characters_ActorId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CastCrewMemberId1",
                table: "ProductionRoles");

            migrationBuilder.DropColumn(
                name: "ProductionRoleId",
                table: "CastCrewMember");

            migrationBuilder.AddColumn<int>(
                name: "CastCrewMemberId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductionRoles_CastCrewMemberId",
                table: "ProductionRoles",
                column: "CastCrewMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CastCrewMemberId",
                table: "Characters",
                column: "CastCrewMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CastCrewMember_CastCrewMemberId",
                table: "Characters",
                column: "CastCrewMemberId",
                principalTable: "CastCrewMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionRoles_CastCrewMember_CastCrewMemberId",
                table: "ProductionRoles",
                column: "CastCrewMemberId",
                principalTable: "CastCrewMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CastCrewMember_CastCrewMemberId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionRoles_CastCrewMember_CastCrewMemberId",
                table: "ProductionRoles");

            migrationBuilder.DropIndex(
                name: "IX_ProductionRoles_CastCrewMemberId",
                table: "ProductionRoles");

            migrationBuilder.DropIndex(
                name: "IX_Characters_CastCrewMemberId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CastCrewMemberId",
                table: "Characters");

            migrationBuilder.AddColumn<int>(
                name: "CastCrewMemberId1",
                table: "ProductionRoles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductionRoleId",
                table: "CastCrewMember",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductionRoles_CastCrewMemberId1",
                table: "ProductionRoles",
                column: "CastCrewMemberId1");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ActorId",
                table: "Characters",
                column: "ActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CastCrewMember_ActorId",
                table: "Characters",
                column: "ActorId",
                principalTable: "CastCrewMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionRoles_CastCrewMember_CastCrewMemberId1",
                table: "ProductionRoles",
                column: "CastCrewMemberId1",
                principalTable: "CastCrewMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
