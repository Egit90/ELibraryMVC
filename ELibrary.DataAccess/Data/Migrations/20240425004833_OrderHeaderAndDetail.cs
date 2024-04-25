using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ELibrary.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrderHeaderAndDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("0fe253b3-b3dc-4852-8ae6-85e0d265a1b3"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("7979f3a7-69ab-4bba-8b9d-1013213d6a7c"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("bb053086-fe37-4b8f-a830-32d7eaf4c75e"));

            migrationBuilder.CreateTable(
                name: "OrderHeaders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "TEXT", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrderTotal = table.Column<double>(type: "REAL", nullable: false),
                    OrderStatus = table.Column<string>(type: "TEXT", nullable: true),
                    PaymentStatus = table.Column<string>(type: "TEXT", nullable: true),
                    TrackingNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Carrier = table.Column<string>(type: "TEXT", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PaymentDateDueDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    PaymentIntentId = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    StreetAddress = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrderHeaderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderHeaders_OrderHeaderId",
                        column: x => x.OrderHeaderId,
                        principalTable: "OrderHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
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
                    { new Guid("027dd843-0026-491f-bc57-5bcd0f2c4f07"), "Jacksonville", "Company A", "9045796633", "65557", "Fl", "789 dsa" },
                    { new Guid("4326f0a8-1437-481d-acef-3145d5340943"), "Miami", "Company B", "9045796633", "32225", "Fl", "54321 gew" },
                    { new Guid("cb141cf2-df13-48c0-8a50-4a51d862cae6"), "OakLeaf", "Company C", "9045796633", "7798", "Fl", "5321 dse4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderHeaderId",
                table: "OrderDetails",
                column: "OrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_ApplicationUserId",
                table: "OrderHeaders",
                column: "ApplicationUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrderHeaders");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("027dd843-0026-491f-bc57-5bcd0f2c4f07"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("4326f0a8-1437-481d-acef-3145d5340943"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("cb141cf2-df13-48c0-8a50-4a51d862cae6"));

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { new Guid("0fe253b3-b3dc-4852-8ae6-85e0d265a1b3"), "Jacksonville", "Company A", "9045796633", "65557", "Fl", "789 dsa" },
                    { new Guid("7979f3a7-69ab-4bba-8b9d-1013213d6a7c"), "Miami", "Company B", "9045796633", "32225", "Fl", "54321 gew" },
                    { new Guid("bb053086-fe37-4b8f-a830-32d7eaf4c75e"), "OakLeaf", "Company C", "9045796633", "7798", "Fl", "5321 dse4" }
                });
        }
    }
}
