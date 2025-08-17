using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BarberHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedBarbershops : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SelectedOn",
                table: "UserOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 17, 7, 41, 8, 215, DateTimeKind.Local).AddTicks(315),
                comment: "Date and time when the offer was selected",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 14, 23, 16, 41, 925, DateTimeKind.Local).AddTicks(750),
                oldComment: "Date and time when the offer was selected");

            migrationBuilder.InsertData(
                table: "Barbershops",
                columns: new[] { "Id", "Address", "City", "CloseTime", "Description", "ImageUrl", "Name", "OpenTime", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("0b345d63-4eeb-44a0-b61a-a3d19c9555c5"), "ул. Тодор Александров 12", "Благоевград", new TimeOnly(18, 0, 0), "Спокойна обстановка и професионализъм.", "https://example.com/barberspot.png", "The Barber Spot", new TimeOnly(9, 30, 0), "0884111222" },
                    { new Guid("23f53a53-bf8b-4bba-bd00-e920d0953a8e"), "ул. Сливница 101", "Варна", new TimeOnly(20, 0, 0), "Метал, кожа и стилни подстрижки.", "https://example.com/steelandstyle.jpg", "Steel & Style", new TimeOnly(10, 0, 0), "0889012345" },
                    { new Guid("34d8bf59-88af-4d1b-b761-a65e2b67827c"), "ул. Данаил Попов 5", "Плевен", new TimeOnly(19, 0, 0), "Независим стил за свободни хора.", "https://example.com/barberrepublic.jpg", "Barber Republic", new TimeOnly(8, 0, 0), "0885333444" },
                    { new Guid("4dc134e6-6a16-4a6d-b685-b6066207c18f"), "бул. Дондуков 66", "София", new TimeOnly(19, 0, 0), "Бръснарница в сърцето на града.", "https://example.com/downtownbarber.webp", "Downtown Barber", new TimeOnly(9, 0, 0), "0898989898" },
                    { new Guid("5cc99a51-6dc3-4eae-8103-e5a11fceba0e"), "ул. Богориди 14", "Бургас", new TimeOnly(20, 0, 0), "Точност и стил във всяка прическа.", "https://example.com/sharplook.png", "Sharp Look", new TimeOnly(10, 0, 0), "0883456789" },
                    { new Guid("60fdc286-fcb9-415c-b5b0-3ba7e89e25ce"), "ул. Александровска 9", "Русе", new TimeOnly(19, 0, 0), "Място за модерния джентълмен.", "https://example.com/moderngents.jpg", "Modern Gents", new TimeOnly(9, 30, 0), "0886543210" },
                    { new Guid("6aa8e559-9f84-4e87-9351-28a2b0da612a"), "ж.к. Младост 1, бл. 54", "София", new TimeOnly(20, 0, 0), "Специалисти в fade стил подстрижките.", "https://example.com/fadehouse.jpg", "The Fade House", new TimeOnly(8, 0, 0), "0897654123" },
                    { new Guid("73956d5e-5a39-4274-8c8a-1e59bef9a69b"), "ул. Цар Симеон Велики 45", "Стара Загора", new TimeOnly(19, 30, 0), "Премиум обслужване и уютна атмосфера.", "https://example.com/elitebarbers.png", "Elite Barbers", new TimeOnly(8, 30, 0), "0877456321" },
                    { new Guid("90625b4c-37c5-45e0-b907-e6cb112546b9"), "ул. Христо Ботев 32", "Пловдив", new TimeOnly(18, 0, 0), "Класика в мъжките подстрижки.", "https://example.com/kingscuts.jpg", "King's Cuts", new TimeOnly(8, 0, 0), "0899765432" },
                    { new Guid("9bbc6a4b-52fa-48e9-8bcf-eea7eb011720"), "ул. Съединение 27", "Бургас", new TimeOnly(18, 30, 0), "Място за истинско златно обслужване.", "https://example.com/goldenrazor.jpg", "Golden Razor", new TimeOnly(9, 0, 0), "0877011223" },
                    { new Guid("acc57349-ea74-470b-b548-d9f485be8e2a"), "ул. Независимост 17", "Велико Търново", new TimeOnly(18, 30, 0), "Традиционни подстрижки и бръснене.", "https://example.com/classicbarber.jpg", "Classic Barber", new TimeOnly(9, 0, 0), "0877123456" },
                    { new Guid("e50edee5-a5b3-4533-a996-3aa73d1d6af2"), "ул. Александър Стамболийски 78", "София", new TimeOnly(19, 30, 0), "Съвременна бръснарница с младежки стил.", "https://example.com/urbanfade.jpg", "Urban Fade", new TimeOnly(9, 0, 0), "0899123456" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("0b345d63-4eeb-44a0-b61a-a3d19c9555c5"));

            migrationBuilder.DeleteData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("23f53a53-bf8b-4bba-bd00-e920d0953a8e"));

            migrationBuilder.DeleteData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("34d8bf59-88af-4d1b-b761-a65e2b67827c"));

            migrationBuilder.DeleteData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("4dc134e6-6a16-4a6d-b685-b6066207c18f"));

            migrationBuilder.DeleteData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("5cc99a51-6dc3-4eae-8103-e5a11fceba0e"));

            migrationBuilder.DeleteData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("60fdc286-fcb9-415c-b5b0-3ba7e89e25ce"));

            migrationBuilder.DeleteData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("6aa8e559-9f84-4e87-9351-28a2b0da612a"));

            migrationBuilder.DeleteData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("73956d5e-5a39-4274-8c8a-1e59bef9a69b"));

            migrationBuilder.DeleteData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("90625b4c-37c5-45e0-b907-e6cb112546b9"));

            migrationBuilder.DeleteData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("9bbc6a4b-52fa-48e9-8bcf-eea7eb011720"));

            migrationBuilder.DeleteData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("acc57349-ea74-470b-b548-d9f485be8e2a"));

            migrationBuilder.DeleteData(
                table: "Barbershops",
                keyColumn: "Id",
                keyValue: new Guid("e50edee5-a5b3-4533-a996-3aa73d1d6af2"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SelectedOn",
                table: "UserOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 14, 23, 16, 41, 925, DateTimeKind.Local).AddTicks(750),
                comment: "Date and time when the offer was selected",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 17, 7, 41, 8, 215, DateTimeKind.Local).AddTicks(315),
                oldComment: "Date and time when the offer was selected");
        }
    }
}
