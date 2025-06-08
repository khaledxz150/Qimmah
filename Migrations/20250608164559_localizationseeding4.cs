using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qimmah.Migrations
{
    /// <inheritdoc />
    public partial class localizationseeding4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 24, 1 },
                column: "Description",
                value: "By 2030, AYITS will stand as a pivotal turning point that redefined the role of Arab youth as leaders in the global digital economy. It will serve as an integrated platform that unites innovation and technology efforts across the Arab world, leading the region toward excellence in the sustainable knowledge economy.");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 24, 2 },
                column: "Description",
                value: "بحلول 2030، تصبح AYITS نقطة التحول المفصلية التي أعادت تعريف دور الشباب العربي كقادة للاقتصاد الرقمي العالمي، ومنصة متكاملة توحد جهود الابتكار والتكنولوجيا في العالم العربي لتقود المنطقة نحو الريادة في الاقتصاد المعرفي المستدام.  (المعلومات التالية بناءا على ملف الخطة الاستراتيجية)");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 28, 1 },
                column: "Description",
                value: "AYITS 2025 aspires to turn its vision into tangible outcomes through a set of strategic objectives, including:");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 29, 1 },
                column: "Description",
                value: "Launching cross-border Arab projects and alliances");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 29, 2 },
                column: "Description",
                value: "إطلاق مشاريع وتحالفات عربية عابرة للحدود");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 24, 1 },
                column: "Description",
                value: "By 2030, AYITS will stand as a pivotal turning point that redefined the role");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 24, 2 },
                column: "Description",
                value: "بحلول 2030، تصبح AYITS نقطة التحول المفصلية التي أعادت تعريف دور الشباب العربي كقادة التغيير");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 28, 1 },
                column: "Description",
                value: "AYITS 2025 aspires to turn its vision into tangible outcomes through a set");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 29, 1 },
                column: "Description",
                value: "of strategic objectives. include: • Launching cross-border Arab projects");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 29, 2 },
                column: "Description",
                value: "من الأهداف الاستراتيجية، إطلاق مشاريع عربية عابرة للحدود");
        }
    }
}
