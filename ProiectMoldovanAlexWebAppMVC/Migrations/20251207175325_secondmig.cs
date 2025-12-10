using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectMoldovanAlexWebAppMVC.Migrations
{
    /// <inheritdoc />
    public partial class secondmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "OrderStatusID",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStatusID",
                table: "Order",
                column: "OrderStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderStatus_OrderStatusID",
                table: "Order",
                column: "OrderStatusID",
                principalTable: "OrderStatus",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderStatus_OrderStatusID",
                table: "Order");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropIndex(
                name: "IX_Order_OrderStatusID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderStatusID",
                table: "Order");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
