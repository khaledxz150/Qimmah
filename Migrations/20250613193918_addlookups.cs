using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Qimmah.Migrations
{
    /// <inheritdoc />
    public partial class addlookups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "System");

            migrationBuilder.CreateTable(
                name: "LookupCategories",
                schema: "System",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Lookups",
                schema: "System",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DictionaryID = table.Column<int>(type: "int", nullable: true),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    IntValue = table.Column<int>(type: "int", nullable: true),
                    LongValue = table.Column<long>(type: "bigint", nullable: true),
                    StringValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BoolValue = table.Column<bool>(type: "bit", nullable: true),
                    GuidValue = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookups", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lookups_Dictionary_DictionaryID",
                        column: x => x.DictionaryID,
                        principalSchema: "Localization",
                        principalTable: "Dictionary",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Lookups_LookupCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalSchema: "System",
                        principalTable: "LookupCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lookups_Lookups_ParentID",
                        column: x => x.ParentID,
                        principalSchema: "System",
                        principalTable: "Lookups",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                schema: "Localization",
                table: "Dictionary",
                column: "ID",
                values: new object[]
                {
                    1001,
                    1002,
                    1003,
                    1004,
                    1005,
                    1006,
                    1007,
                    1008,
                    1009,
                    1010,
                    1011,
                    1012,
                    1013,
                    1014,
                    1015,
                    1016,
                    1017,
                    1018,
                    1019,
                    1020,
                    1021,
                    1022,
                    1023,
                    1024,
                    1025,
                    1026,
                    1027,
                    1028,
                    1029,
                    1030,
                    1031,
                    1032,
                    1033,
                    1034,
                    1035,
                    1036,
                    1037,
                    1038,
                    1039,
                    1040,
                    1041,
                    1042,
                    1043,
                    1044,
                    1045,
                    1046,
                    1047,
                    1048,
                    1049,
                    1050,
                    1051,
                    1052,
                    1053,
                    1054,
                    1055,
                    1056,
                    1057,
                    1058,
                    1059,
                    1060,
                    1061,
                    1062,
                    1063,
                    1064,
                    1065,
                    1066,
                    1067,
                    1068,
                    1069,
                    1070,
                    1071,
                    1072,
                    1073,
                    1074,
                    1075,
                    1076,
                    1077,
                    1078,
                    1079,
                    1080,
                    1081,
                    1082,
                    1083,
                    1084,
                    1085,
                    1086,
                    1087,
                    1088,
                    1089,
                    1090,
                    1091,
                    1092,
                    1093,
                    1094,
                    1095,
                    1096,
                    1097,
                    1098,
                    1099,
                    1100,
                    1101,
                    1102,
                    1103,
                    1104,
                    1105,
                    1106,
                    1107,
                    1108,
                    1109,
                    1110,
                    1111,
                    1112,
                    1113,
                    1114,
                    1115,
                    1116,
                    1117,
                    1118,
                    1119,
                    1120,
                    1121,
                    1122,
                    1123,
                    1124,
                    1125,
                    1126,
                    1127,
                    1128,
                    1129,
                    1130,
                    1131,
                    1132,
                    1133,
                    1134,
                    1135,
                    1136,
                    1137,
                    1138,
                    1139,
                    1140,
                    1141,
                    1142,
                    1143,
                    1144,
                    1145,
                    1146,
                    1147,
                    1148,
                    1149,
                    1150,
                    1151,
                    1152,
                    1153,
                    1154,
                    1155,
                    1156,
                    1157,
                    1158,
                    1159,
                    1160,
                    1161,
                    1162,
                    1163,
                    1164,
                    1165,
                    1166,
                    1167,
                    1168,
                    1169,
                    1170,
                    1171,
                    1172,
                    1173,
                    1174,
                    1175,
                    1176,
                    1177,
                    1178,
                    1179,
                    1180,
                    1181,
                    1182,
                    1183,
                    1184,
                    1185,
                    1186,
                    1187,
                    1188,
                    1189,
                    1190,
                    1191,
                    1192,
                    1193,
                    1194,
                    1195,
                    1196,
                    1197,
                    1198,
                    1199,
                    1200,
                    1201,
                    1202,
                    1203,
                    1204,
                    1205,
                    1206,
                    1207,
                    1208,
                    1209,
                    1210,
                    1211,
                    1212,
                    1213,
                    1214,
                    1215,
                    1216,
                    1217,
                    1218,
                    1219,
                    1220,
                    1221,
                    1222,
                    1223,
                    1224,
                    1225,
                    1226,
                    1227,
                    1228,
                    1229,
                    1230,
                    1231,
                    1232,
                    1233,
                    1234,
                    1235,
                    1236,
                    1237,
                    1238,
                    1239,
                    1240,
                    1241,
                    1242,
                    1243,
                    1244,
                    1245,
                    1246,
                    1247,
                    1248,
                    1249,
                    1250,
                    1251,
                    1252,
                    1253,
                    1254,
                    1255,
                    1256,
                    1257,
                    1258,
                    1259,
                    1260,
                    1261,
                    1262,
                    1263,
                    1264,
                    1265,
                    1266,
                    1267,
                    1268,
                    1269,
                    1270,
                    1271,
                    1272,
                    1273,
                    1274,
                    1275,
                    1276,
                    1277,
                    1278,
                    1279,
                    1280,
                    1281,
                    1282,
                    1283,
                    1284,
                    1285,
                    1286,
                    1287,
                    1288,
                    1289,
                    1290,
                    1291,
                    1292,
                    1293,
                    1294,
                    1295,
                    1296,
                    1297,
                    1298,
                    1299,
                    1300,
                    1301,
                    1302,
                    1303,
                    1304,
                    1305,
                    1306,
                    1307,
                    1308,
                    1309,
                    1310,
                    1311,
                    1312,
                    1313,
                    1314,
                    1315,
                    1316,
                    1317,
                    1318,
                    1319,
                    1320,
                    1321,
                    1322,
                    1323,
                    1324,
                    1325,
                    1326,
                    1327,
                    1328,
                    1329,
                    1330,
                    1331,
                    1332,
                    1333,
                    1334,
                    1335,
                    1336,
                    1337,
                    1338,
                    1339,
                    1340,
                    1341,
                    1342,
                    1343,
                    1344,
                    1345,
                    1346,
                    1347,
                    1348,
                    1349,
                    1350,
                    1351,
                    1352,
                    1353,
                    1354,
                    1355,
                    1356,
                    1357,
                    1358,
                    1359,
                    1360,
                    1361,
                    1362,
                    1363,
                    1364,
                    1365,
                    1366,
                    1367,
                    1368,
                    1369,
                    1370,
                    1371,
                    1372,
                    1373,
                    1374,
                    1375,
                    1376,
                    1377,
                    1378,
                    1379,
                    1380,
                    1381,
                    1382,
                    1383,
                    1384,
                    1385,
                    1386,
                    1387,
                    1388,
                    1389,
                    1390,
                    1391,
                    1392,
                    1393,
                    1394,
                    1395,
                    1396,
                    1397,
                    1398,
                    1399,
                    1400,
                    1401,
                    1402,
                    1403,
                    1404,
                    1405,
                    1406,
                    1407,
                    1408,
                    1409,
                    1410,
                    1411,
                    1412,
                    1413,
                    1414,
                    1415,
                    1416,
                    1417,
                    1418,
                    1419,
                    1420,
                    1421,
                    1422,
                    1423,
                    1424,
                    1425,
                    1426,
                    1427,
                    1428,
                    1429,
                    1430,
                    1431,
                    1432,
                    1433,
                    1434,
                    1435,
                    1436,
                    1437,
                    1438,
                    1439,
                    1440,
                    1441,
                    1442,
                    1443,
                    1444,
                    1445,
                    1446,
                    1447,
                    1448,
                    1449,
                    1450,
                    1451,
                    1452,
                    1453,
                    1454,
                    1455,
                    1456,
                    1457,
                    1458,
                    1459,
                    1460,
                    1461,
                    1462,
                    1463,
                    1464,
                    1465,
                    1466,
                    1467,
                    1468,
                    1469,
                    1470,
                    1471,
                    1472,
                    1473,
                    1474,
                    1475,
                    1476,
                    1477,
                    1478,
                    1479,
                    1480,
                    1481,
                    1482,
                    1483,
                    1484,
                    1485,
                    1486,
                    1487,
                    1488,
                    1489,
                    1490,
                    1491,
                    1492,
                    1493,
                    1494,
                    1495,
                    1496,
                    1497,
                    1498,
                    1499,
                    1500
                });

            migrationBuilder.InsertData(
                schema: "System",
                table: "LookupCategories",
                columns: new[] { "ID", "Description", "IsActive", "IsDeleted", "OrderID", "ParentID" },
                values: new object[,]
                {
                    { 1, "List of countries", true, false, 0, null },
                    { 2, "List of cities", true, false, 0, null }
                });

            migrationBuilder.InsertData(
                schema: "Localization",
                table: "DictionaryLocalization",
                columns: new[] { "ID", "LanguageID", "Description" },
                values: new object[,]
                {
                    { 1001, 1, "Jordan" },
                    { 1001, 2, "الأردن" },
                    { 1002, 1, "Palestine" },
                    { 1002, 2, "فلسطين" },
                    { 1003, 1, "Lebanon" },
                    { 1003, 2, "لبنان" },
                    { 1004, 1, "Syria" },
                    { 1004, 2, "سوريا" },
                    { 1005, 1, "Iraq" },
                    { 1005, 2, "العراق" },
                    { 1006, 1, "Saudi Arabia" },
                    { 1006, 2, "السعودية" },
                    { 1007, 1, "Kuwait" },
                    { 1007, 2, "الكويت" },
                    { 1008, 1, "Bahrain" },
                    { 1008, 2, "البحرين" },
                    { 1009, 1, "Qatar" },
                    { 1009, 2, "قطر" },
                    { 1010, 1, "United Arab Emirates" },
                    { 1010, 2, "الإمارات العربية المتحدة" },
                    { 1011, 1, "Oman" },
                    { 1011, 2, "عُمان" },
                    { 1012, 1, "Yemen" },
                    { 1012, 2, "اليمن" },
                    { 1013, 1, "Egypt" },
                    { 1013, 2, "مصر" },
                    { 1014, 1, "Turkey" },
                    { 1014, 2, "تركيا" },
                    { 1015, 1, "Iran" },
                    { 1015, 2, "إيران" }
                });

            migrationBuilder.InsertData(
                schema: "System",
                table: "Lookups",
                columns: new[] { "ID", "BoolValue", "CategoryID", "Description", "DictionaryID", "GuidValue", "IntValue", "IsActive", "IsDeleted", "LongValue", "OrderID", "ParentID", "StringValue" },
                values: new object[,]
                {
                    { 1, null, 1, "Jordan", 1001, null, null, true, false, null, 0, null, null },
                    { 2, null, 1, "Palestine", 1002, null, null, true, false, null, 0, null, null },
                    { 3, null, 1, "Lebanon", 1003, null, null, true, false, null, 0, null, null },
                    { 4, null, 1, "Syria", 1004, null, null, true, false, null, 0, null, null },
                    { 5, null, 1, "Iraq", 1005, null, null, true, false, null, 0, null, null },
                    { 6, null, 1, "Saudi Arabia", 1006, null, null, true, false, null, 0, null, null },
                    { 7, null, 1, "Kuwait", 1007, null, null, true, false, null, 0, null, null },
                    { 8, null, 1, "Bahrain", 1008, null, null, true, false, null, 0, null, null },
                    { 9, null, 1, "Qatar", 1009, null, null, true, false, null, 0, null, null },
                    { 10, null, 1, "United Arab Emirates", 1010, null, null, true, false, null, 0, null, null },
                    { 11, null, 1, "Oman", 1011, null, null, true, false, null, 0, null, null },
                    { 12, null, 1, "Yemen", 1012, null, null, true, false, null, 0, null, null },
                    { 13, null, 1, "Egypt", 1013, null, null, true, false, null, 0, null, null },
                    { 14, null, 1, "Turkey", 1014, null, null, true, false, null, 0, null, null },
                    { 15, null, 1, "Iran", 1015, null, null, true, false, null, 0, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lookups_CategoryID",
                schema: "System",
                table: "Lookups",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Lookups_DictionaryID",
                schema: "System",
                table: "Lookups",
                column: "DictionaryID");

            migrationBuilder.CreateIndex(
                name: "IX_Lookups_ParentID",
                schema: "System",
                table: "Lookups",
                column: "ParentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lookups",
                schema: "System");

            migrationBuilder.DropTable(
                name: "LookupCategories",
                schema: "System");

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1016);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1017);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1018);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1019);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1020);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1021);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1022);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1023);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1024);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1025);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1026);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1027);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1028);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1029);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1030);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1031);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1032);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1033);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1034);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1035);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1036);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1037);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1038);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1039);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1040);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1041);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1042);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1043);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1044);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1045);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1046);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1047);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1048);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1049);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1050);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1051);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1052);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1053);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1054);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1055);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1056);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1057);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1058);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1059);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1060);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1061);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1062);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1063);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1064);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1065);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1066);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1067);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1068);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1069);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1070);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1071);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1072);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1073);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1074);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1075);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1076);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1077);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1078);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1079);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1080);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1081);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1082);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1083);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1084);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1085);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1086);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1087);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1088);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1089);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1090);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1091);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1092);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1093);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1094);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1095);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1096);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1097);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1098);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1099);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1100);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1101);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1102);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1103);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1104);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1105);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1106);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1107);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1108);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1109);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1110);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1111);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1112);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1113);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1114);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1115);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1116);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1117);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1118);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1119);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1120);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1121);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1122);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1123);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1124);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1125);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1126);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1127);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1128);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1129);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1130);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1131);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1132);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1133);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1134);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1135);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1136);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1137);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1138);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1139);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1140);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1141);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1142);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1143);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1144);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1145);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1146);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1147);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1148);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1149);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1150);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1151);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1152);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1153);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1154);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1155);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1156);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1157);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1158);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1159);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1160);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1161);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1162);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1163);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1164);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1165);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1166);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1167);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1168);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1169);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1170);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1171);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1172);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1173);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1174);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1175);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1176);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1177);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1178);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1179);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1180);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1181);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1182);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1183);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1184);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1185);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1186);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1187);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1188);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1189);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1190);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1191);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1192);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1193);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1194);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1195);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1196);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1197);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1198);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1199);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1200);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1201);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1202);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1203);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1204);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1205);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1206);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1207);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1208);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1209);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1210);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1211);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1212);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1213);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1214);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1215);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1216);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1217);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1218);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1219);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1220);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1221);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1222);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1223);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1224);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1225);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1226);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1227);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1228);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1229);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1230);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1231);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1232);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1233);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1234);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1235);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1236);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1237);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1238);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1239);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1240);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1241);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1242);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1243);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1244);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1245);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1246);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1247);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1248);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1249);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1250);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1251);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1252);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1253);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1254);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1255);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1256);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1257);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1258);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1259);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1260);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1261);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1262);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1263);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1264);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1265);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1266);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1267);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1268);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1269);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1270);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1271);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1272);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1273);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1274);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1275);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1276);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1277);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1278);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1279);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1280);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1281);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1282);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1283);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1284);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1285);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1286);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1287);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1288);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1289);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1290);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1291);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1292);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1293);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1294);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1295);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1296);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1297);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1298);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1299);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1300);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1301);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1302);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1303);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1304);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1305);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1306);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1307);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1308);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1309);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1310);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1311);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1312);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1313);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1314);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1315);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1316);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1317);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1318);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1319);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1320);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1321);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1322);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1323);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1324);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1325);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1326);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1327);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1328);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1329);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1330);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1331);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1332);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1333);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1334);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1335);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1336);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1337);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1338);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1339);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1340);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1341);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1342);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1343);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1344);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1345);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1346);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1347);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1348);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1349);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1350);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1351);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1352);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1353);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1354);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1355);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1356);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1357);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1358);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1359);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1360);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1361);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1362);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1363);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1364);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1365);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1366);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1367);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1368);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1369);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1370);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1371);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1372);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1373);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1374);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1375);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1376);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1377);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1378);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1379);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1380);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1381);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1382);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1383);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1384);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1385);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1386);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1387);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1388);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1389);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1390);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1391);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1392);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1393);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1394);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1395);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1396);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1397);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1398);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1399);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1400);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1401);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1402);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1403);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1404);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1405);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1406);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1407);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1408);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1409);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1410);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1411);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1412);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1413);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1414);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1415);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1416);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1417);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1418);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1419);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1420);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1421);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1422);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1423);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1424);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1425);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1426);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1427);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1428);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1429);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1430);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1431);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1432);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1433);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1434);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1435);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1436);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1437);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1438);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1439);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1440);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1441);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1442);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1443);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1444);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1445);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1446);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1447);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1448);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1449);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1450);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1451);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1452);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1453);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1454);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1455);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1456);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1457);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1458);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1459);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1460);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1461);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1462);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1463);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1464);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1465);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1466);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1467);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1468);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1469);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1470);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1471);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1472);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1473);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1474);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1475);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1476);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1477);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1478);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1479);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1480);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1481);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1482);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1483);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1484);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1485);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1486);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1487);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1488);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1489);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1490);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1491);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1492);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1493);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1494);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1495);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1496);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1497);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1498);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1499);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1500);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1001, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1001, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1002, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1002, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1003, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1003, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1004, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1004, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1005, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1005, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1006, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1006, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1007, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1007, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1008, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1008, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1009, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1009, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1010, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1010, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1011, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1011, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1012, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1012, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1013, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1013, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1014, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1014, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1015, 1 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "DictionaryLocalization",
                keyColumns: new[] { "ID", "LanguageID" },
                keyValues: new object[] { 1015, 2 });

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1012);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1013);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1014);

            migrationBuilder.DeleteData(
                schema: "Localization",
                table: "Dictionary",
                keyColumn: "ID",
                keyValue: 1015);
        }
    }
}
