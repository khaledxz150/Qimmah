using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Qimmah.Migrations
{
    /// <inheritdoc />
    public partial class addlocal13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 3, 1 },
                column: "Description",
                value: "We Innovate Today To Lead Tomorrow");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 3, 2 },
                column: "Description",
                value: "نبتكر اليوم لنقود الغد");

            migrationBuilder.InsertData(
                schema: "Localization",
                table: "DictionaryLocalization",
                columns: new[] { "ID", "LanguageID", "Description" },
                values: new object[,]
                {
                    { 245, 1, "Coming Soon..." },
                    { 245, 2, "قريباً..." },
                    { 246, 1, "No Data" },
                    { 246, 2, "لا يجود بيانات" }
                });

            migrationBuilder.UpdateData(
                schema: "Activities",
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 1L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2025, 6, 22, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 22, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Activities",
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 2L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2025, 6, 23, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 23, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Activities",
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 3L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2025, 6, 24, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 24, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Activities",
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 4L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2025, 6, 29, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 29, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Activities",
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 5L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 7, 1, 10, 0, 0, 0, DateTimeKind.Local) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 245, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 245, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 246, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 246, 2 });

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 3, 1 },
                column: "Description",
                value: "Begin your journey toward an Arab future led by innovation");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 3, 2 },
                column: "Description",
                value: "ابدأ رحلتك نحو مستقبل عربي تقوده الابتكار");

            migrationBuilder.UpdateData(
                schema: "Activities",
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 1L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2025, 6, 21, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 21, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Activities",
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 2L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2025, 6, 22, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 22, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Activities",
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 3L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2025, 6, 23, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 23, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Activities",
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 4L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2025, 6, 28, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 28, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Activities",
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 5L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2025, 6, 30, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 30, 10, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
