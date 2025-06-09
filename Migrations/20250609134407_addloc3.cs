using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Qimmah.Migrations
{
    /// <inheritdoc />
    public partial class addloc3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 35, 1 },
                column: "Description",
                value: "AYITS is not about words or slogans — it delivers real, actionable outcomes that translate into policies, platforms, and initiatives.\r\nKey outcomes include:");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 35, 2 },
                column: "Description",
                value: "لا تقتصر القمة على الكلمات أو الشعارات، بل تُطلق مخرجات عملية ملموسة تُترجم إلى سياسات، منصات، ومبادرات تشمل هذه المخرجات:");

            migrationBuilder.InsertData(
                schema: "Localization",
                table: "DictionaryLocalization",
                columns: new[] { "ID", "LanguageID", "Description" },
                values: new object[,]
                {
                    { 100, 1, "Launching the Arab Youth Innovation Platform" },
                    { 100, 2, "إطلاق منصة الشباب العربي للابتكار" },
                    { 101, 1, "Signing funding agreements and strategic partnerships" },
                    { 101, 2, "توقيع اتفاقيات تمويل وشراكة استراتيجية" },
                    { 102, 1, "Publishing the 'State of Arab Innovation' report" },
                    { 102, 2, "إصدار تقرير \"حالة الابتكار العربي\"" },
                    { 103, 1, "Establishing the Arab Council for Innovation" },
                    { 103, 2, "تأسيس المجلس العربي للإبداع" },
                    { 104, 1, "Launching an annual innovation journal and index" },
                    { 104, 2, "إطلاق مجلة ومؤشر ابتكار سنوي" },
                    { 105, 1, "Turning the summit into a recurring regional tradition" },
                    { 105, 2, "تحويل القمة إلى تقليد إقليمي دائم" },
                    { 106, 1, "Developing practical training and employment programs" },
                    { 106, 2, "تطوير برامج تدريب وتوظيف فعلي" },
                    { 107, 1, "Implementing the recommendations of the 'Amman Declaration'" },
                    { 107, 2, "تفعيل توصيات \"إعلان عمّان\"" },
                    { 108, 1, "Advancing digital sovereignty and smart currencies" },
                    { 108, 2, "دعم السيادة الرقمية والعملات الذكية" },
                    { 109, 1, "Improving Arab and Jordanian performance indicators in innovation, environment, and education" },
                    { 109, 2, "رفع مؤشرات الأداء الأردني والعربي في الابتكار والبيئة والتعليم" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 100, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 100, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 101, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 101, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 102, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 102, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 103, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 103, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 104, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 104, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 105, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 105, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 106, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 106, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 107, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 107, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 108, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 108, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 109, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 109, 2 });

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 35, 1 },
                column: "Description",
                value: "AYITS is not about words or slogans — it delivers real, actionable");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 35, 2 },
                column: "Description",
                value: "قمة AYITS ليست مجرد شعارات، بل منصة حقيقية تقدم نتائج ملموسة قابلة للتطبيق");
        }
    }
}
