using Microsoft.EntityFrameworkCore.Migrations;

namespace TRPZ_PrintService.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "ManagerId",
                "ModelsInOrders",
                "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "Type",
                "AspNetUsers",
                "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                "IX_ModelsInOrders_ManagerId",
                "ModelsInOrders",
                "ManagerId");

            migrationBuilder.AddForeignKey(
                "FK_ModelsInOrders_AspNetUsers_ManagerId",
                "ModelsInOrders",
                "ManagerId",
                "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_ModelsInOrders_AspNetUsers_ManagerId",
                "ModelsInOrders");

            migrationBuilder.DropIndex(
                "IX_ModelsInOrders_ManagerId",
                "ModelsInOrders");

            migrationBuilder.DropColumn(
                "ManagerId",
                "ModelsInOrders");

            migrationBuilder.DropColumn(
                "Type",
                "AspNetUsers");
        }
    }
}