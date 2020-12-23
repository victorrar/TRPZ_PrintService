using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TRPZ_PrintService.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "AspNetRoles",
                table => new
                {
                    Id = table.Column<string>("text", nullable: false),
                    Name = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>("text", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AspNetRoles", x => x.Id); });

            migrationBuilder.CreateTable(
                "AspNetUsers",
                table => new
                {
                    Id = table.Column<string>("text", nullable: false),
                    FirstName = table.Column<string>("text", nullable: true),
                    LastName = table.Column<string>("text", nullable: true),
                    Discriminator = table.Column<string>("text", nullable: false),
                    UserName = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>("boolean", nullable: false),
                    PasswordHash = table.Column<string>("text", nullable: true),
                    SecurityStamp = table.Column<string>("text", nullable: true),
                    ConcurrencyStamp = table.Column<string>("text", nullable: true),
                    PhoneNumber = table.Column<string>("text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>("boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>("boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>("timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>("boolean", nullable: false),
                    AccessFailedCount = table.Column<int>("integer", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_AspNetUsers", x => x.Id); });

            migrationBuilder.CreateTable(
                "Materials",
                table => new
                {
                    MaterialId = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>("text", nullable: false),
                    Description = table.Column<string>("text", nullable: true),
                    Price = table.Column<int>("integer", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Materials", x => x.MaterialId); });

            migrationBuilder.CreateTable(
                "Models3D",
                table => new
                {
                    Model3DId = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FilePath = table.Column<string>("text", nullable: true),
                    Description = table.Column<string>("text", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Models3D", x => x.Model3DId); });

            migrationBuilder.CreateTable(
                "ModelsSettings",
                table => new
                {
                    ModelSettingsId = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InfillPercentage = table.Column<int>("integer", nullable: false),
                    NozzleDiameter = table.Column<int>("integer", nullable: false),
                    LayerHeight = table.Column<int>("integer", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_ModelsSettings", x => x.ModelSettingsId); });

            migrationBuilder.CreateTable(
                "PostProcessings",
                table => new
                {
                    PostProcessingId = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>("text", nullable: true),
                    Description = table.Column<string>("text", nullable: true),
                    Price = table.Column<int>("integer", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_PostProcessings", x => x.PostProcessingId); });

            migrationBuilder.CreateTable(
                "Printers",
                table => new
                {
                    PrinterId = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>("text", nullable: true),
                    Description = table.Column<string>("text", nullable: true),
                    ExtruderCount = table.Column<int>("integer", nullable: false),
                    MaxTemp = table.Column<int>("integer", nullable: false),
                    BuildPlateLength = table.Column<int>("integer", nullable: false),
                    BuildPlateWidth = table.Column<int>("integer", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Printers", x => x.PrinterId); });

            migrationBuilder.CreateTable(
                "PromoCodes",
                table => new
                {
                    PromoCodeId = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Issue = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    ActiveTo = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    Count = table.Column<int>("integer", nullable: false),
                    Discount = table.Column<int>("integer", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_PromoCodes", x => x.PromoCodeId); });

            migrationBuilder.CreateTable(
                "AspNetRoleClaims",
                table => new
                {
                    Id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>("text", nullable: false),
                    ClaimType = table.Column<string>("text", nullable: true),
                    ClaimValue = table.Column<string>("text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        x => x.RoleId,
                        "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserClaims",
                table => new
                {
                    Id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>("text", nullable: false),
                    ClaimType = table.Column<string>("text", nullable: true),
                    ClaimValue = table.Column<string>("text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetUserClaims_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserLogins",
                table => new
                {
                    LoginProvider = table.Column<string>("character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>("character varying(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>("text", nullable: true),
                    UserId = table.Column<string>("text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new {x.LoginProvider, x.ProviderKey});
                    table.ForeignKey(
                        "FK_AspNetUserLogins_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserRoles",
                table => new
                {
                    UserId = table.Column<string>("text", nullable: false),
                    RoleId = table.Column<string>("text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new {x.UserId, x.RoleId});
                    table.ForeignKey(
                        "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        x => x.RoleId,
                        "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_AspNetUserRoles_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserTokens",
                table => new
                {
                    UserId = table.Column<string>("text", nullable: false),
                    LoginProvider = table.Column<string>("character varying(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>("character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>("text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new {x.UserId, x.LoginProvider, x.Name});
                    table.ForeignKey(
                        "FK_AspNetUserTokens_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Orders",
                table => new
                {
                    OrderId = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Timestamp = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    TotalPrintTime = table.Column<TimeSpan>("interval", nullable: false),
                    ClientId = table.Column<string>("text", nullable: true),
                    PromoCodeId = table.Column<int>("integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        "FK_Orders_AspNetUsers_ClientId",
                        x => x.ClientId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Orders_PromoCodes_PromoCodeId",
                        x => x.PromoCodeId,
                        "PromoCodes",
                        "PromoCodeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "ModelsInOrders",
                table => new
                {
                    ModelInOrderId = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Scale = table.Column<double>("double precision", nullable: false, defaultValue: 1.0),
                    HasSolubleSupports = table.Column<bool>("boolean", nullable: false),
                    PriceTotal = table.Column<int>("integer", nullable: false),
                    OrderId = table.Column<int>("integer", nullable: true),
                    ModelSettingsId = table.Column<int>("integer", nullable: true),
                    MaterialId = table.Column<int>("integer", nullable: true),
                    PostProcessingId = table.Column<int>("integer", nullable: true),
                    PrinterId = table.Column<int>("integer", nullable: true),
                    Model3DId = table.Column<int>("integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelsInOrders", x => x.ModelInOrderId);
                    table.ForeignKey(
                        "FK_ModelsInOrders_Materials_MaterialId",
                        x => x.MaterialId,
                        "Materials",
                        "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_ModelsInOrders_Models3D_Model3DId",
                        x => x.Model3DId,
                        "Models3D",
                        "Model3DId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_ModelsInOrders_ModelsSettings_ModelSettingsId",
                        x => x.ModelSettingsId,
                        "ModelsSettings",
                        "ModelSettingsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_ModelsInOrders_Orders_OrderId",
                        x => x.OrderId,
                        "Orders",
                        "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_ModelsInOrders_PostProcessings_PostProcessingId",
                        x => x.PostProcessingId,
                        "PostProcessings",
                        "PostProcessingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_ModelsInOrders_Printers_PrinterId",
                        x => x.PrinterId,
                        "Printers",
                        "PrinterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_AspNetRoleClaims_RoleId",
                "AspNetRoleClaims",
                "RoleId");

            migrationBuilder.CreateIndex(
                "RoleNameIndex",
                "AspNetRoles",
                "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_AspNetUserClaims_UserId",
                "AspNetUserClaims",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserLogins_UserId",
                "AspNetUserLogins",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserRoles_RoleId",
                "AspNetUserRoles",
                "RoleId");

            migrationBuilder.CreateIndex(
                "EmailIndex",
                "AspNetUsers",
                "NormalizedEmail");

            migrationBuilder.CreateIndex(
                "UserNameIndex",
                "AspNetUsers",
                "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_ModelsInOrders_MaterialId",
                "ModelsInOrders",
                "MaterialId");

            migrationBuilder.CreateIndex(
                "IX_ModelsInOrders_Model3DId",
                "ModelsInOrders",
                "Model3DId");

            migrationBuilder.CreateIndex(
                "IX_ModelsInOrders_ModelSettingsId",
                "ModelsInOrders",
                "ModelSettingsId");

            migrationBuilder.CreateIndex(
                "IX_ModelsInOrders_OrderId",
                "ModelsInOrders",
                "OrderId");

            migrationBuilder.CreateIndex(
                "IX_ModelsInOrders_PostProcessingId",
                "ModelsInOrders",
                "PostProcessingId");

            migrationBuilder.CreateIndex(
                "IX_ModelsInOrders_PrinterId",
                "ModelsInOrders",
                "PrinterId");

            migrationBuilder.CreateIndex(
                "IX_Orders_ClientId",
                "Orders",
                "ClientId");

            migrationBuilder.CreateIndex(
                "IX_Orders_PromoCodeId",
                "Orders",
                "PromoCodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "AspNetRoleClaims");

            migrationBuilder.DropTable(
                "AspNetUserClaims");

            migrationBuilder.DropTable(
                "AspNetUserLogins");

            migrationBuilder.DropTable(
                "AspNetUserRoles");

            migrationBuilder.DropTable(
                "AspNetUserTokens");

            migrationBuilder.DropTable(
                "ModelsInOrders");

            migrationBuilder.DropTable(
                "AspNetRoles");

            migrationBuilder.DropTable(
                "Materials");

            migrationBuilder.DropTable(
                "Models3D");

            migrationBuilder.DropTable(
                "ModelsSettings");

            migrationBuilder.DropTable(
                "Orders");

            migrationBuilder.DropTable(
                "PostProcessings");

            migrationBuilder.DropTable(
                "Printers");

            migrationBuilder.DropTable(
                "AspNetUsers");

            migrationBuilder.DropTable(
                "PromoCodes");
        }
    }
}