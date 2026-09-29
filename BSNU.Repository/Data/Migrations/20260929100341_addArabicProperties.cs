using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSNU.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class addArabicProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vision",
                table: "Programs",
                newName: "VisionEn");

            migrationBuilder.RenameColumn(
                name: "StudySystem",
                table: "Programs",
                newName: "VisionAr");

            migrationBuilder.RenameColumn(
                name: "Mission",
                table: "Programs",
                newName: "VideoPath");

            migrationBuilder.RenameColumn(
                name: "JobTitles",
                table: "Programs",
                newName: "StudySystemEn");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Programs",
                newName: "StudySystemAr");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Programs",
                newName: "MissionEn");

            migrationBuilder.RenameColumn(
                name: "CreditHours",
                table: "Programs",
                newName: "CreditHoursEn");

            migrationBuilder.RenameColumn(
                name: "AcademicDegree",
                table: "Programs",
                newName: "MissionAr");

            migrationBuilder.RenameColumn(
                name: "JobTitle",
                table: "AspNetUsers",
                newName: "JobTitleEn");

            migrationBuilder.AddColumn<string>(
                name: "AcademicDegreeAr",
                table: "Programs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AcademicDegreeEn",
                table: "Programs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Programs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "CreditHoursAr",
                table: "Programs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DurationAr",
                table: "Programs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DurationEn",
                table: "Programs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Programs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Programs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "JobTitlesAr",
                table: "Programs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobTitlesEn",
                table: "Programs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Programs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "JobTitleAr",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ProgramImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramImage_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramImage_ProgramId",
                table: "ProgramImage",
                column: "ProgramId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramImage");

            migrationBuilder.DropColumn(
                name: "AcademicDegreeAr",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "AcademicDegreeEn",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "CreditHoursAr",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "DurationAr",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "DurationEn",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "JobTitlesAr",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "JobTitlesEn",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "JobTitleAr",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "VisionEn",
                table: "Programs",
                newName: "Vision");

            migrationBuilder.RenameColumn(
                name: "VisionAr",
                table: "Programs",
                newName: "StudySystem");

            migrationBuilder.RenameColumn(
                name: "VideoPath",
                table: "Programs",
                newName: "Mission");

            migrationBuilder.RenameColumn(
                name: "StudySystemEn",
                table: "Programs",
                newName: "JobTitles");

            migrationBuilder.RenameColumn(
                name: "StudySystemAr",
                table: "Programs",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "MissionEn",
                table: "Programs",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "MissionAr",
                table: "Programs",
                newName: "AcademicDegree");

            migrationBuilder.RenameColumn(
                name: "CreditHoursEn",
                table: "Programs",
                newName: "CreditHours");

            migrationBuilder.RenameColumn(
                name: "JobTitleEn",
                table: "AspNetUsers",
                newName: "JobTitle");
        }
    }
}
