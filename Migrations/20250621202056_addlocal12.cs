using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Qimmah.Migrations
{
    /// <inheritdoc />
    public partial class addlocal12 : Migration
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
                    { 244, 1, "Sorry, something went wrong, please try again later." },
                    { 244, 2, "عذرا، حدث خطأ ما يرجى المعاودة لاحقا." }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 244, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 244, 2 });

            migrationBuilder.UpdateData(
                schema: "Activities",
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 1L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2025, 6, 20, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 20, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Activities",
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 2L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2025, 6, 21, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 21, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Activities",
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 3L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2025, 6, 22, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 22, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Activities",
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 4L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2025, 6, 27, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 27, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Activities",
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 5L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2025, 6, 29, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 29, 10, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
