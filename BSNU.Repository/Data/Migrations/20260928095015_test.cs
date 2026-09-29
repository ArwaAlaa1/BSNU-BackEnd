using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSNU.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AdmissionDocuments_AdmissionRuleId",
                table: "AdmissionDocuments");

            migrationBuilder.AddColumn<int>(
                name: "sectorId",
                table: "TuitionFee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TuitionFee_sectorId",
                table: "TuitionFee",
                column: "sectorId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionDocuments_AdmissionRuleId",
                table: "AdmissionDocuments",
                column: "AdmissionRuleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TuitionFee_Sectors_sectorId",
                table: "TuitionFee",
                column: "sectorId",
                principalTable: "Sectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TuitionFee_Sectors_sectorId",
                table: "TuitionFee");

            migrationBuilder.DropIndex(
                name: "IX_TuitionFee_sectorId",
                table: "TuitionFee");

            migrationBuilder.DropIndex(
                name: "IX_AdmissionDocuments_AdmissionRuleId",
                table: "AdmissionDocuments");

            migrationBuilder.DropColumn(
                name: "sectorId",
                table: "TuitionFee");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionDocuments_AdmissionRuleId",
                table: "AdmissionDocuments",
                column: "AdmissionRuleId");
        }
    }
}
