using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BarberHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOfferModelAndOfferConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("b77ffead-2b9b-4fa9-9bc9-964e2a7c0c18"));

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Offer Identifier"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Offer Name"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, comment: "Offer Description"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", maxLength: 100, nullable: false, comment: "Offer Price")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                },
                comment: "Offer in the system");

            migrationBuilder.UpdateData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"),
                column: "Description",
                value: "Традиционна бръснарница с модерен привкус.");

            migrationBuilder.InsertData(
                table: "Barbershops",
                columns: new[] { "Id", "Address", "City", "CloseTime", "Description", "ImageUrl", "Name", "OpenTime", "PhoneNumber" },
                values: new object[] { new Guid("26aee914-41af-47f2-88b2-522e4aa203e4"), "бул. Ломско шосе", "Sofia", new TimeOnly(20, 30, 0), "Just a barbershop", "~/images/no-image.jpg", "The Brothers", new TimeOnly(8, 30, 0), "0881234567" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("0d4de42a-f4b0-4e1a-a6ee-9df1ead44ff6"), "Добре оформена брада с бръснач", "Оформяне на брада", 3m },
                    { new Guid("6582820a-79c5-4ecf-853d-544b64f528ed"), "Оформяне на вежди", "Оформяне на вежди", 2m },
                    { new Guid("99242240-c9e9-42ff-8414-8536eb740c84"), "Минаване с машина за подстригване по цялата глава с един номер", "Подстригване с един номер", 5m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DeleteData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("26aee914-41af-47f2-88b2-522e4aa203e4"));

            migrationBuilder.UpdateData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"),
                column: "Description",
                value: "Традиционна бръснарница Offer модерен привкус.");

            migrationBuilder.InsertData(
                table: "Barbershops",
                columns: new[] { "Id", "Address", "City", "CloseTime", "Description", "ImageUrl", "Name", "OpenTime", "PhoneNumber" },
                values: new object[] { new Guid("b77ffead-2b9b-4fa9-9bc9-964e2a7c0c18"), "бул. Ломско шосе", "Sofia", new TimeOnly(20, 30, 0), "Just a barbershop", "~/images/no-image.jpg", "The Brothers", new TimeOnly(8, 30, 0), "0881234567" });
        }
    }
}
