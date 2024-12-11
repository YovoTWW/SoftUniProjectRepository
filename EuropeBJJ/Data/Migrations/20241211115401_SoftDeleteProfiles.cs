using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EuropeBJJ.Data.Migrations
{
    /// <inheritdoc />
    public partial class SoftDeleteProfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Profiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 11, 13, 54, 0, 855, DateTimeKind.Local).AddTicks(7156));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 12, 11, 13, 54, 0, 855, DateTimeKind.Local).AddTicks(7201));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 12, 11, 13, 54, 0, 855, DateTimeKind.Local).AddTicks(7206));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 12, 11, 13, 54, 0, 855, DateTimeKind.Local).AddTicks(7209));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 14,
                column: "Date",
                value: new DateTime(2024, 12, 11, 13, 54, 0, 855, DateTimeKind.Local).AddTicks(7212));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Profiles");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 10, 22, 23, 11, 448, DateTimeKind.Local).AddTicks(695));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 12, 10, 22, 23, 11, 448, DateTimeKind.Local).AddTicks(738));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 12, 10, 22, 23, 11, 448, DateTimeKind.Local).AddTicks(742));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 12, 10, 22, 23, 11, 448, DateTimeKind.Local).AddTicks(745));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 14,
                column: "Date",
                value: new DateTime(2024, 12, 10, 22, 23, 11, 448, DateTimeKind.Local).AddTicks(748));
        }
    }
}
