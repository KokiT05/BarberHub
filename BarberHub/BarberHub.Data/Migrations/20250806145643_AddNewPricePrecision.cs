using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPricePrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Offers",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                comment: "Offer Price",
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldMaxLength: 100,
                oldPrecision: 3,
                oldScale: 2,
                oldComment: "Offer Price");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                oldType: "decimal(5,2)",
                oldPrecision: 5,
                oldScale: 2,
                oldComment: "Offer Price");
        }
    }
}
