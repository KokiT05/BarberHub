using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserOfferModelWithConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SelectOffer",
                columns: table => new
                {
                    OfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key reference to the offer"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Foreign key reference to the user"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "SelectOffer Description"),
                    TotalPrice = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false, comment: "SelectOffer TotalPrice"),
                    SelectedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2025, 8, 10, 19, 31, 26, 711, DateTimeKind.Local).AddTicks(247), comment: "Date and time when the offer was selected"),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, comment: "Optional comment provided by the user")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectOffer", x => new { x.UserId, x.OfferId });
                    table.ForeignKey(
                        name: "FK_SelectOffer_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectOffer_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Represents a selected offer by a user");

            migrationBuilder.CreateIndex(
                name: "IX_SelectOffer_OfferId",
                table: "SelectOffer",
                column: "OfferId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SelectOffer");
        }
    }
}
