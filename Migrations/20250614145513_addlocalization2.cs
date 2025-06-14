using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qimmah.Migrations
{
    /// <inheritdoc />
    public partial class addlocalization2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 183, 1 },
                column: "Description",
                value: "Have An Account?");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 183, 2 },
                column: "Description",
                value: "لديك حساب؟");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 184, 1 },
                column: "Description",
                value: "Login Now");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 184, 2 },
                column: "Description",
                value: "سجل الدخول الآن");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 183, 1 },
                column: "Description",
                value: "لديك حساب؟");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 183, 2 },
                column: "Description",
                value: "Have An Account?");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 184, 1 },
                column: "Description",
                value: "سجل الدخول الآن");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 184, 2 },
                column: "Description",
                value: "Login Now");
        }
    }
}
