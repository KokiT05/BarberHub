using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationBetweenBarbershopAndAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_AspNetUsers_UserId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Barbershops_BarbershopId1",
                table: "Appointment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_BarbershopId1",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "BarbershopId1",
                table: "Appointment");

            migrationBuilder.RenameTable(
                name: "Appointment",
                newName: "Appointments");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_UserId",
                table: "Appointments",
                newName: "IX_Appointments_UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SelectedOn",
                table: "UserOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 11, 22, 34, 8, 992, DateTimeKind.Local).AddTicks(8997),
                comment: "Date and time when the offer was selected",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 11, 22, 16, 42, 961, DateTimeKind.Local).AddTicks(4717),
                oldComment: "Date and time when the offer was selected");

            migrationBuilder.AlterColumn<Guid>(
                name: "BarbershopId",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_BarbershopId",
                table: "Appointments",
                column: "BarbershopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId",
                table: "Appointments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Barbershops_BarbershopId",
                table: "Appointments",
                column: "BarbershopId",
                principalTable: "Barbershops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Barbershops_BarbershopId",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_BarbershopId",
                table: "Appointments");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "Appointment");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_UserId",
                table: "Appointment",
                newName: "IX_Appointment_UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SelectedOn",
                table: "UserOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 11, 22, 16, 42, 961, DateTimeKind.Local).AddTicks(4717),
                comment: "Date and time when the offer was selected",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 11, 22, 34, 8, 992, DateTimeKind.Local).AddTicks(8997),
                oldComment: "Date and time when the offer was selected");

            migrationBuilder.AlterColumn<string>(
                name: "BarbershopId",
                table: "Appointment",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "BarbershopId1",
                table: "Appointment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_BarbershopId1",
                table: "Appointment",
                column: "BarbershopId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_AspNetUsers_UserId",
                table: "Appointment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Barbershops_BarbershopId1",
                table: "Appointment",
                column: "BarbershopId1",
                principalTable: "Barbershops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
