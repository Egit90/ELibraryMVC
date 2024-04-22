using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ELibrary.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddShoppingCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("45883a2f-cb2a-44b0-b7a5-b5685bd5e333"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("b1b614f4-ef3c-47a5-84ef-ee26a1b1abf0"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("c70187ee-f1f0-4e1b-b57a-9e22fac497a3"));

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { new Guid("1466b07a-08f1-45ac-a361-35545c2c50c5"), "Jacksonville", "Company A", "9045796633", "65557", "Fl", "789 dsa" },
                    { new Guid("92e505ad-6c7c-4dd0-b031-5658a03edd03"), "Miami", "Company B", "9045796633", "32225", "Fl", "54321 gew" },
                    { new Guid("a6ebefbf-dd47-49ac-978e-4cc522a664fe"), "OakLeaf", "Company C", "9045796633", "7798", "Fl", "5321 dse4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ApplicationUserId",
                table: "ShoppingCarts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ProductId",
                table: "ShoppingCarts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("1466b07a-08f1-45ac-a361-35545c2c50c5"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("92e505ad-6c7c-4dd0-b031-5658a03edd03"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("a6ebefbf-dd47-49ac-978e-4cc522a664fe"));

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { new Guid("45883a2f-cb2a-44b0-b7a5-b5685bd5e333"), "OakLeaf", "Company C", "9045796633", "7798", "Fl", "5321 dse4" },
                    { new Guid("b1b614f4-ef3c-47a5-84ef-ee26a1b1abf0"), "Jacksonville", "Company A", "9045796633", "65557", "Fl", "789 dsa" },
                    { new Guid("c70187ee-f1f0-4e1b-b57a-9e22fac497a3"), "Miami", "Company B", "9045796633", "32225", "Fl", "54321 gew" }
                });
        }
    }
}
