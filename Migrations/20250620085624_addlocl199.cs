using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Qimmah.Migrations
{
    /// <inheritdoc />
    public partial class addlocl199 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Localization",
                table: "DictionaryLocalization",
                columns: new[] { "ID", "LanguageID", "Description" },
                values: new object[,]
                {
                    { 126, 1, "Be a strategic partner in the Innovation and Technology Summit 2025" },
                    { 126, 2, "كن شريكًا استراتيجيًا في قمة الابتكار والتكنولوجيا 2025" },
                    { 127, 1, "The Innovation and Technology Summit invites all leading entities – companies, universities, organizations, media or government institutions – to join as strategic partners in supporting and empowering Arab youth in digital transformation, innovation, and entrepreneurship" },
                    { 127, 2, "تدعو قمة الابتكار والتكنولوجيا جميع الجهات الرائدة – شركات، جامعات، منظمات، مؤسسات إعلامية أو حكومية – إلى الانضمام كشركاء استراتيجيين في دعم وتمكين شباب الوطن العربي في التحول الرقمي، الابتكار، والريادة" },
                    { 128, 1, "Apply now as a strategic partner" },
                    { 128, 2, "قدّم الآن كشريك استراتيجي" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 126, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 126, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 127, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 127, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 128, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 128, 2 });
        }
    }
}
