using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JwtProject.Migrations
{
    /// <inheritdoc />
    public partial class add_new_order_relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "Orders",
                newName: "id_status");

            migrationBuilder.RenameColumn(
                name: "deliveryType",
                table: "Orders",
                newName: "id_delivery_type");

            migrationBuilder.CreateTable(
                name: "OrderDeliveryType",
                columns: table => new
                {
                    id_delivery_type = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDeliveryType", x => x.id_delivery_type);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    id_status = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.id_status);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_id_delivery_type",
                table: "Orders",
                column: "id_delivery_type");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_id_status",
                table: "Orders",
                column: "id_status");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderDeliveryType_id_delivery_type",
                table: "Orders",
                column: "id_delivery_type",
                principalTable: "OrderDeliveryType",
                principalColumn: "id_delivery_type",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatus_id_status",
                table: "Orders",
                column: "id_status",
                principalTable: "OrderStatus",
                principalColumn: "id_status",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderDeliveryType_id_delivery_type",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatus_id_status",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderDeliveryType");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropIndex(
                name: "IX_Orders_id_delivery_type",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_id_status",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "id_status",
                table: "Orders",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "id_delivery_type",
                table: "Orders",
                newName: "deliveryType");
        }
    }
}
