using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Usertablechanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReservationTime",
                table: "reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 20, 19, 29, 39, 934, DateTimeKind.Local).AddTicks(496),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 18, 16, 17, 5, 381, DateTimeKind.Local).AddTicks(2416));

            migrationBuilder.CreateIndex(
                name: "IX_restaurants_name",
                table: "restaurants",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_restaurants_name",
                table: "restaurants");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReservationTime",
                table: "reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 18, 16, 17, 5, 381, DateTimeKind.Local).AddTicks(2416),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 20, 19, 29, 39, 934, DateTimeKind.Local).AddTicks(496));
        }
    }
}
