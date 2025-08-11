using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointmentWithConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectOffer_AspNetUsers_UserId",
                table: "SelectOffer");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectOffer_Offers_OfferId",
                table: "SelectOffer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SelectOffer",
                table: "SelectOffer");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "SelectOffer");

            migrationBuilder.RenameTable(
                name: "SelectOffer",
                newName: "UserOffers");

            migrationBuilder.RenameIndex(
                name: "IX_SelectOffer_OfferId",
                table: "UserOffers",
                newName: "IX_UserOffers_OfferId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SelectedOn",
                table: "UserOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 11, 22, 16, 42, 961, DateTimeKind.Local).AddTicks(4717),
                comment: "Date and time when the offer was selected",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 10, 19, 31, 26, 711, DateTimeKind.Local).AddTicks(247),
                oldComment: "Date and time when the offer was selected");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOffers",
                table: "UserOffers",
                columns: new[] { "UserId", "OfferId" });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BarbershopId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BarbershopId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_Barbershops_BarbershopId1",
                        column: x => x.BarbershopId1,
                        principalTable: "Barbershops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_BarbershopId1",
                table: "Appointment",
                column: "BarbershopId1");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_UserId",
                table: "Appointment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOffers_AspNetUsers_UserId",
                table: "UserOffers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOffers_Offers_OfferId",
                table: "UserOffers",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOffers_AspNetUsers_UserId",
                table: "UserOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOffers_Offers_OfferId",
                table: "UserOffers");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOffers",
                table: "UserOffers");

            migrationBuilder.RenameTable(
                name: "UserOffers",
                newName: "SelectOffer");

            migrationBuilder.RenameIndex(
                name: "IX_UserOffers_OfferId",
                table: "SelectOffer",
                newName: "IX_SelectOffer_OfferId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SelectedOn",
                table: "SelectOffer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 10, 19, 31, 26, 711, DateTimeKind.Local).AddTicks(247),
                comment: "Date and time when the offer was selected",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 11, 22, 16, 42, 961, DateTimeKind.Local).AddTicks(4717),
                oldComment: "Date and time when the offer was selected");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "SelectOffer",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                comment: "SelectOffer TotalPrice");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SelectOffer",
                table: "SelectOffer",
                columns: new[] { "UserId", "OfferId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SelectOffer_AspNetUsers_UserId",
                table: "SelectOffer",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SelectOffer_Offers_OfferId",
                table: "SelectOffer",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
