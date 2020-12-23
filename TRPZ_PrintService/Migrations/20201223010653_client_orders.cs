using Microsoft.EntityFrameworkCore.Migrations;

namespace TRPZ_PrintService.Migrations
{
    public partial class client_orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Orders_AspNetUsers_ClientId",
                "Orders");

            migrationBuilder.AddForeignKey(
                "FK_Orders_AspNetUsers_ClientId",
                "Orders",
                "ClientId",
                "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Orders_AspNetUsers_ClientId",
                "Orders");

            migrationBuilder.AddForeignKey(
                "FK_Orders_AspNetUsers_ClientId",
                "Orders",
                "ClientId",
                "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}