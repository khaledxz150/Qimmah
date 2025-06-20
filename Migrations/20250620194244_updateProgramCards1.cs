using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Qimmah.Migrations
{
    /// <inheritdoc />
    public partial class updateProgramCards1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCurrentlyBroadCasting",
                schema: "Activities",
                table: "Programs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "Activities",
                table: " ProgramCategory_Localization",
                keyColumns: new[] { "LanguageID", "ProgramCategoryID" },
                keyValues: new object[] { 2, 1 },
                column: "Description",
                value: "برمج");

            migrationBuilder.InsertData(
                schema: "Localization",
                table: "DictionaryLocalization",
                columns: new[] { "ID", "LanguageID", "Description" },
                values: new object[,]
                {
                    { 235, 1, "Activities" },
                    { 235, 2, "الفعاليات" },
                    { 236, 1, "Activities And Programs" },
                    { 236, 2, "الفعاليات والبرامج" },
                    { 237, 1, "Showing {1} - {2}, We've Found {0} Activities For You" },
                    { 237, 2, "يتم عرض {1} – {2} ،لقد وجدنا {0}  الفعاليات متاحة لك" },
                    { 238, 1, "All Categories" },
                    { 238, 2, "جميع الفئات" },
                    { 239, 1, "Sort by" },
                    { 239, 2, "ترتيب حسب" },
                    { 240, 1, "Default" },
                    { 240, 2, "الافتراضي" },
                    { 241, 1, "Search" },
                    { 241, 2, "البحث" },
                    { 242, 1, "We found exactly {0} activities available for you" },
                    { 242, 2, "لقد وجدنا {0} فعاليات متاحة لك" },
                    { 243, 1, "Live Broadcast" },
                    { 243, 2, "البث المباشر" }
                });

            migrationBuilder.UpdateData(
                schema: "Activities",
                table: "Programs",
                keyColumn: "ID",
                keyValue: 1L,
                column: "IsCurrentlyBroadCasting",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 235, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 235, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 236, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 236, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 237, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 237, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 238, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 238, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 239, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 239, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 240, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 240, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 241, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 241, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 242, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 242, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 243, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 243, 2 });

            migrationBuilder.DropColumn(
                name: "IsCurrentlyBroadCasting",
                schema: "Activities",
                table: "Programs");

            migrationBuilder.UpdateData(
                schema: "Activities",
                table: " ProgramCategory_Localization",
                keyColumns: new[] { "LanguageID", "ProgramCategoryID" },
                keyValues: new object[] { 2, 1 },
                column: "Description",
                value: "تطوير الذات");
        }
    }
}
