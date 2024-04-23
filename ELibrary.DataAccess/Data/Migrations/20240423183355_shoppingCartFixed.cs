using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ELibrary.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class shoppingCartFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_ApplicationUserId",
                table: "ShoppingCarts");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("1132050f-9610-46e8-a653-e07dff41e365"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("6545fa62-327b-4621-8f29-16fe1724a6fc"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("9242b52c-a460-4808-87e8-3215852c696a"));

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ShoppingCarts",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { new Guid("0fe253b3-b3dc-4852-8ae6-85e0d265a1b3"), "Jacksonville", "Company A", "9045796633", "65557", "Fl", "789 dsa" },
                    { new Guid("7979f3a7-69ab-4bba-8b9d-1013213d6a7c"), "Miami", "Company B", "9045796633", "32225", "Fl", "54321 gew" },
                    { new Guid("bb053086-fe37-4b8f-a830-32d7eaf4c75e"), "OakLeaf", "Company C", "9045796633", "7798", "Fl", "5321 dse4" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_ApplicationUserId",
                table: "ShoppingCarts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_ApplicationUserId",
                table: "ShoppingCarts");

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

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ShoppingCarts",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { new Guid("1132050f-9610-46e8-a653-e07dff41e365"), "Miami", "Company B", "9045796633", "32225", "Fl", "54321 gew" },
                    { new Guid("6545fa62-327b-4621-8f29-16fe1724a6fc"), "Jacksonville", "Company A", "9045796633", "65557", "Fl", "789 dsa" },
                    { new Guid("9242b52c-a460-4808-87e8-3215852c696a"), "OakLeaf", "Company C", "9045796633", "7798", "Fl", "5321 dse4" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_ApplicationUserId",
                table: "ShoppingCarts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
