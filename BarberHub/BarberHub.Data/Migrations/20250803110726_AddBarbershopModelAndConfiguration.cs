using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BarberHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBarbershopModelAndConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barbershops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Barbershop Identifier"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Barbershop Name"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, comment: "Barbershop Description"),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true, comment: "Barbershop image url"),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Barbershop City"),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Barbershop Address"),
                    OpenTime = table.Column<TimeOnly>(type: "time", nullable: true, comment: "Barbershop opening time"),
                    CloseTime = table.Column<TimeOnly>(type: "time", nullable: true, comment: "Barbershop closing time"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Show if barbershop is deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbershops", x => x.Id);
                },
                comment: "Barbershop in the system");

            migrationBuilder.InsertData(
                table: "Barbershops",
                columns: new[] { "Id", "Address", "City", "CloseTime", "Description", "ImageUrl", "Name", "OpenTime" },
                values: new object[,]
                {
                    { new Guid("1a2b3c4d-5e6f-7890-abcd-ef1234567890"), "ул. Княз Борис I 25", "Варна", new TimeOnly(17, 30, 0), "Ексклузивна бръснарница за истински господа.", "https://example.com/gentlemensquarters.webp", "Gentlemen's Quarters", new TimeOnly(8, 30, 0) },
                    { new Guid("6129abe5-2514-4431-867e-5247150aaf60"), "бул. Ломско шосе", "Sofia", new TimeOnly(20, 30, 0), "Just a barbershop", "~/images/no-image.jpg", "The Brothers", new TimeOnly(8, 30, 0) },
                    { new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"), "ул. Витоша 15", "София", new TimeOnly(18, 0, 0), "Традиционна бръснарница с модерен привкус.", "https://example.com/barbersden.jpg", "Barber's Den", new TimeOnly(9, 0, 0) },
                    { new Guid("f6e5d4c3-b2a1-0987-6543-210fedcba987"), "бул. Свобода 10", "Пловдив", new TimeOnly(19, 0, 0), "Място, където стилът среща прецизността.", "https://example.com/clipjoint.png", "The Clip Joint", new TimeOnly(10, 0, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Barbershops");
        }
    }
}
