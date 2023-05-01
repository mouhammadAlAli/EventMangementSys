using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomField",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomField", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartAppearingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationInDays = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomFieldKey",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFieldKey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomFieldKey_CustomField_CustomFieldId",
                        column: x => x.CustomFieldId,
                        principalTable: "CustomField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTranslation_Products_CoreId",
                        column: x => x.CoreId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomFieldValue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomFieldKeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProducId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFieldValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomFieldValue_CustomFieldKey_CustomFieldKeyId",
                        column: x => x.CustomFieldKeyId,
                        principalTable: "CustomFieldKey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomFieldValue_Products_ProducId",
                        column: x => x.ProducId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedOnUtc", "Name", "UpdateOnUtc", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("aa78790e-9d22-4243-a735-f96ac103d491"), "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "House", null, null },
                    { new Guid("c77e3e74-22ff-4032-aa44-716ca223f7bf"), "System", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Car", null, null }
                });

            migrationBuilder.InsertData(
                table: "CustomField",
                columns: new[] { "Id", "CreatedBy", "CreatedOnUtc", "Name", "UpdateOnUtc", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("d84ec479-b38d-433f-ba57-2d3d2e4a3b29"), "System", new DateTime(2023, 4, 30, 21, 8, 12, 471, DateTimeKind.Utc).AddTicks(1257), "House Fields", null, null },
                    { new Guid("d84ec479-b38d-433f-ba57-2d3d2e4a3b91"), "System", new DateTime(2023, 4, 30, 21, 8, 12, 471, DateTimeKind.Utc).AddTicks(1267), "Engine specs", null, null }
                });

            migrationBuilder.InsertData(
                table: "CustomFieldKey",
                columns: new[] { "Id", "CustomFieldId", "Key" },
                values: new object[,]
                {
                    { new Guid("991cd085-9877-493c-838b-31689d030a84"), new Guid("d84ec479-b38d-433f-ba57-2d3d2e4a3b91"), "engine size" },
                    { new Guid("991cd085-9877-493c-838b-31689d030a86"), new Guid("d84ec479-b38d-433f-ba57-2d3d2e4a3b91"), "engine type" },
                    { new Guid("991cd085-9877-493c-838b-31689d030a87"), new Guid("d84ec479-b38d-433f-ba57-2d3d2e4a3b29"), "Type" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldKey_CustomFieldId",
                table: "CustomFieldKey",
                column: "CustomFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldValue_CustomFieldKeyId",
                table: "CustomFieldValue",
                column: "CustomFieldKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldValue_ProducId",
                table: "CustomFieldValue",
                column: "ProducId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslation_CoreId",
                table: "ProductTranslation",
                column: "CoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomFieldValue");

            migrationBuilder.DropTable(
                name: "ProductTranslation");

            migrationBuilder.DropTable(
                name: "CustomFieldKey");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "CustomField");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
