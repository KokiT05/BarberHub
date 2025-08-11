using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationBetweenAppointmentAndBarbershop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SelectedOn",
                table: "UserOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 11, 22, 43, 31, 274, DateTimeKind.Local).AddTicks(1896),
                comment: "Date and time when the offer was selected",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 11, 22, 34, 8, 992, DateTimeKind.Local).AddTicks(8997),
                oldComment: "Date and time when the offer was selected");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SelectedOn",
                table: "UserOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 11, 22, 34, 8, 992, DateTimeKind.Local).AddTicks(8997),
                comment: "Date and time when the offer was selected",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 11, 22, 43, 31, 274, DateTimeKind.Local).AddTicks(1896),
                oldComment: "Date and time when the offer was selected");
        }
    }
}
