using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace asp.netCore_project.Migrations
{
    /// <inheritdoc />
    public partial class rolse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5696561a-9cdc-4757-a97a-5f602d6694ca", "b4a814ef-c05e-438a-b17f-45741b3da921", "User", "user" },
                    { "cc1e99d3-6243-4936-ac18-07b441a2db47", "b38aaf41-8bff-4aef-b842-4eb28e174ec3", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5696561a-9cdc-4757-a97a-5f602d6694ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc1e99d3-6243-4936-ac18-07b441a2db47");
        }
    }
}
