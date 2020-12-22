using Microsoft.EntityFrameworkCore.Migrations;

namespace TRPZ_PrintService.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "ModelsInOrders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModelsInOrders_ManagerId",
                table: "ModelsInOrders",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModelsInOrders_AspNetUsers_ManagerId",
                table: "ModelsInOrders",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelsInOrders_AspNetUsers_ManagerId",
                table: "ModelsInOrders");

            migrationBuilder.DropIndex(
                name: "IX_ModelsInOrders_ManagerId",
                table: "ModelsInOrders");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "ModelsInOrders");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "AspNetUsers");
        }
    }
}
