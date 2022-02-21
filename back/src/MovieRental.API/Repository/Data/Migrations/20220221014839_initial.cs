using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieRental.API.Data.Migrations {
    public partial class initial : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                name: "ClientModels",
                columns: table => new {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Cpf = table.Column<string>(type: "TEXT", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_ClientModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieModels",
                columns: table => new {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    ParentalRating = table.Column<int>(type: "INTEGER", nullable: false),
                    LauchMovie = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_MovieModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentalModels",
                columns: table => new {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RentalDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FKMovieId = table.Column<int>(type: "INTEGER", nullable: false),
                    FKClientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_RentalModels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "ClientModels");

            migrationBuilder.DropTable(
                name: "MovieModels");

            migrationBuilder.DropTable(
                name: "RentalModels");
        }
    }
}
