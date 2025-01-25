using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dermastore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RolesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d8a7c3a6-1d6f-4b3b-b431-68e6bc953d1e", null, "Staff", "STAFF" },
                    { "e7a8c4b7-2c5a-4c5a-9b47-1e1f87289b2b", null, "Manager", "MANAGER" },
                    { "f2a5f3d7-3b6c-4c5b-9b2e-1c5e53e4d3f4", null, "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8a7c3a6-1d6f-4b3b-b431-68e6bc953d1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7a8c4b7-2c5a-4c5a-9b47-1e1f87289b2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2a5f3d7-3b6c-4c5b-9b2e-1c5e53e4d3f4");
        }
    }
}
