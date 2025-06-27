using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qimmah.Migrations
{
    /// <inheritdoc />
    public partial class pendingMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Activities",
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 1L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2025, 6, 27, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 27, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Activities",
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 2L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2025, 6, 28, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 28, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Activities",
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 3L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2025, 6, 29, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 29, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Activities",
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 4L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2025, 7, 4, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 7, 4, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Activities",
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 5L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2025, 7, 6, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 7, 6, 10, 0, 0, 0, DateTimeKind.Local) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
