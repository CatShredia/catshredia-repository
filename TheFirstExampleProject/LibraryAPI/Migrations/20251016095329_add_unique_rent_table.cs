using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAPI.Migrations
{
    /// <inheritdoc />
    public partial class add_unique_rent_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RentLists_id_book",
                table: "RentLists");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "date_end",
                table: "RentLists",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.CreateIndex(
                name: "IX_RentLists_id_book_id_user",
                table: "RentLists",
                columns: new[] { "id_book", "id_user" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RentLists_id_book_id_user",
                table: "RentLists");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "date_end",
                table: "RentLists",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentLists_id_book",
                table: "RentLists",
                column: "id_book");
        }
    }
}
