using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSNU.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddImagesInSectorAndFaculty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionAr",
                table: "Sectors");

            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "Sectors");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Sectors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Sectors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Sectors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Sectors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Sectors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SubTitleAr",
                table: "Sectors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubTitleEn",
                table: "Sectors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Faculties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Faculties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Sectors");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Sectors");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Sectors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Sectors");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Sectors");

            migrationBuilder.DropColumn(
                name: "SubTitleAr",
                table: "Sectors");

            migrationBuilder.DropColumn(
                name: "SubTitleEn",
                table: "Sectors");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Faculties");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionAr",
                table: "Sectors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "Sectors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
