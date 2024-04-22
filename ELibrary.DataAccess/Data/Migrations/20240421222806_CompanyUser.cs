using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ELibrary.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CompanyUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { new Guid("8c5e44c5-cc2b-4f3f-a324-a4f1e3d1fd36"), "Miami", "Company B", "9045796633", "32225", "Fl", "54321 gew" },
                    { new Guid("bca467fe-d2db-4390-82d4-33e9cdec22e3"), "Jacksonville", "Company A", "9045796633", "65557", "Fl", "789 dsa" },
                    { new Guid("ca490866-d32f-4584-b153-54511e138494"), "OakLeaf", "Company C", "9045796633", "7798", "Fl", "5321 dse4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers");

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

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "AspNetUsers");

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
    }
}
