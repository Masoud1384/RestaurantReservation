using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class chages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserToken_users_userId",
                table: "UserToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserToken",
                table: "UserToken");

            migrationBuilder.RenameTable(
                name: "UserToken",
                newName: "UserTokens");

            migrationBuilder.RenameIndex(
                name: "IX_UserToken_userId",
                table: "UserTokens",
                newName: "IX_UserTokens_userId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReservationTime",
                table: "reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 28, 14, 18, 18, 591, DateTimeKind.Local).AddTicks(5879),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 28, 13, 51, 5, 643, DateTimeKind.Local).AddTicks(7694));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTokens",
                table: "UserTokens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_users_userId",
                table: "UserTokens",
                column: "userId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_users_userId",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTokens",
                table: "UserTokens");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                newName: "UserToken");

            migrationBuilder.RenameIndex(
                name: "IX_UserTokens_userId",
                table: "UserToken",
                newName: "IX_UserToken_userId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReservationTime",
                table: "reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 28, 13, 51, 5, 643, DateTimeKind.Local).AddTicks(7694),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 28, 14, 18, 18, 591, DateTimeKind.Local).AddTicks(5879));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserToken",
                table: "UserToken",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserToken_users_userId",
                table: "UserToken",
                column: "userId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
