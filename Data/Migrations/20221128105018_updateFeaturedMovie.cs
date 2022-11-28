using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMDB.Data.Migrations
{
    public partial class updateFeaturedMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Banner",
                table: "FeaturedMovies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EditorPick",
                table: "FeaturedMovies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Recommended",
                table: "FeaturedMovies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Banner",
                table: "FeaturedMovies");

            migrationBuilder.DropColumn(
                name: "EditorPick",
                table: "FeaturedMovies");

            migrationBuilder.DropColumn(
                name: "Recommended",
                table: "FeaturedMovies");
        }
    }
}
