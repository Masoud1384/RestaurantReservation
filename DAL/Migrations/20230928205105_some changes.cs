using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class somechanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReservationTime",
                table: "reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 28, 13, 51, 5, 643, DateTimeKind.Local).AddTicks(7694),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 28, 12, 59, 20, 864, DateTimeKind.Local).AddTicks(6194));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReservationTime",
                table: "reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 28, 12, 59, 20, 864, DateTimeKind.Local).AddTicks(6194),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 28, 13, 51, 5, 643, DateTimeKind.Local).AddTicks(7694));
        }
    }
}
