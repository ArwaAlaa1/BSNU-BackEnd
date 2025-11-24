using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSNU.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserProgramRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Programs_ProgramId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Programs_AspNetUsers_ManagerId",
                table: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Programs_ManagerId",
                table: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProgramId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "ProgramId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Programs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_UserId",
                table: "Programs",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Programs_AspNetUsers_UserId",
                table: "Programs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programs_AspNetUsers_UserId",
                table: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Programs_UserId",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Programs");

            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "Programs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProgramId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Programs_ManagerId",
                table: "Programs",
                column: "ManagerId",
                unique: true,
                filter: "[ManagerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProgramId",
                table: "AspNetUsers",
                column: "ProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Programs_ProgramId",
                table: "AspNetUsers",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Programs_AspNetUsers_ManagerId",
                table: "Programs",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
