using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Qimmah.Migrations
{
    /// <inheritdoc />
    public partial class connectUsersAndPrograms2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsCurrentlyBroadcasting",
                schema: "Activities",
                table: "Sessions",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Activities",
                table: "Sessions",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                schema: "Activities",
                table: "Sessions",
                columns: new[] { "ID", "EndDateTime", "IsActive", "IsCurrentlyBroadcasting", "IsDeleted", "LiveBroadcastLink", "ProgramId", "StartDateTime" },
                values: new object[] { 1L, new DateTime(2025, 6, 20, 12, 0, 0, 0, DateTimeKind.Local), true, true, false, "https://www.youtube.com/watch?v=dQw4w9WgXcQ", 1L, new DateTime(2025, 6, 20, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                schema: "Activities",
                table: "Sessions",
                columns: new[] { "ID", "EndDateTime", "IsDeleted", "LiveBroadcastLink", "ProgramId", "StartDateTime" },
                values: new object[,]
                {
                    { 2L, new DateTime(2025, 6, 21, 12, 0, 0, 0, DateTimeKind.Local), false, "https://www.youtube.com/watch?v=example2", 1L, new DateTime(2025, 6, 21, 10, 0, 0, 0, DateTimeKind.Local) },
                    { 3L, new DateTime(2025, 6, 22, 12, 0, 0, 0, DateTimeKind.Local), false, "https://www.youtube.com/watch?v=example3", 1L, new DateTime(2025, 6, 22, 10, 0, 0, 0, DateTimeKind.Local) },
                    { 4L, new DateTime(2025, 6, 27, 12, 0, 0, 0, DateTimeKind.Local), false, "https://www.youtube.com/watch?v=example4", 1L, new DateTime(2025, 6, 27, 10, 0, 0, 0, DateTimeKind.Local) },
                    { 5L, new DateTime(2025, 6, 29, 12, 0, 0, 0, DateTimeKind.Local), false, "https://www.youtube.com/watch?v=example5", 1L, new DateTime(2025, 6, 29, 10, 0, 0, 0, DateTimeKind.Local) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 5L);

            migrationBuilder.AlterColumn<bool>(
                name: "IsCurrentlyBroadcasting",
                schema: "Activities",
                table: "Sessions",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Activities",
                table: "Sessions",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);
        }
    }
}
