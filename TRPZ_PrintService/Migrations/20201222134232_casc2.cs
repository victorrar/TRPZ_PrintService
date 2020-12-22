using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TRPZ_PrintService.Migrations
{
    public partial class casc2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelsInOrders_ModelsSettings_ModelSettingsId",
                table: "ModelsInOrders");

            migrationBuilder.DropIndex(
                name: "IX_ModelsInOrders_ModelSettingsId",
                table: "ModelsInOrders");

            migrationBuilder.DropColumn(
                name: "ModelSettingsId",
                table: "ModelsInOrders");

            migrationBuilder.AlterColumn<int>(
                name: "ModelSettingsId",
                table: "ModelsSettings",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelsSettings_ModelsInOrders_ModelSettingsId",
                table: "ModelsSettings",
                column: "ModelSettingsId",
                principalTable: "ModelsInOrders",
                principalColumn: "ModelInOrderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelsSettings_ModelsInOrders_ModelSettingsId",
                table: "ModelsSettings");

            migrationBuilder.AlterColumn<int>(
                name: "ModelSettingsId",
                table: "ModelsSettings",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "ModelSettingsId",
                table: "ModelsInOrders",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModelsInOrders_ModelSettingsId",
                table: "ModelsInOrders",
                column: "ModelSettingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModelsInOrders_ModelsSettings_ModelSettingsId",
                table: "ModelsInOrders",
                column: "ModelSettingsId",
                principalTable: "ModelsSettings",
                principalColumn: "ModelSettingsId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
