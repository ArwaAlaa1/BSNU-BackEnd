using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSNU.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProgramEntite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Programs_ProgramId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_Programs_AspNetUsers_UserId",
                table: "Programs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Programs",
                table: "Programs");

            migrationBuilder.RenameTable(
                name: "Programs",
                newName: "Program");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Program",
                newName: "jopTitel");

            migrationBuilder.RenameIndex(
                name: "IX_Programs_UserId",
                table: "Program",
                newName: "IX_Program_UserId");

            migrationBuilder.AddColumn<string>(
                name: "AcadamicDegree",
                table: "Program",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreditHour",
                table: "Program",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "Program",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Goals",
                table: "Program",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mission",
                table: "Program",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumberOfStudents",
                table: "Program",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Vision",
                table: "Program",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Program",
                table: "Program",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Programtabels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditsHours = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programtabels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programtabels_Program_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Program",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programtabels_ProgramId",
                table: "Programtabels",
                column: "ProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Program_ProgramId",
                table: "News",
                column: "ProgramId",
                principalTable: "Program",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Program_AspNetUsers_UserId",
                table: "Program",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Program_ProgramId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_Program_AspNetUsers_UserId",
                table: "Program");

            migrationBuilder.DropTable(
                name: "Programtabels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Program",
                table: "Program");

            migrationBuilder.DropColumn(
                name: "AcadamicDegree",
                table: "Program");

            migrationBuilder.DropColumn(
                name: "CreditHour",
                table: "Program");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Program");

            migrationBuilder.DropColumn(
                name: "Goals",
                table: "Program");

            migrationBuilder.DropColumn(
                name: "Mission",
                table: "Program");

            migrationBuilder.DropColumn(
                name: "NumberOfStudents",
                table: "Program");

            migrationBuilder.DropColumn(
                name: "Vision",
                table: "Program");

            migrationBuilder.RenameTable(
                name: "Program",
                newName: "Programs");

            migrationBuilder.RenameColumn(
                name: "jopTitel",
                table: "Programs",
                newName: "Description");

            migrationBuilder.RenameIndex(
                name: "IX_Program_UserId",
                table: "Programs",
                newName: "IX_Programs_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Programs",
                table: "Programs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Programs_ProgramId",
                table: "News",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Programs_AspNetUsers_UserId",
                table: "Programs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
