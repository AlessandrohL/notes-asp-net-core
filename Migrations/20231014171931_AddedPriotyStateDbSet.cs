using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo_app.Migrations
{
    public partial class AddedPriotyStateDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Priority_PriorityId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_State_StateId",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_State",
                table: "State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Priority",
                table: "Priority");

            migrationBuilder.RenameTable(
                name: "State",
                newName: "States");

            migrationBuilder.RenameTable(
                name: "Priority",
                newName: "Priorities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "States",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Priorities",
                table: "Priorities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Priorities_PriorityId",
                table: "Notes",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_States_StateId",
                table: "Notes",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Priorities_PriorityId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_States_StateId",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Priorities",
                table: "Priorities");

            migrationBuilder.RenameTable(
                name: "States",
                newName: "State");

            migrationBuilder.RenameTable(
                name: "Priorities",
                newName: "Priority");

            migrationBuilder.AddPrimaryKey(
                name: "PK_State",
                table: "State",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Priority",
                table: "Priority",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Priority_PriorityId",
                table: "Notes",
                column: "PriorityId",
                principalTable: "Priority",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_State_StateId",
                table: "Notes",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
