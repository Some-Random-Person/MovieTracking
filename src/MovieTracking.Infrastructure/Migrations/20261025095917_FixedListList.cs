using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTracking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedListList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListList");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListList",
                columns: table => new
                {
                    ChildListsId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ParentListsId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListList", x => new { x.ChildListsId, x.ParentListsId });
                    table.ForeignKey(
                        name: "FK_ListList_Lists_ChildListsId",
                        column: x => x.ChildListsId,
                        principalTable: "Lists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListList_Lists_ParentListsId",
                        column: x => x.ParentListsId,
                        principalTable: "Lists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ListList_ParentListsId",
                table: "ListList",
                column: "ParentListsId");
        }
    }
}
