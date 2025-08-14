using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixUserOfferTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Barbershops_BarbershopId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "UserOffers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "UserOffers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SelectedOn",
                table: "UserOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 14, 23, 16, 41, 925, DateTimeKind.Local).AddTicks(750),
                comment: "Date and time when the offer was selected",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 11, 22, 43, 31, 274, DateTimeKind.Local).AddTicks(1896),
                oldComment: "Date and time when the offer was selected");

            migrationBuilder.AlterColumn<Guid>(
                name: "BarbershopId",
                table: "Offers",
                type: "uniqueidentifier",
                nullable: false,
                comment: "FK describe relation between Barbershop and Offer",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Barbershops_BarbershopId",
                table: "Offers",
                column: "BarbershopId",
                principalTable: "Barbershops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Barbershops_BarbershopId",
                table: "Offers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SelectedOn",
                table: "UserOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 11, 22, 43, 31, 274, DateTimeKind.Local).AddTicks(1896),
                comment: "Date and time when the offer was selected",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 14, 23, 16, 41, 925, DateTimeKind.Local).AddTicks(750),
                oldComment: "Date and time when the offer was selected");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "UserOffers",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                comment: "Optional comment provided by the user");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "UserOffers",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                comment: "SelectOffer Description");

            migrationBuilder.AlterColumn<Guid>(
                name: "BarbershopId",
                table: "Offers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "FK describe relation between Barbershop and Offer");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Barbershops_BarbershopId",
                table: "Offers",
                column: "BarbershopId",
                principalTable: "Barbershops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
