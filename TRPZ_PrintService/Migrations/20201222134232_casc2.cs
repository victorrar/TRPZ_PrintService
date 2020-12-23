using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TRPZ_PrintService.Migrations
{
    public partial class casc2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_ModelsInOrders_ModelsSettings_ModelSettingsId",
                "ModelsInOrders");

            migrationBuilder.DropIndex(
                "IX_ModelsInOrders_ModelSettingsId",
                "ModelsInOrders");

            migrationBuilder.DropColumn(
                "ModelSettingsId",
                "ModelsInOrders");

            migrationBuilder.AlterColumn<int>(
                    "ModelSettingsId",
                    "ModelsSettings",
                    "integer",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                "FK_ModelsSettings_ModelsInOrders_ModelSettingsId",
                "ModelsSettings",
                "ModelSettingsId",
                "ModelsInOrders",
                principalColumn: "ModelInOrderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_ModelsSettings_ModelsInOrders_ModelSettingsId",
                "ModelsSettings");

            migrationBuilder.AlterColumn<int>(
                    "ModelSettingsId",
                    "ModelsSettings",
                    "integer",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                "ModelSettingsId",
                "ModelsInOrders",
                "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                "IX_ModelsInOrders_ModelSettingsId",
                "ModelsInOrders",
                "ModelSettingsId");

            migrationBuilder.AddForeignKey(
                "FK_ModelsInOrders_ModelsSettings_ModelSettingsId",
                "ModelsInOrders",
                "ModelSettingsId",
                "ModelsSettings",
                principalColumn: "ModelSettingsId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}