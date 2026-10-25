using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTracking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OneMoreTryActuallyRightAmountOfIdsMaybe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListHierarchy_Lists_ListId",
                table: "ListHierarchy");

            migrationBuilder.DropForeignKey(
                name: "FK_ListHierarchy_Lists_ListId1",
                table: "ListHierarchy");

            migrationBuilder.DropIndex(
                name: "IX_ListHierarchy_ListId",
                table: "ListHierarchy");

            migrationBuilder.DropIndex(
                name: "IX_ListHierarchy_ListId1",
                table: "ListHierarchy");

            migrationBuilder.DropColumn(
                name: "ListId",
                table: "ListHierarchy");

            migrationBuilder.DropColumn(
                name: "ListId1",
                table: "ListHierarchy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ListId",
                table: "ListHierarchy",
                type: "char(36)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ListId1",
                table: "ListHierarchy",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListHierarchy_ListId",
                table: "ListHierarchy",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_ListHierarchy_ListId1",
                table: "ListHierarchy",
                column: "ListId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ListHierarchy_Lists_ListId",
                table: "ListHierarchy",
                column: "ListId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ListHierarchy_Lists_ListId1",
                table: "ListHierarchy",
                column: "ListId1",
                principalTable: "Lists",
                principalColumn: "Id");
        }
    }
}
