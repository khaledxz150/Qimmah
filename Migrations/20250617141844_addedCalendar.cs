using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Qimmah.Migrations
{
    /// <inheritdoc />
    public partial class addedCalendar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Calendar");

            migrationBuilder.CreateTable(
                name: "CalendarItems",
                schema: "Calendar",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayNumber = table.Column<int>(type: "int", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarItems", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CalendarItems_Localization",
                schema: "Calendar",
                columns: table => new
                {
                    LanguageID = table.Column<int>(type: "int", nullable: false),
                    CalendarItemID = table.Column<long>(type: "bigint", nullable: false),
                    DateDisplay = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarItems_Localization", x => new { x.LanguageID, x.CalendarItemID });
                    table.ForeignKey(
                        name: "FK_CalendarItems_Localization_CalendarItems_CalendarItemID",
                        column: x => x.CalendarItemID,
                        principalSchema: "Calendar",
                        principalTable: "CalendarItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalendarItems_Localization_Language_LanguageID",
                        column: x => x.LanguageID,
                        principalSchema: "Localization",
                        principalTable: "Language",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Timelines",
                schema: "Calendar",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalendarItemID = table.Column<long>(type: "bigint", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timelines", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Timelines_CalendarItems_CalendarItemID",
                        column: x => x.CalendarItemID,
                        principalSchema: "Calendar",
                        principalTable: "CalendarItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Timelines_Localization",
                schema: "Calendar",
                columns: table => new
                {
                    LanguageID = table.Column<int>(type: "int", nullable: false),
                    TimelineID = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timelines_Localization", x => new { x.LanguageID, x.TimelineID });
                    table.ForeignKey(
                        name: "FK_Timelines_Localization_Language_LanguageID",
                        column: x => x.LanguageID,
                        principalSchema: "Localization",
                        principalTable: "Language",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Timelines_Localization_Timelines_TimelineID",
                        column: x => x.TimelineID,
                        principalSchema: "Calendar",
                        principalTable: "Timelines",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Calendar",
                table: "CalendarItems",
                columns: new[] { "ID", "DayNumber", "EventDate", "IsActive", "IsDeleted", "SortOrder" },
                values: new object[,]
                {
                    { 1L, 1, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, 1 },
                    { 2L, 2, new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, 2 },
                    { 3L, 3, new DateTime(2024, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, 3 }
                });

            migrationBuilder.InsertData(
                schema: "Calendar",
                table: "CalendarItems_Localization",
                columns: new[] { "CalendarItemID", "LanguageID", "DateDisplay", "Description" },
                values: new object[,]
                {
                    { 1L, 1, "15 أغسطس", "اليوم الأول" },
                    { 2L, 1, "16 أغسطس", "اليوم الثاني" },
                    { 3L, 1, "17 أغسطس", "اليوم الثالث" }
                });

            migrationBuilder.InsertData(
                schema: "Calendar",
                table: "Timelines",
                columns: new[] { "ID", "CalendarItemID", "EndTime", "IsActive", "IsDeleted", "SortOrder", "StartTime" },
                values: new object[,]
                {
                    { 1L, 1L, new TimeSpan(0, 10, 0, 0, 0), true, false, 1, new TimeSpan(0, 9, 0, 0, 0) },
                    { 2L, 1L, new TimeSpan(0, 10, 30, 0, 0), true, false, 2, new TimeSpan(0, 10, 0, 0, 0) },
                    { 3L, 1L, new TimeSpan(0, 11, 30, 0, 0), true, false, 3, new TimeSpan(0, 10, 30, 0, 0) },
                    { 4L, 1L, new TimeSpan(0, 13, 0, 0, 0), true, false, 4, new TimeSpan(0, 12, 0, 0, 0) },
                    { 5L, 1L, new TimeSpan(0, 15, 0, 0, 0), true, false, 5, new TimeSpan(0, 13, 0, 0, 0) },
                    { 6L, 2L, new TimeSpan(0, 10, 30, 0, 0), true, false, 1, new TimeSpan(0, 9, 0, 0, 0) },
                    { 7L, 2L, new TimeSpan(0, 12, 0, 0, 0), true, false, 2, new TimeSpan(0, 10, 30, 0, 0) },
                    { 8L, 2L, new TimeSpan(0, 14, 30, 0, 0), true, false, 3, new TimeSpan(0, 13, 0, 0, 0) },
                    { 9L, 2L, new TimeSpan(0, 16, 0, 0, 0), true, false, 4, new TimeSpan(0, 14, 30, 0, 0) },
                    { 10L, 3L, new TimeSpan(0, 11, 0, 0, 0), true, false, 1, new TimeSpan(0, 9, 0, 0, 0) },
                    { 11L, 3L, new TimeSpan(0, 12, 30, 0, 0), true, false, 2, new TimeSpan(0, 11, 0, 0, 0) },
                    { 12L, 3L, new TimeSpan(0, 15, 0, 0, 0), true, false, 3, new TimeSpan(0, 13, 30, 0, 0) }
                });

            migrationBuilder.InsertData(
                schema: "Calendar",
                table: "Timelines_Localization",
                columns: new[] { "LanguageID", "TimelineID", "Description" },
                values: new object[,]
                {
                    { 1, 1L, "الجلسة الافتتاحية - كلمة ترحيبية من رئيس القمة" },
                    { 1, 2L, "عرض فيديو تفاعلي \"رحلة التغيير العربي\"" },
                    { 1, 3L, "الجلسة الأولى: التحول الرقمي في العالم العربي" },
                    { 1, 4L, "حوار شبابي: أصوات من الميدان" },
                    { 1, 5L, "ورش عمل تطبيقية: كيف نبدأ مشروعك المبتكر؟" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalendarItems_Localization_CalendarItemID",
                schema: "Calendar",
                table: "CalendarItems_Localization",
                column: "CalendarItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Timelines_CalendarItemID_StartTime",
                schema: "Calendar",
                table: "Timelines",
                columns: new[] { "CalendarItemID", "StartTime" });

            migrationBuilder.CreateIndex(
                name: "IX_Timelines_ID_CalendarItemID",
                schema: "Calendar",
                table: "Timelines",
                columns: new[] { "ID", "CalendarItemID" });

            migrationBuilder.CreateIndex(
                name: "IX_Timelines_Localization_TimelineID",
                schema: "Calendar",
                table: "Timelines_Localization",
                column: "TimelineID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalendarItems_Localization",
                schema: "Calendar");

            migrationBuilder.DropTable(
                name: "Timelines_Localization",
                schema: "Calendar");

            migrationBuilder.DropTable(
                name: "Timelines",
                schema: "Calendar");

            migrationBuilder.DropTable(
                name: "CalendarItems",
                schema: "Calendar");
        }
    }
}
