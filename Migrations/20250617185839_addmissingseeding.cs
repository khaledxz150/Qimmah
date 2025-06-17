using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Qimmah.Migrations
{
    /// <inheritdoc />
    public partial class addmissingseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Calendar",
                table: "CalendarItems_Localization",
                keyColumns: new[] { "CalendarItemID", "LanguageID" },
                keyValues: new object[] { 1L, 1 });

            migrationBuilder.DeleteData(
                schema: "Calendar",
                table: "CalendarItems_Localization",
                keyColumns: new[] { "CalendarItemID", "LanguageID" },
                keyValues: new object[] { 2L, 1 });

            migrationBuilder.DeleteData(
                schema: "Calendar",
                table: "CalendarItems_Localization",
                keyColumns: new[] { "CalendarItemID", "LanguageID" },
                keyValues: new object[] { 3L, 1 });

            migrationBuilder.DeleteData(
                schema: "Calendar",
                table: "Timelines_Localization",
                keyColumns: new[] { "LanguageID", "TimelineID" },
                keyValues: new object[] { 1, 1L });

            migrationBuilder.DeleteData(
                schema: "Calendar",
                table: "Timelines_Localization",
                keyColumns: new[] { "LanguageID", "TimelineID" },
                keyValues: new object[] { 1, 2L });

            migrationBuilder.DeleteData(
                schema: "Calendar",
                table: "Timelines_Localization",
                keyColumns: new[] { "LanguageID", "TimelineID" },
                keyValues: new object[] { 1, 3L });

            migrationBuilder.DeleteData(
                schema: "Calendar",
                table: "Timelines_Localization",
                keyColumns: new[] { "LanguageID", "TimelineID" },
                keyValues: new object[] { 1, 4L });

            migrationBuilder.DeleteData(
                schema: "Calendar",
                table: "Timelines_Localization",
                keyColumns: new[] { "LanguageID", "TimelineID" },
                keyValues: new object[] { 1, 5L });

            migrationBuilder.InsertData(
                schema: "Calendar",
                table: "CalendarItems_Localization",
                columns: new[] { "CalendarItemID", "LanguageID", "DateDisplay", "Description" },
                values: new object[,]
                {
                    { 1L, 2, "15 أغسطس", "اليوم الأول" },
                    { 2L, 2, "16 أغسطس", "اليوم الثاني" },
                    { 3L, 2, "17 أغسطس", "اليوم الثالث" }
                });

            migrationBuilder.InsertData(
                schema: "Calendar",
                table: "Timelines_Localization",
                columns: new[] { "LanguageID", "TimelineID", "Description" },
                values: new object[,]
                {
                    { 2, 1L, "الجلسة الافتتاحية - كلمة ترحيبية من رئيس القمة" },
                    { 2, 2L, "عرض فيديو تفاعلي \"رحلة التغيير العربي\"" },
                    { 2, 3L, "الجلسة الأولى: التحول الرقمي في العالم العربي" },
                    { 2, 4L, "حوار شبابي: أصوات من الميدان" },
                    { 2, 5L, "ورش عمل تطبيقية: كيف نبدأ مشروعك المبتكر؟" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Calendar",
                table: "CalendarItems_Localization",
                keyColumns: new[] { "CalendarItemID", "LanguageID" },
                keyValues: new object[] { 1L, 2 });

            migrationBuilder.DeleteData(
                schema: "Calendar",
                table: "CalendarItems_Localization",
                keyColumns: new[] { "CalendarItemID", "LanguageID" },
                keyValues: new object[] { 2L, 2 });

            migrationBuilder.DeleteData(
                schema: "Calendar",
                table: "CalendarItems_Localization",
                keyColumns: new[] { "CalendarItemID", "LanguageID" },
                keyValues: new object[] { 3L, 2 });

            migrationBuilder.DeleteData(
                schema: "Calendar",
                table: "Timelines_Localization",
                keyColumns: new[] { "LanguageID", "TimelineID" },
                keyValues: new object[] { 2, 1L });

            migrationBuilder.DeleteData(
                schema: "Calendar",
                table: "Timelines_Localization",
                keyColumns: new[] { "LanguageID", "TimelineID" },
                keyValues: new object[] { 2, 2L });

            migrationBuilder.DeleteData(
                schema: "Calendar",
                table: "Timelines_Localization",
                keyColumns: new[] { "LanguageID", "TimelineID" },
                keyValues: new object[] { 2, 3L });

            migrationBuilder.DeleteData(
                schema: "Calendar",
                table: "Timelines_Localization",
                keyColumns: new[] { "LanguageID", "TimelineID" },
                keyValues: new object[] { 2, 4L });

            migrationBuilder.DeleteData(
                schema: "Calendar",
                table: "Timelines_Localization",
                keyColumns: new[] { "LanguageID", "TimelineID" },
                keyValues: new object[] { 2, 5L });

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
        }
    }
}
