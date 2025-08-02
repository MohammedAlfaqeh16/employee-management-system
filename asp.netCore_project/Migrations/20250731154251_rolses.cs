using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace asp.netCore_project.Migrations
{
    /// <inheritdoc />
    public partial class rolses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5696561a-9cdc-4757-a97a-5f602d6694ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc1e99d3-6243-4936-ac18-07b441a2db47");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1A2B3C4D-0000-1111-2222-1234567890AB", "ABC12345-6789-0000-1111-222233334444", "Admin", "ADMIN" },
                    { "5E6F7G8H-9999-8888-7777-9876543210CD", "DDD55555-6666-7777-8888-99990000AAAA", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1A2B3C4D-0000-1111-2222-1234567890AB");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5E6F7G8H-9999-8888-7777-9876543210CD");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5696561a-9cdc-4757-a97a-5f602d6694ca", "b4a814ef-c05e-438a-b17f-45741b3da921", "User", "user" },
                    { "cc1e99d3-6243-4936-ac18-07b441a2db47", "b38aaf41-8bff-4aef-b842-4eb28e174ec3", "Admin", "admin" }
                });
        }
    }
}
