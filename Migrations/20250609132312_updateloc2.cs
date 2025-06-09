using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qimmah.Migrations
{
    /// <inheritdoc />
    public partial class updateloc2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 31, 1 },
                column: "Description",
                value: "The Arab Youth Innovation & Technology Summit (AYITS) is a leading regional platform that brings together young innovators, decision-makers, and experts in one place to redefine the role of youth in driving digital transformation and sustainable development. Held in Amman — the Arab Youth Capital 2025 — under the umbrella of the League of Arab States, the summit serves as a unique meeting point between youthful energy and institutional opportunities, generating real solutions to the Arab world’s most pressing challenges.");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 31, 2 },
                column: "Description",
                value: "قمة الابتكار والتكنولوجيا للشباب العربي هي منصة إقليمية رائدة، تجمع الشباب المبتكرين وصنّاع القرار والخبراء في مكان واحد، لإعادة تعريف دور الشباب في قيادة التحول الرقمي والتنمية المستدامة.\r\nتنعقد القمة في عمّان، عاصمة الشباب العربي 2025، تحت مظلة جامعة الدول العربية، وتُعد نقطة التقاء استثنائية بين الطاقات الشابة والفرص المؤسسية لتوليد حلول فعلية لتحديات العالم العربي.");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 33, 1 },
                column: "Description",
                value: "Because youth are the true engine of change in our societies. The summit is rooted in a deep belief that investing in the technical and creative potential of young people is not optional — it is a strategic necessity. With youth unemployment in the Arab world exceeding 25%, AYITS serves as a practical platform to turn challenges into opportunities and accelerate the shift toward a productive, fair, and sustainable digital economy");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 33, 2 },
                column: "Description",
                value: "لأن الشباب هم المحرّك الحقيقي للتغيير في مجتمعاتنا. \r\nتنطلق القمة من إيمان عميق بأن الاستثمار في قدرات الشباب التقنية والإبداعية ليس خيارًا، بل ضرورة استراتيجية. فمع ارتفاع نسبة البطالة في العالم العربي إلى أكثر من 25%، تصبح القمة منصة عملية لتحويل التحديات إلى فرص، وتسريع التحول نحو اقتصاد رقمي منتج وعادل ومستدام.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 31, 1 },
                column: "Description",
                value: "The Arab Youth Innovation & Technology Summit (AYITS) is a leading region");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 31, 2 },
                column: "Description",
                value: "قمة الابتكار والتكنولوجيا للشباب العرب (AYITS) هي منصة إقليمية رائدة");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 33, 1 },
                column: "Description",
                value: "Because youth are the true engine of change in our societies. The summit is");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 33, 2 },
                column: "Description",
                value: "لأن الشباب هم المحرك الفعلي للتغيير في مجتمعاتنا. القمة هي إيمان حقيقي باستثمار قدرات الشباب العربي النهائية لقيادة بل");
        }
    }
}
