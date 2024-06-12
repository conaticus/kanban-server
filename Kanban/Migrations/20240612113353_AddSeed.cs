using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kanban.Migrations
{
    /// <inheritdoc />
    public partial class AddSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Container",
                columns: new[] { "Id", "ContainerId", "Title" },
                values: new object[,]
                {
                    { 1, null, "Todo" },
                    { 2, null, "In Progress" },
                    { 3, null, "Done" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Container",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Container",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Container",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
