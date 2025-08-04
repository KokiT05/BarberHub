using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddQueryFilter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("ff85166e-757b-4487-aea9-54bcdc2169d0"));

            migrationBuilder.UpdateData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("1a2b3c4d-5e6f-7890-abcd-ef1234567890"),
                column: "PhoneNumber",
                value: "0881233361");

            migrationBuilder.UpdateData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"),
                column: "PhoneNumber",
                value: "0887654321");

            migrationBuilder.UpdateData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("f6e5d4c3-b2a1-0987-6543-210fedcba987"),
                column: "PhoneNumber",
                value: "0885126287");

            migrationBuilder.InsertData(
                table: "Barbershops",
                columns: new[] { "Id", "Address", "City", "CloseTime", "Description", "ImageUrl", "Name", "OpenTime", "PhoneNumber" },
                values: new object[] { new Guid("b77ffead-2b9b-4fa9-9bc9-964e2a7c0c18"), "бул. Ломско шосе", "Sofia", new TimeOnly(20, 30, 0), "Just a barbershop", "~/images/no-image.jpg", "The Brothers", new TimeOnly(8, 30, 0), "0881234567" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("b77ffead-2b9b-4fa9-9bc9-964e2a7c0c18"));

            migrationBuilder.UpdateData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("1a2b3c4d-5e6f-7890-abcd-ef1234567890"),
                column: "PhoneNumber",
                value: null);

            migrationBuilder.UpdateData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"),
                column: "PhoneNumber",
                value: null);

            migrationBuilder.UpdateData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("f6e5d4c3-b2a1-0987-6543-210fedcba987"),
                column: "PhoneNumber",
                value: null);

            migrationBuilder.InsertData(
                table: "Barbershops",
                columns: new[] { "Id", "Address", "City", "CloseTime", "Description", "ImageUrl", "Name", "OpenTime", "PhoneNumber" },
                values: new object[] { new Guid("ff85166e-757b-4487-aea9-54bcdc2169d0"), "бул. Ломско шосе", "Sofia", new TimeOnly(20, 30, 0), "Just a barbershop", "~/images/no-image.jpg", "The Brothers", new TimeOnly(8, 30, 0), null });
        }
    }
}
