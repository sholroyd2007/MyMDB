using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMDB.Data.Migrations
{
    public partial class addProductionLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionCompanyMovies");

            migrationBuilder.DropTable(
                name: "TVNetworkShows");

            migrationBuilder.CreateTable(
                name: "ProductionLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: true),
                    TVShowId = table.Column<int>(type: "int", nullable: true),
                    ProductionCompanyId = table.Column<int>(type: "int", nullable: true),
                    TVNetworkId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Edited = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionLinks_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionLinks_ProductionCompanies_ProductionCompanyId",
                        column: x => x.ProductionCompanyId,
                        principalTable: "ProductionCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionLinks_TVNetworks_TVNetworkId",
                        column: x => x.TVNetworkId,
                        principalTable: "TVNetworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionLinks_TVShows_TVShowId",
                        column: x => x.TVShowId,
                        principalTable: "TVShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductionLinks_MovieId",
                table: "ProductionLinks",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionLinks_ProductionCompanyId",
                table: "ProductionLinks",
                column: "ProductionCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionLinks_TVNetworkId",
                table: "ProductionLinks",
                column: "TVNetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionLinks_TVShowId",
                table: "ProductionLinks",
                column: "TVShowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionLinks");

            migrationBuilder.CreateTable(
                name: "ProductionCompanyMovies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edited = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionCompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCompanyMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionCompanyMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionCompanyMovies_ProductionCompanies_ProductionCompanyId",
                        column: x => x.ProductionCompanyId,
                        principalTable: "ProductionCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TVNetworkShows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edited = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionCompanyId = table.Column<int>(type: "int", nullable: true),
                    TVNetworkId = table.Column<int>(type: "int", nullable: true),
                    TVShowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVNetworkShows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TVNetworkShows_ProductionCompanies_ProductionCompanyId",
                        column: x => x.ProductionCompanyId,
                        principalTable: "ProductionCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TVNetworkShows_TVNetworks_TVNetworkId",
                        column: x => x.TVNetworkId,
                        principalTable: "TVNetworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TVNetworkShows_TVShows_TVShowId",
                        column: x => x.TVShowId,
                        principalTable: "TVShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCompanyMovies_MovieId",
                table: "ProductionCompanyMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCompanyMovies_ProductionCompanyId",
                table: "ProductionCompanyMovies",
                column: "ProductionCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TVNetworkShows_ProductionCompanyId",
                table: "TVNetworkShows",
                column: "ProductionCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TVNetworkShows_TVNetworkId",
                table: "TVNetworkShows",
                column: "TVNetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_TVNetworkShows_TVShowId",
                table: "TVNetworkShows",
                column: "TVShowId");
        }
    }
}
