using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Qimmah.Migrations
{
    /// <inheritdoc />
    public partial class addlocal14 : Migration
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
                    { 247, 1, "Developed By Coderz For Development And Training" },
                    { 247, 2, "تم التطوير من قبل كودرز للبرمجه والتدريب" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 247, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 247, 2 });
        }
    }
}
