using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMDB.Data.Migrations
{
    public partial class updateRatingsOnMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Ratings_RatingId1",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_RatingId1",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "RatingId1",
                table: "Movies");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_MovieId",
                table: "Ratings",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Movies_MovieId",
                table: "Ratings",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Movies_MovieId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_MovieId",
                table: "Ratings");

            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RatingId1",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_RatingId1",
                table: "Movies",
                column: "RatingId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Ratings_RatingId1",
                table: "Movies",
                column: "RatingId1",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
