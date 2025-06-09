using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Qimmah.Migrations
{
    /// <inheritdoc />
    public partial class addlocl2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 46, 1 },
                column: "Description",
                value: "join the summit team as a volunteer and be at the heart of the Arab world’s largest innovation and technology event. Gain experience, build valuable connections, and make real impact — from Jordan to the entire Arab region.");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 46, 2 },
                column: "Description",
                value: "انضم إلى فريق القمة كمتطوع، وكن في قلب أكبر حدث عربي للابتكار والتكنولوجيا.   خبرات، شبكة علاقات، وأثر حقيقي... من أرض الأردن إلى كل العالم العربي.");

            migrationBuilder.InsertData(
                schema: "Localization",
                table: "DictionaryLocalization",
                columns: new[] { "ID", "LanguageID", "Description" },
                values: new object[,]
                {
                    { 111, 1, "Join the Team" },
                    { 111, 2, "انضم الى الفريق" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 111, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 111, 2 });

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 46, 1 },
                column: "Description",
                value: "Join the summit team as a volunteer and be at the heart of the Arab world’s");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 46, 2 },
                column: "Description",
                value: "انضم كمتطوع في فريق القمة، وكن في قلب حدث من أكثر الأحداث تأثيراً في الابتكار والتكنولوجيا في العالم العربي");
        }
    }
}
