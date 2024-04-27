using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ELibrary.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSessionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("1e2c40f1-a174-4abe-ab3f-45865b458e2a"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("43dc2df5-0692-4d8d-bc32-502991f738a9"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("bc1835a1-844d-4039-b600-b7f4b1a56d48"));

            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "OrderHeaders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { new Guid("6676d7dd-b253-4e2b-b6ad-d9d28fd9415a"), "Miami", "Company B", "9045796633", "32225", "Fl", "54321 gew" },
                    { new Guid("a335b121-60bc-41e2-bfd9-8c971586cc00"), "OakLeaf", "Company C", "9045796633", "7798", "Fl", "5321 dse4" },
                    { new Guid("de77db47-cd19-4e78-831c-b3ac46170a75"), "Jacksonville", "Company A", "9045796633", "65557", "Fl", "789 dsa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("6676d7dd-b253-4e2b-b6ad-d9d28fd9415a"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("a335b121-60bc-41e2-bfd9-8c971586cc00"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("de77db47-cd19-4e78-831c-b3ac46170a75"));

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "OrderHeaders");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { new Guid("1e2c40f1-a174-4abe-ab3f-45865b458e2a"), "OakLeaf", "Company C", "9045796633", "7798", "Fl", "5321 dse4" },
                    { new Guid("43dc2df5-0692-4d8d-bc32-502991f738a9"), "Jacksonville", "Company A", "9045796633", "65557", "Fl", "789 dsa" },
                    { new Guid("bc1835a1-844d-4039-b600-b7f4b1a56d48"), "Miami", "Company B", "9045796633", "32225", "Fl", "54321 gew" }
                });
        }
    }
}
