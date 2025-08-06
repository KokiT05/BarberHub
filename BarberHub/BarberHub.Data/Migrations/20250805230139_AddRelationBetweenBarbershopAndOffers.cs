using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationBetweenBarbershopAndOffers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BarbershopId",
                table: "Offers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("0d4de42a-f4b0-4e1a-a6ee-9df1ead44ff6"),
                column: "BarbershopId",
                value: new Guid("9c31e450-0fd6-4aa6-8d05-cd79b87ce656"));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("6582820a-79c5-4ecf-853d-544b64f528ed"),
                column: "BarbershopId",
                value: new Guid("9c31e450-0fd6-4aa6-8d05-cd79b87ce656"));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("99242240-c9e9-42ff-8414-8536eb740c84"),
                column: "BarbershopId",
                value: new Guid("9c31e450-0fd6-4aa6-8d05-cd79b87ce656"));

            migrationBuilder.CreateIndex(
                name: "IX_Offers_BarbershopId",
                table: "Offers",
                column: "BarbershopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Barbershops_BarbershopId",
                table: "Offers",
                column: "BarbershopId",
                principalTable: "Barbershops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Barbershops_BarbershopId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_BarbershopId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "BarbershopId",
                table: "Offers");
        }
    }
}
