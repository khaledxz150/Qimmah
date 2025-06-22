using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qimmah.Migrations
{
    /// <inheritdoc />
    public partial class addedPRogramRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgramRatings",
                schema: "Activities",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    RatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsVerifiedPurchase = table.Column<bool>(type: "bit", nullable: false),
                    HelpfulCount = table.Column<int>(type: "int", nullable: false),
                    IsReported = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramRatings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProgramRatings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Users",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramRatings_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalSchema: "Activities",
                        principalTable: "Programs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramRatings_ProgramId",
                schema: "Activities",
                table: "ProgramRatings",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramRatings_UserId_ProgramId",
                schema: "Activities",
                table: "ProgramRatings",
                columns: new[] { "UserId", "ProgramId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramRatings",
                schema: "Activities");
        }
    }
}
