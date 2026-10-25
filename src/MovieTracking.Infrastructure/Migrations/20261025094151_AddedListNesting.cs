using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTracking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedListNesting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListHierarchy",
                columns: table => new
                {
                    ParentListId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ChildListId = table.Column<Guid>(type: "char(36)", nullable: false),
                    SortingNumber = table.Column<int>(type: "int", nullable: true),
                    ListId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListHierarchy", x => new { x.ChildListId, x.ParentListId });
                    table.ForeignKey(
                        name: "FK_ListHierarchy_Lists_ChildListId",
                        column: x => x.ChildListId,
                        principalTable: "Lists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListHierarchy_Lists_ListId",
                        column: x => x.ListId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ListHierarchy_Lists_ParentListId",
                        column: x => x.ParentListId,
                        principalTable: "Lists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

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
                name: "IX_ListHierarchy_ListId",
                table: "ListHierarchy",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_ListHierarchy_ParentListId",
                table: "ListHierarchy",
                column: "ParentListId");

            migrationBuilder.CreateIndex(
                name: "IX_ListList_ParentListsId",
                table: "ListList",
                column: "ParentListsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListHierarchy");

            migrationBuilder.DropTable(
                name: "ListList");
        }
    }
}
