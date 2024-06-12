using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kanban.Migrations
{
    /// <inheritdoc />
    public partial class UnIgnoreJson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Container_containerId",
                table: "Card");

            migrationBuilder.RenameColumn(
                name: "containerId",
                table: "Card",
                newName: "ContainerId");

            migrationBuilder.RenameIndex(
                name: "IX_Card_containerId",
                table: "Card",
                newName: "IX_Card_ContainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Container_ContainerId",
                table: "Card",
                column: "ContainerId",
                principalTable: "Container",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Container_ContainerId",
                table: "Card");

            migrationBuilder.RenameColumn(
                name: "ContainerId",
                table: "Card",
                newName: "containerId");

            migrationBuilder.RenameIndex(
                name: "IX_Card_ContainerId",
                table: "Card",
                newName: "IX_Card_containerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Container_containerId",
                table: "Card",
                column: "containerId",
                principalTable: "Container",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
