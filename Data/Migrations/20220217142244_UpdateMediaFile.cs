using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMDB.Data.Migrations
{
    public partial class UpdateMediaFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "MediaFiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActorId",
                table: "MediaFiles",
                type: "int",
                nullable: true);
        }
    }
}
