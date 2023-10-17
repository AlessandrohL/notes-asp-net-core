using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo_app.Migrations
{
    public partial class AddedRelationNoteTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoteTag",
                columns: table => new
                {
                    NoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteTag", x => new { x.NoteId, x.TagId });
                    table.ForeignKey(
                        name: "FK_NoteTag_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoteTag_TagId",
                table: "NoteTag",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteTag");
        }
    }
}
