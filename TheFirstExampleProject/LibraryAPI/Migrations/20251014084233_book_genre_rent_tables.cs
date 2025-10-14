using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAPI.Migrations
{
    /// <inheritdoc />
    public partial class book_genre_rent_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    id_genre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.id_genre);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    id_book = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cost = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_genre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.id_book);
                    table.ForeignKey(
                        name: "FK_Books_Genres_id_genre",
                        column: x => x.id_genre,
                        principalTable: "Genres",
                        principalColumn: "id_genre",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentLists",
                columns: table => new
                {
                    id_list = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_start = table.Column<DateOnly>(type: "date", nullable: false),
                    date_end = table.Column<DateOnly>(type: "date", nullable: false),
                    id_book = table.Column<int>(type: "int", nullable: false),
                    id_user = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentLists", x => x.id_list);
                    table.ForeignKey(
                        name: "FK_RentLists_Books_id_book",
                        column: x => x.id_book,
                        principalTable: "Books",
                        principalColumn: "id_book",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentLists_Users_id_user",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_id_genre",
                table: "Books",
                column: "id_genre");

            migrationBuilder.CreateIndex(
                name: "IX_RentLists_id_book",
                table: "RentLists",
                column: "id_book");

            migrationBuilder.CreateIndex(
                name: "IX_RentLists_id_user",
                table: "RentLists",
                column: "id_user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentLists");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
