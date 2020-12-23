using Microsoft.EntityFrameworkCore.Migrations;

namespace TRPZ_PrintService.Migrations
{
    public partial class casc1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_ModelsInOrders_Orders_OrderId",
                "ModelsInOrders");

            migrationBuilder.DropColumn(
                "Discriminator",
                "AspNetUsers");

            migrationBuilder.DropColumn(
                "Type",
                "AspNetUsers");

            migrationBuilder.AddForeignKey(
                "FK_ModelsInOrders_Orders_OrderId",
                "ModelsInOrders",
                "OrderId",
                "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_ModelsInOrders_Orders_OrderId",
                "ModelsInOrders");

            migrationBuilder.AddColumn<string>(
                "Discriminator",
                "AspNetUsers",
                "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                "Type",
                "AspNetUsers",
                "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                "FK_ModelsInOrders_Orders_OrderId",
                "ModelsInOrders",
                "OrderId",
                "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}