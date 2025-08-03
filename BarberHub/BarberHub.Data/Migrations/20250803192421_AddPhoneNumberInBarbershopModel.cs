using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPhoneNumberInBarbershopModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("6129abe5-2514-4431-867e-5247150aaf60"));

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Barbershops",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                comment: "Barbershop Phone number");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("ff85166e-757b-4487-aea9-54bcdc2169d0"));

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Barbershops");

            migrationBuilder.InsertData(
                table: "Barbershops",
                columns: new[] { "Id", "Address", "City", "CloseTime", "Description", "ImageUrl", "Name", "OpenTime" },
                values: new object[] { new Guid("6129abe5-2514-4431-867e-5247150aaf60"), "бул. Ломско шосе", "Sofia", new TimeOnly(20, 30, 0), "Just a barbershop", "~/images/no-image.jpg", "The Brothers", new TimeOnly(8, 30, 0) });
        }
    }
}
