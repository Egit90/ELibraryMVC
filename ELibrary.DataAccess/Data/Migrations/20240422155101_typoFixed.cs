using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ELibrary.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class typoFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("8c5e44c5-cc2b-4f3f-a324-a4f1e3d1fd36"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("bca467fe-d2db-4390-82d4-33e9cdec22e3"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("ca490866-d32f-4584-b153-54511e138494"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { new Guid("8c5e44c5-cc2b-4f3f-a324-a4f1e3d1fd36"), "Miami", "Company B", "9045796633", "32225", "Fl", "54321 gew" },
                    { new Guid("bca467fe-d2db-4390-82d4-33e9cdec22e3"), "Jacksonville", "Company A", "9045796633", "65557", "Fl", "789 dsa" },
                    { new Guid("ca490866-d32f-4584-b153-54511e138494"), "OakLeaf", "Company C", "9045796633", "7798", "Fl", "5321 dse4" }
                });
        }
    }
}
