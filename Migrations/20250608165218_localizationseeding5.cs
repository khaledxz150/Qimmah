using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qimmah.Migrations
{
    /// <inheritdoc />
    public partial class localizationseeding5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 26, 1 },
                column: "Description",
                value: "To empower Arab youth to lead the region’s digital transformation through an open knowledge ecosystem, strategic partnership networks, and innovative support for promising projects—while strengthening their role in technology policymaking and shaping a sustainable future through technology.");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 26, 2 },
                column: "Description",
                value: "تمكين الشباب العربي من قيادة التحول الرقمي في المنطقة عبر بيئة معرفية مفتوحة، شبكات شراكة استراتيجية، ودعم مبتكر للمشاريع الواعدة، مع تعزيز دورهم في السياسات التقنية وصناعة مستقبل مستدام بالتكنولوجيا.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 26, 1 },
                column: "Description",
                value: "To empower Arab youth to lead the region’s digital transformation through a");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 26, 2 },
                column: "Description",
                value: "تمكين الشباب العربي من قيادة التحول الرقمي في المنطقة عبر مبادرة معرفية محكومة بشراكة أوسع");
        }
    }
}
