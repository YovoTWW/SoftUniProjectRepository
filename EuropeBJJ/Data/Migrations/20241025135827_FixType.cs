using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EuropeBJJ.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 10, 25, 16, 58, 27, 35, DateTimeKind.Local).AddTicks(5904));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 10, 25, 16, 58, 27, 35, DateTimeKind.Local).AddTicks(5956));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 10, 25, 16, 58, 27, 35, DateTimeKind.Local).AddTicks(5960));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 10, 25, 16, 58, 27, 35, DateTimeKind.Local).AddTicks(5964));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 10, 25, 16, 29, 45, 286, DateTimeKind.Local).AddTicks(8114));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 10, 25, 16, 29, 45, 286, DateTimeKind.Local).AddTicks(8191));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 10, 25, 16, 29, 45, 286, DateTimeKind.Local).AddTicks(8194));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 10, 25, 16, 29, 45, 286, DateTimeKind.Local).AddTicks(8197));
        }
    }
}
