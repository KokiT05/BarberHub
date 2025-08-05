using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOfferPricePrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("26aee914-41af-47f2-88b2-522e4aa203e4"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Offers",
                type: "decimal(3,2)",
                maxLength: 100,
                precision: 3,
                scale: 2,
                nullable: false,
                comment: "Offer Price",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 100,
                oldComment: "Offer Price");

            migrationBuilder.InsertData(
                table: "Barbershops",
                columns: new[] { "Id", "Address", "City", "CloseTime", "Description", "ImageUrl", "Name", "OpenTime", "PhoneNumber" },
                values: new object[] { new Guid("9c31e450-0fd6-4aa6-8d05-cd79b87ce656"), "бул. Ломско шосе", "Sofia", new TimeOnly(20, 30, 0), "Just a barbershop", "~/images/no-image.jpg", "The Brothers", new TimeOnly(8, 30, 0), "0881234567" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("9c31e450-0fd6-4aa6-8d05-cd79b87ce656"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Offers",
                type: "decimal(18,2)",
                maxLength: 100,
                nullable: false,
                comment: "Offer Price",
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldMaxLength: 100,
                oldPrecision: 3,
                oldScale: 2,
                oldComment: "Offer Price");

            migrationBuilder.InsertData(
                table: "Barbershops",
                columns: new[] { "Id", "Address", "City", "CloseTime", "Description", "ImageUrl", "Name", "OpenTime", "PhoneNumber" },
                values: new object[] { new Guid("26aee914-41af-47f2-88b2-522e4aa203e4"), "бул. Ломско шосе", "Sofia", new TimeOnly(20, 30, 0), "Just a barbershop", "~/images/no-image.jpg", "The Brothers", new TimeOnly(8, 30, 0), "0881234567" });
        }
    }
}
