using Microsoft.EntityFrameworkCore.Migrations;

namespace TRPZ_PrintService.Migrations
{
    public partial class edit_order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}