using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Qimmah.Migrations
{
    /// <inheritdoc />
    public partial class addProgramGoalsAndComponents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoalText",
                schema: "Activities",
                table: "ProgramGoals_Localization");

            migrationBuilder.DropColumn(
                name: "ComponentText",
                schema: "Activities",
                table: "ProgramComponents_Localization");

            migrationBuilder.InsertData(
                schema: "Activities",
                table: "ProgramComponents",
                columns: new[] { "Id", "ProgramId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 2L, 1L },
                    { 3L, 1L }
                });

            migrationBuilder.InsertData(
                schema: "Activities",
                table: "ProgramGoals",
                columns: new[] { "Id", "ProgramId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 2L, 1L },
                    { 3L, 1L },
                    { 4L, 1L },
                    { 5L, 1L },
                    { 6L, 1L },
                    { 7L, 1L },
                    { 8L, 1L }
                });

            migrationBuilder.InsertData(
                schema: "Activities",
                table: "ProgramComponents_Localization",
                columns: new[] { "LanguageID", "ProgramComponentID", "Description" },
                values: new object[,]
                {
                    { 1, 1L, "Training sessions and workshops for programming languages, UI design, and startup tools" },
                    { 2, 1L, "جلسات تدريبية وورشات عمل لتعليم لغات برمجة، تصميم واجهات، وأدوات تطوير المشاريع الناشئة" },
                    { 1, 2L, "Multi-day tech competition for creative solutions in teams, with prizes for top three" },
                    { 2, 2L, "مسابقة تقنية تمتد لعدة أيام لتطوير حلول تقنية إبداعية ضمن فرق، مع جوائز للمراكز الثلاثة الأولى" },
                    { 1, 3L, "Building collaborative project platforms and interaction with visitors and mentors" },
                    { 2, 3L, "بناء منصات المشاريع المشتركة والتفاعل مع الزوار والمستشارين" }
                });

            migrationBuilder.InsertData(
                schema: "Activities",
                table: "ProgramGoals_Localization",
                columns: new[] { "LanguageID", "ProgramGoalID", "Description" },
                values: new object[,]
                {
                    { 1, 1L, "Enable participants in programming basics" },
                    { 2, 1L, "تمكين المشاركين من أساسيات البرمجة" },
                    { 1, 2L, "Foster innovation in technical solutions" },
                    { 2, 2L, "تعزيز الابتكار في الحلول التقنية" },
                    { 1, 3L, "Encourage teamwork and competition" },
                    { 2, 3L, "تحفيز روح العمل الجماعي والمنافسة" },
                    { 1, 4L, "Connect participants with industry experts and mentors" },
                    { 2, 4L, "ربط المشاركين بأهل الصناعة والمستشارين" },
                    { 1, 5L, "Foster innovation in technical solutions" },
                    { 2, 5L, "تعزيز الابتكار في الحلول التقنية" },
                    { 1, 6L, "Encourage teamwork and competition" },
                    { 2, 6L, "تحفيز روح العمل الجماعي والمنافسة" },
                    { 1, 7L, "Connect participants with industry experts and mentors" },
                    { 2, 7L, "ربط المشاركين بأهل الصناعة والمستشارين" },
                    { 1, 8L, "Enable participants in programming basics" },
                    { 2, 8L, "تمكين المشاركين من أساسيات البرمجة" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramComponents_Localization",
                keyColumns: new[] { "LanguageID", "ProgramComponentID" },
                keyValues: new object[] { 1, 1L });

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramComponents_Localization",
                keyColumns: new[] { "LanguageID", "ProgramComponentID" },
                keyValues: new object[] { 2, 1L });

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramComponents_Localization",
                keyColumns: new[] { "LanguageID", "ProgramComponentID" },
                keyValues: new object[] { 1, 2L });

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramComponents_Localization",
                keyColumns: new[] { "LanguageID", "ProgramComponentID" },
                keyValues: new object[] { 2, 2L });

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramComponents_Localization",
                keyColumns: new[] { "LanguageID", "ProgramComponentID" },
                keyValues: new object[] { 1, 3L });

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramComponents_Localization",
                keyColumns: new[] { "LanguageID", "ProgramComponentID" },
                keyValues: new object[] { 2, 3L });

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramGoals_Localization",
                keyColumns: new[] { "LanguageID", "ProgramGoalID" },
                keyValues: new object[] { 1, 1L });

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramGoals_Localization",
                keyColumns: new[] { "LanguageID", "ProgramGoalID" },
                keyValues: new object[] { 2, 1L });

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramGoals_Localization",
                keyColumns: new[] { "LanguageID", "ProgramGoalID" },
                keyValues: new object[] { 1, 2L });

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramGoals_Localization",
                keyColumns: new[] { "LanguageID", "ProgramGoalID" },
                keyValues: new object[] { 2, 2L });

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramGoals_Localization",
                keyColumns: new[] { "LanguageID", "ProgramGoalID" },
                keyValues: new object[] { 1, 3L });

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramGoals_Localization",
                keyColumns: new[] { "LanguageID", "ProgramGoalID" },
                keyValues: new object[] { 2, 3L });

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramGoals_Localization",
                keyColumns: new[] { "LanguageID", "ProgramGoalID" },
                keyValues: new object[] { 1, 4L });

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramGoals_Localization",
                keyColumns: new[] { "LanguageID", "ProgramGoalID" },
                keyValues: new object[] { 2, 4L });

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramGoals_Localization",
                keyColumns: new[] { "LanguageID", "ProgramGoalID" },
                keyValues: new object[] { 1, 5L });

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramGoals_Localization",
                keyColumns: new[] { "LanguageID", "ProgramGoalID" },
                keyValues: new object[] { 2, 5L });

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramGoals_Localization",
                keyColumns: new[] { "LanguageID", "ProgramGoalID" },
                keyValues: new object[] { 1, 6L });

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramGoals_Localization",
                keyColumns: new[] { "LanguageID", "ProgramGoalID" },
                keyValues: new object[] { 2, 6L });

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramGoals_Localization",
                keyColumns: new[] { "LanguageID", "ProgramGoalID" },
                keyValues: new object[] { 1, 7L });

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramGoals_Localization",
                keyColumns: new[] { "LanguageID", "ProgramGoalID" },
                keyValues: new object[] { 2, 7L });

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramGoals_Localization",
                keyColumns: new[] { "LanguageID", "ProgramGoalID" },
                keyValues: new object[] { 1, 8L });

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramGoals_Localization",
                keyColumns: new[] { "LanguageID", "ProgramGoalID" },
                keyValues: new object[] { 2, 8L });

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramComponents",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramComponents",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramComponents",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramGoals",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramGoals",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramGoals",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramGoals",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramGoals",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramGoals",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramGoals",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                schema: "Activities",
                table: "ProgramGoals",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.AddColumn<string>(
                name: "GoalText",
                schema: "Activities",
                table: "ProgramGoals_Localization",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ComponentText",
                schema: "Activities",
                table: "ProgramComponents_Localization",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");
        }
    }
}
