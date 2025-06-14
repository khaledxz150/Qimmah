using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qimmah.Migrations
{
    /// <inheritdoc />
    public partial class addlocalization3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 185, 1 },
                column: "Description",
                value: "Don't have an account?");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 185, 2 },
                column: "Description",
                value: "ليس لديك حساب؟");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 186, 1 },
                column: "Description",
                value: "Register Now");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 186, 2 },
                column: "Description",
                value: "سجل الآن");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 185, 1 },
                column: "Description",
                value: "Have An Account?");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 185, 2 },
                column: "Description",
                value: "لديك حساب؟");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 186, 1 },
                column: "Description",
                value: "Login Now");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 186, 2 },
                column: "Description",
                value: "سجل الدخول الآن");
        }
    }
}
