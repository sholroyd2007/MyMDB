using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMDB.Data.Migrations
{
    public partial class addCreateEditToFacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facts_FactTypes_TypeId",
                table: "Facts");

            migrationBuilder.DropIndex(
                name: "IX_Facts_TypeId",
                table: "Facts");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Facts");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "FactTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Edited",
                table: "FactTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Facts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Edited",
                table: "Facts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FactTypeId",
                table: "Facts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Facts_FactTypeId",
                table: "Facts",
                column: "FactTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facts_FactTypes_FactTypeId",
                table: "Facts",
                column: "FactTypeId",
                principalTable: "FactTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facts_FactTypes_FactTypeId",
                table: "Facts");

            migrationBuilder.DropIndex(
                name: "IX_Facts_FactTypeId",
                table: "Facts");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "FactTypes");

            migrationBuilder.DropColumn(
                name: "Edited",
                table: "FactTypes");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Facts");

            migrationBuilder.DropColumn(
                name: "Edited",
                table: "Facts");

            migrationBuilder.DropColumn(
                name: "FactTypeId",
                table: "Facts");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Facts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facts_TypeId",
                table: "Facts",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facts_FactTypes_TypeId",
                table: "Facts",
                column: "TypeId",
                principalTable: "FactTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
