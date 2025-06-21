using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qimmah.Migrations
{
    /// <inheritdoc />
    public partial class connectUsersAndPrograms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Culture",
                schema: "Localization",
                table: "Language",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ProgramsUsers",
                schema: "Users",
                columns: table => new
                {
                    UsersId = table.Column<long>(type: "bigint", nullable: false),
                    programsID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramsUsers", x => new { x.UsersId, x.programsID });
                    table.ForeignKey(
                        name: "FK_ProgramsUsers_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "Users",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramsUsers_Programs_programsID",
                        column: x => x.programsID,
                        principalSchema: "Activities",
                        principalTable: "Programs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                schema: "Activities",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramId = table.Column<long>(type: "bigint", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LiveBroadcastLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCurrentlyBroadcasting = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sessions_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalSchema: "Activities",
                        principalTable: "Programs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "Language",
                keyColumn: "ID",
                keyValue: 1,
                column: "Culture",
                value: "en-US");

            migrationBuilder.UpdateData(
                schema: "Localization",
                table: "Language",
                keyColumn: "ID",
                keyValue: 2,
                column: "Culture",
                value: "ar-SA");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramsUsers_programsID",
                schema: "Users",
                table: "ProgramsUsers",
                column: "programsID");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ProgramId",
                schema: "Activities",
                table: "Sessions",
                column: "ProgramId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramsUsers",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "Sessions",
                schema: "Activities");

            migrationBuilder.DropColumn(
                name: "Culture",
                schema: "Localization",
                table: "Language");
        }
    }
}
