using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo_app.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoteTag_Notes_NoteId",
                table: "NoteTag");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteTag_Tags_TagId",
                table: "NoteTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NoteTag",
                table: "NoteTag");

            migrationBuilder.RenameTable(
                name: "NoteTag",
                newName: "NoteTags");

            migrationBuilder.RenameIndex(
                name: "IX_NoteTag_TagId",
                table: "NoteTags",
                newName: "IX_NoteTags_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NoteTags",
                table: "NoteTags",
                columns: new[] { "NoteId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_NoteTags_Notes_NoteId",
                table: "NoteTags",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NoteTags_Tags_TagId",
                table: "NoteTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoteTags_Notes_NoteId",
                table: "NoteTags");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteTags_Tags_TagId",
                table: "NoteTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NoteTags",
                table: "NoteTags");

            migrationBuilder.RenameTable(
                name: "NoteTags",
                newName: "NoteTag");

            migrationBuilder.RenameIndex(
                name: "IX_NoteTags_TagId",
                table: "NoteTag",
                newName: "IX_NoteTag_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NoteTag",
                table: "NoteTag",
                columns: new[] { "NoteId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_NoteTag_Notes_NoteId",
                table: "NoteTag",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NoteTag_Tags_TagId",
                table: "NoteTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
