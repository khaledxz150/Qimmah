using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qimmah.Migrations
{
    /// <inheritdoc />
    public partial class addlocalization6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "Language",
                keyColumn: "ID",
                keyValue: 2,
                column: "LanguageName",
                value: "العربية");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "Language",
                keyColumn: "ID",
                keyValue: 2,
                column: "LanguageName",
                value: "Arabic");
        }
    }
}
