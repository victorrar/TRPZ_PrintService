using Microsoft.EntityFrameworkCore.Migrations;

namespace TRPZ_PrintService.Migrations
{
    public partial class status_enum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "IsConfirmed",
                "Orders");

            migrationBuilder.DropColumn(
                "IsFinished",
                "Orders");

            migrationBuilder.DropColumn(
                "IsSent",
                "Orders");

            migrationBuilder.AddColumn<int>(
                "Status",
                "Orders",
                "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Status",
                "Orders");

            migrationBuilder.AddColumn<bool>(
                "IsConfirmed",
                "Orders",
                "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                "IsFinished",
                "Orders",
                "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                "IsSent",
                "Orders",
                "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}