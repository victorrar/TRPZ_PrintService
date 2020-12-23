using Microsoft.EntityFrameworkCore.Migrations;

namespace TRPZ_PrintService.Migrations
{
    public partial class client_orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ClientId",
                table: "Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ClientId",
                table: "Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
