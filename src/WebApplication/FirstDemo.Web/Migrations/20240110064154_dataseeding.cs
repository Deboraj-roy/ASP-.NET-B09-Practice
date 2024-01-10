using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FirstDemo.Web.Migrations
{
    /// <inheritdoc />
    public partial class dataseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Fees", "Title" },
                values: new object[,]
                {
                    { new Guid("672b26ca-6a94-46a0-8296-5583a37c84d9"), " Test Description 1", 2000L, "Test Course 1" },
                    { new Guid("7c47af1a-8fe1-4424-bce9-b002d606a86f"), " Test Description 2", 3000L, "Test Course 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("672b26ca-6a94-46a0-8296-5583a37c84d9"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("7c47af1a-8fe1-4424-bce9-b002d606a86f"));
        }
    }
}
