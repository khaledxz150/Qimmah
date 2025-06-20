using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Qimmah.Migrations
{
    /// <inheritdoc />
    public partial class programDBbuilt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Activities");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "Users",
                table: "AspNetUsers",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_ID_LanguageID",
                schema: "Users",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_Id_LanguageID");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "Users",
                table: "AspNetUserClaims",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "Users",
                table: "AspNetRoles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "Users",
                table: "AspNetRoleClaims",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: " ProgramCategory",
                schema: "Activities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ ProgramCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Organizers",
                schema: "Users",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: " ProgramCategory_Localization",
                schema: "Activities",
                columns: table => new
                {
                    LanguageID = table.Column<int>(type: "int", nullable: false),
                    ProgramCategoryID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ ProgramCategory_Localization", x => new { x.ProgramCategoryID, x.LanguageID });
                    table.ForeignKey(
                        name: "FK_ ProgramCategory_Localization_ ProgramCategory_ProgramCategoryID",
                        column: x => x.ProgramCategoryID,
                        principalSchema: "Activities",
                        principalTable: " ProgramCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ ProgramCategory_Localization_Language_LanguageID",
                        column: x => x.LanguageID,
                        principalSchema: "Localization",
                        principalTable: "Language",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organizers_Localization",
                schema: "Users",
                columns: table => new
                {
                    LanguageID = table.Column<int>(type: "int", nullable: false),
                    OrganizerId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizers_Localization", x => x.LanguageID);
                    table.ForeignKey(
                        name: "FK_Organizers_Localization_Language_LanguageID",
                        column: x => x.LanguageID,
                        principalSchema: "Localization",
                        principalTable: "Language",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Organizers_Localization_Organizers_OrganizerId",
                        column: x => x.OrganizerId,
                        principalSchema: "Users",
                        principalTable: "Organizers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                schema: "Activities",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    ParticipantCount = table.Column<int>(type: "int", nullable: false),
                    IsFree = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscountPercent = table.Column<int>(type: "int", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: true),
                    RatingCount = table.Column<int>(type: "int", nullable: true),
                    ProgramCategoryId = table.Column<int>(type: "int", nullable: false),
                    OrganizerId = table.Column<long>(type: "bigint", nullable: false),
                    CountryLookupID = table.Column<int>(type: "int", nullable: false),
                    CityLookupID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Programs_ ProgramCategory_ProgramCategoryId",
                        column: x => x.ProgramCategoryId,
                        principalSchema: "Activities",
                        principalTable: " ProgramCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Programs_Lookups_CityLookupID",
                        column: x => x.CityLookupID,
                        principalSchema: "System",
                        principalTable: "Lookups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Programs_Lookups_CountryLookupID",
                        column: x => x.CountryLookupID,
                        principalSchema: "System",
                        principalTable: "Lookups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Programs_Organizers_OrganizerId",
                        column: x => x.OrganizerId,
                        principalSchema: "Users",
                        principalTable: "Organizers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramComponents",
                schema: "Activities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramComponents_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalSchema: "Activities",
                        principalTable: "Programs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramGoals",
                schema: "Activities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramGoals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramGoals_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalSchema: "Activities",
                        principalTable: "Programs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Programs_Description_Localization",
                schema: "Activities",
                columns: table => new
                {
                    LanguageID = table.Column<int>(type: "int", nullable: false),
                    ProgramID = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs_Description_Localization", x => new { x.ProgramID, x.LanguageID });
                    table.ForeignKey(
                        name: "FK_Programs_Description_Localization_Language_LanguageID",
                        column: x => x.LanguageID,
                        principalSchema: "Localization",
                        principalTable: "Language",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Programs_Description_Localization_Programs_ProgramID",
                        column: x => x.ProgramID,
                        principalSchema: "Activities",
                        principalTable: "Programs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Programs_Title_Localization",
                schema: "Activities",
                columns: table => new
                {
                    LanguageID = table.Column<int>(type: "int", nullable: false),
                    ProgramID = table.Column<long>(type: "bigint", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs_Title_Localization", x => new { x.ProgramID, x.LanguageID });
                    table.ForeignKey(
                        name: "FK_Programs_Title_Localization_Language_LanguageID",
                        column: x => x.LanguageID,
                        principalSchema: "Localization",
                        principalTable: "Language",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Programs_Title_Localization_Programs_ProgramID",
                        column: x => x.ProgramID,
                        principalSchema: "Activities",
                        principalTable: "Programs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramComponents_Localization",
                schema: "Activities",
                columns: table => new
                {
                    LanguageID = table.Column<int>(type: "int", nullable: false),
                    ProgramComponentID = table.Column<long>(type: "bigint", nullable: false),
                    ComponentText = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramComponents_Localization", x => new { x.ProgramComponentID, x.LanguageID });
                    table.ForeignKey(
                        name: "FK_ProgramComponents_Localization_Language_LanguageID",
                        column: x => x.LanguageID,
                        principalSchema: "Localization",
                        principalTable: "Language",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramComponents_Localization_ProgramComponents_ProgramComponentID",
                        column: x => x.ProgramComponentID,
                        principalSchema: "Activities",
                        principalTable: "ProgramComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramGoals_Localization",
                schema: "Activities",
                columns: table => new
                {
                    LanguageID = table.Column<int>(type: "int", nullable: false),
                    ProgramGoalID = table.Column<long>(type: "bigint", nullable: false),
                    GoalText = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramGoals_Localization", x => new { x.ProgramGoalID, x.LanguageID });
                    table.ForeignKey(
                        name: "FK_ProgramGoals_Localization_Language_LanguageID",
                        column: x => x.LanguageID,
                        principalSchema: "Localization",
                        principalTable: "Language",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramGoals_Localization_ProgramGoals_ProgramGoalID",
                        column: x => x.ProgramGoalID,
                        principalSchema: "Activities",
                        principalTable: "ProgramGoals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Activities",
                table: " ProgramCategory",
                columns: new[] { "ID", "IsActive", "OrderID" },
                values: new object[,]
                {
                    { 1, true, 1 },
                    { 2, true, 2 }
                });

            migrationBuilder.InsertData(
                schema: "Localization",
                table: "DictionaryLocalization",
                columns: new[] { "ID", "LanguageID", "Description" },
                values: new object[,]
                {
                    { 193, 1, "Amman" },
                    { 193, 2, "عمّان" },
                    { 194, 1, "Irbid" },
                    { 194, 2, "إربد" },
                    { 195, 1, "Zarqa" },
                    { 195, 2, "الزرقاء" },
                    { 196, 1, "Aqaba" },
                    { 196, 2, "العقبة" },
                    { 197, 1, "Ramallah" },
                    { 197, 2, "رام الله" },
                    { 198, 1, "Nablus" },
                    { 198, 2, "نابلس" },
                    { 199, 1, "Hebron" },
                    { 199, 2, "الخليل" },
                    { 200, 1, "Gaza" },
                    { 200, 2, "غزة" },
                    { 201, 1, "Beirut" },
                    { 201, 2, "بيروت" },
                    { 202, 1, "Tripoli" },
                    { 202, 2, "طرابلس" },
                    { 203, 1, "Sidon" },
                    { 203, 2, "صيدا" },
                    { 204, 1, "Damascus" },
                    { 204, 2, "دمشق" },
                    { 205, 1, "Aleppo" },
                    { 205, 2, "حلب" },
                    { 206, 1, "Homs" },
                    { 206, 2, "حمص" },
                    { 207, 1, "Baghdad" },
                    { 207, 2, "بغداد" },
                    { 208, 1, "Basra" },
                    { 208, 2, "البصرة" },
                    { 209, 1, "Erbil" },
                    { 209, 2, "أربيل" },
                    { 210, 1, "Riyadh" },
                    { 210, 2, "الرياض" },
                    { 211, 1, "Jeddah" },
                    { 211, 2, "جدة" },
                    { 212, 1, "Dammam" },
                    { 212, 2, "الدمام" },
                    { 213, 1, "Mecca" },
                    { 213, 2, "مكة" },
                    { 214, 1, "Medina" },
                    { 214, 2, "المدينة المنورة" },
                    { 215, 1, "Kuwait City" },
                    { 215, 2, "مدينة الكويت" },
                    { 216, 1, "Manama" },
                    { 216, 2, "المنامة" },
                    { 217, 1, "Doha" },
                    { 217, 2, "الدوحة" },
                    { 218, 1, "Abu Dhabi" },
                    { 218, 2, "أبو ظبي" },
                    { 219, 1, "Dubai" },
                    { 219, 2, "دبي" },
                    { 220, 1, "Sharjah" },
                    { 220, 2, "الشارقة" },
                    { 221, 1, "Muscat" },
                    { 221, 2, "مسقط" },
                    { 222, 1, "Salalah" },
                    { 222, 2, "صلالة" },
                    { 223, 1, "Sana'a" },
                    { 223, 2, "صنعاء" },
                    { 224, 1, "Aden" },
                    { 224, 2, "عدن" },
                    { 225, 1, "Cairo" },
                    { 225, 2, "القاهرة" },
                    { 226, 1, "Alexandria" },
                    { 226, 2, "الإسكندرية" },
                    { 227, 1, "Giza" },
                    { 227, 2, "الجيزة" },
                    { 228, 1, "Istanbul" },
                    { 228, 2, "إسطنبول" },
                    { 229, 1, "Ankara" },
                    { 229, 2, "أنقرة" },
                    { 230, 1, "Izmir" },
                    { 230, 2, "إزمير" },
                    { 231, 1, "Tehran" },
                    { 231, 2, "طهران" },
                    { 232, 1, "Mashhad" },
                    { 232, 2, "مشهد" },
                    { 233, 1, "Isfahan" },
                    { 233, 2, "أصفهان" }
                });

            migrationBuilder.InsertData(
                schema: "System",
                table: "LookupCategories",
                columns: new[] { "ID", "Description", "IsActive", "IsDeleted", "OrderID", "ParentID" },
                values: new object[] { 200, "Program Categories", true, false, 1, null });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Lookups",
                columns: new[] { "ID", "BoolValue", "CategoryID", "Description", "DictionaryID", "GuidValue", "IntValue", "IsActive", "IsDeleted", "LongValue", "OrderID", "ParentID", "StringValue" },
                values: new object[,]
                {
                    { 16, null, 2, "Amman", 193, null, null, true, false, null, 0, 1, null },
                    { 17, null, 2, "Irbid", 194, null, null, true, false, null, 0, 1, null },
                    { 18, null, 2, "Zarqa", 195, null, null, true, false, null, 0, 1, null },
                    { 19, null, 2, "Aqaba", 196, null, null, true, false, null, 0, 1, null },
                    { 20, null, 2, "Ramallah", 197, null, null, true, false, null, 0, 2, null },
                    { 21, null, 2, "Nablus", 198, null, null, true, false, null, 0, 2, null },
                    { 22, null, 2, "Hebron", 199, null, null, true, false, null, 0, 2, null },
                    { 23, null, 2, "Gaza", 200, null, null, true, false, null, 0, 2, null },
                    { 24, null, 2, "Beirut", 201, null, null, true, false, null, 0, 3, null },
                    { 25, null, 2, "Tripoli", 202, null, null, true, false, null, 0, 3, null },
                    { 26, null, 2, "Sidon", 203, null, null, true, false, null, 0, 3, null },
                    { 27, null, 2, "Damascus", 204, null, null, true, false, null, 0, 4, null },
                    { 28, null, 2, "Aleppo", 205, null, null, true, false, null, 0, 4, null },
                    { 29, null, 2, "Homs", 206, null, null, true, false, null, 0, 4, null },
                    { 30, null, 2, "Baghdad", 207, null, null, true, false, null, 0, 5, null },
                    { 31, null, 2, "Basra", 208, null, null, true, false, null, 0, 5, null },
                    { 32, null, 2, "Erbil", 209, null, null, true, false, null, 0, 5, null },
                    { 33, null, 2, "Riyadh", 210, null, null, true, false, null, 0, 6, null },
                    { 34, null, 2, "Jeddah", 211, null, null, true, false, null, 0, 6, null },
                    { 35, null, 2, "Dammam", 212, null, null, true, false, null, 0, 6, null },
                    { 36, null, 2, "Mecca", 213, null, null, true, false, null, 0, 6, null },
                    { 37, null, 2, "Medina", 214, null, null, true, false, null, 0, 6, null },
                    { 38, null, 2, "Kuwait City", 215, null, null, true, false, null, 0, 7, null },
                    { 39, null, 2, "Manama", 216, null, null, true, false, null, 0, 8, null },
                    { 40, null, 2, "Doha", 217, null, null, true, false, null, 0, 9, null },
                    { 41, null, 2, "Abu Dhabi", 218, null, null, true, false, null, 0, 10, null },
                    { 42, null, 2, "Dubai", 219, null, null, true, false, null, 0, 10, null },
                    { 43, null, 2, "Sharjah", 220, null, null, true, false, null, 0, 10, null },
                    { 44, null, 2, "Muscat", 221, null, null, true, false, null, 0, 11, null },
                    { 45, null, 2, "Salalah", 222, null, null, true, false, null, 0, 11, null },
                    { 46, null, 2, "Sana'a", 223, null, null, true, false, null, 0, 12, null },
                    { 47, null, 2, "Aden", 224, null, null, true, false, null, 0, 12, null },
                    { 48, null, 2, "Cairo", 225, null, null, true, false, null, 0, 13, null },
                    { 49, null, 2, "Alexandria", 226, null, null, true, false, null, 0, 13, null },
                    { 50, null, 2, "Giza", 227, null, null, true, false, null, 0, 13, null },
                    { 51, null, 2, "Istanbul", 228, null, null, true, false, null, 0, 14, null },
                    { 52, null, 2, "Ankara", 229, null, null, true, false, null, 0, 14, null },
                    { 53, null, 2, "Izmir", 230, null, null, true, false, null, 0, 14, null },
                    { 54, null, 2, "Tehran", 231, null, null, true, false, null, 0, 15, null },
                    { 55, null, 2, "Mashhad", 232, null, null, true, false, null, 0, 15, null },
                    { 56, null, 2, "Isfahan", 233, null, null, true, false, null, 0, 15, null }
                });

            migrationBuilder.InsertData(
                schema: "Users",
                table: "Organizers",
                columns: new[] { "ID", "Email", "ImageUrl", "IsActive", "IsDeleted", "Phone", "Website" },
                values: new object[] { 1L, "info@qimmah.org", "/images/organizers/organizer1.jpg", true, false, "+962-6-1234567", "https://qimmah.org" });

            migrationBuilder.InsertData(
                schema: "Activities",
                table: " ProgramCategory_Localization",
                columns: new[] { "LanguageID", "ProgramCategoryID", "Description" },
                values: new object[,]
                {
                    { 2, 1, "تطوير الذات" },
                    { 2, 2, "الابتكار" }
                });

            migrationBuilder.InsertData(
                schema: "Users",
                table: "Organizers_Localization",
                columns: new[] { "LanguageID", "Description", "OrganizerId" },
                values: new object[,]
                {
                    { 1, "مؤسسة قمة", 1L },
                    { 2, "Qimmah Foundation", 1L }
                });

            migrationBuilder.InsertData(
                schema: "Activities",
                table: "Programs",
                columns: new[] { "ID", "CityLookupID", "CountryLookupID", "DiscountPercent", "DurationMinutes", "ImageUrl", "IsActive", "IsDeleted", "IsFree", "OrganizerId", "ParticipantCount", "Price", "ProgramCategoryId", "Rating", "RatingCount", "StartDate" },
                values: new object[] { 1L, 16, 1, 100, 192, "/images/programs/program1.jpg", true, false, true, 1L, 30, null, 1, 4.7000000000000002, 128, new DateTime(2023, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                schema: "Activities",
                table: "Programs_Description_Localization",
                columns: new[] { "LanguageID", "ProgramID", "Description" },
                values: new object[] { 2, 1L, "برمج. ابتكر. انطلق.\" ليست مجرد فعالية تقنية، بل منصة متكاملة تُطلق العنان لإبداع الشباب، وتمنحهم فرصة حقيقية للانتقال من مجرد أفكار إلى مشاريع واقعية ذات أثر.\r\n\r\n يعيش المشاركون تجربة فريدة تجمع بين التعلم العملي، والتفكير التصميمي، والعمل الجماعي، ضمن بيئة تفاعلية تحفّز الابتكار وتحتضن الموهبة. سواء كنت مبتدئًا في البرمجة أو مطورًا يسعى للارتقاء بمهاراته، ستجد في هذه الفعالية محتوى يناسبك، وورشًا تُشعل شغفك، وفرصًا لصقل مشروعك." });

            migrationBuilder.InsertData(
                schema: "Activities",
                table: "Programs_Title_Localization",
                columns: new[] { "LanguageID", "ProgramID", "Description", "ShortDescription" },
                values: new object[] { 2, 1L, "برمج. ابتكر. انطلق", "فعالية تفاعلية تجمع بين التدريب العملي، الإرشاد المهني، وفرص بناء تطبيقات ومشاريع تقنية حقيقية بمساعدة خبراء في المجال." });

            migrationBuilder.CreateIndex(
                name: "IX_ ProgramCategory_Localization_LanguageID",
                schema: "Activities",
                table: " ProgramCategory_Localization",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_Organizers_Localization_OrganizerId",
                schema: "Users",
                table: "Organizers_Localization",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramComponents_ProgramId",
                schema: "Activities",
                table: "ProgramComponents",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramComponents_Localization_LanguageID",
                schema: "Activities",
                table: "ProgramComponents_Localization",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramGoals_ProgramId",
                schema: "Activities",
                table: "ProgramGoals",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramGoals_Localization_LanguageID",
                schema: "Activities",
                table: "ProgramGoals_Localization",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_CityLookupID",
                schema: "Activities",
                table: "Programs",
                column: "CityLookupID");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_CountryLookupID",
                schema: "Activities",
                table: "Programs",
                column: "CountryLookupID");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_OrganizerId",
                schema: "Activities",
                table: "Programs",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_ProgramCategoryId",
                schema: "Activities",
                table: "Programs",
                column: "ProgramCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_Description_Localization_LanguageID",
                schema: "Activities",
                table: "Programs_Description_Localization",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_Title_Localization_LanguageID",
                schema: "Activities",
                table: "Programs_Title_Localization",
                column: "LanguageID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: " ProgramCategory_Localization",
                schema: "Activities");

            migrationBuilder.DropTable(
                name: "Organizers_Localization",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "ProgramComponents_Localization",
                schema: "Activities");

            migrationBuilder.DropTable(
                name: "ProgramGoals_Localization",
                schema: "Activities");

            migrationBuilder.DropTable(
                name: "Programs_Description_Localization",
                schema: "Activities");

            migrationBuilder.DropTable(
                name: "Programs_Title_Localization",
                schema: "Activities");

            migrationBuilder.DropTable(
                name: "ProgramComponents",
                schema: "Activities");

            migrationBuilder.DropTable(
                name: "ProgramGoals",
                schema: "Activities");

            migrationBuilder.DropTable(
                name: "Programs",
                schema: "Activities");

            migrationBuilder.DropTable(
                name: " ProgramCategory",
                schema: "Activities");

            migrationBuilder.DropTable(
                name: "Organizers",
                schema: "Users");

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 193, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 193, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 194, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 194, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 195, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 195, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 196, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 196, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 197, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 197, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 198, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 198, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 199, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 199, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 200, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 200, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 201, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 201, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 202, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 202, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 203, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 203, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 204, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 204, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 205, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 205, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 206, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 206, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 207, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 207, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 208, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 208, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 209, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 209, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 210, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 210, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 211, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 211, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 212, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 212, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 213, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 213, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 214, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 214, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 215, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 215, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 216, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 216, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 217, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 217, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 218, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 218, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 219, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 219, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 220, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 220, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 221, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 221, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 222, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 222, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 223, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 223, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 224, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 224, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 225, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 225, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 226, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 226, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 227, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 227, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 228, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 228, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 229, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 229, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 230, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 230, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 231, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 231, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 232, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 232, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 233, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 233, 2 });

            migrationBuilder.DeleteData(
                schema: "System",
                table: "LookupCategories",
                keyColumn: "ID",
                keyValue: 200);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                schema: "System",
                table: "Lookups",
                keyColumn: "ID",
                keyValue: 56);

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Users",
                table: "AspNetUsers",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_Id_LanguageID",
                schema: "Users",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_ID_LanguageID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Users",
                table: "AspNetUserClaims",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Users",
                table: "AspNetRoles",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Users",
                table: "AspNetRoleClaims",
                newName: "ID");
        }
    }
}
