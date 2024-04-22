using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ELibrary.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CompaniesSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { new Guid("8312ecf7-93ab-4c2c-b129-aed7119a7d1a"), "Miami", "Company B", "9045796633", "32225", "Fl", "54321 gew" },
                    { new Guid("986921ab-2789-48e5-b31a-916ed45f357f"), "OakLeaf", "Company C", "9045796633", "7798", "Fl", "5321 dse4" },
                    { new Guid("b1c54021-ca90-4533-addd-490068c1dfb4"), "Jacksonville", "Company A", "9045796633", "65557", "Fl", "789 dsa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("8312ecf7-93ab-4c2c-b129-aed7119a7d1a"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("986921ab-2789-48e5-b31a-916ed45f357f"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("b1c54021-ca90-4533-addd-490068c1dfb4"));
        }
    }
}
