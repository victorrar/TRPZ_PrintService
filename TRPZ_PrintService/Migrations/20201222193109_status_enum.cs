using Microsoft.EntityFrameworkCore.Migrations;

namespace TRPZ_PrintService.Migrations
{
    public partial class status_enum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsSent",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "Orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "Orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSent",
                table: "Orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
