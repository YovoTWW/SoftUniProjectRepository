using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EuropeBJJ.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTournamentToSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 6, 17, 39, 22, 521, DateTimeKind.Local).AddTicks(6437));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 12, 6, 17, 39, 22, 521, DateTimeKind.Local).AddTicks(6480));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 12, 6, 17, 39, 22, 521, DateTimeKind.Local).AddTicks(6483));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 12, 6, 17, 39, 22, 521, DateTimeKind.Local).AddTicks(6485));

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AccountId", "City", "Country", "Date", "Description", "Discriminator", "Image", "IsRemoved", "Link", "Location", "MembersPrice", "Name", "NonMembersPrice", "Organiser", "Teacher" },
                values: new object[] { 14, null, "Sofia", "Bulgaria", new DateTime(2024, 12, 6, 17, 39, 22, 521, DateTimeKind.Local).AddTicks(6488), null, "Tournament", "https://smoothcomp.com/pictures/t/5170482-d6y7/sjjifbf-sofia-winter-open-2025-gi-no-gi.jpg", false, "https://sjjif.smoothcomp.com/en/event/20819", null, null, "SJJIFBF Sofia Winter Open 2025 Gi & No-Gi ", null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 24, 15, 39, 52, 684, DateTimeKind.Local).AddTicks(8855));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 24, 15, 39, 52, 684, DateTimeKind.Local).AddTicks(8907));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 11, 24, 15, 39, 52, 684, DateTimeKind.Local).AddTicks(8910));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 11, 24, 15, 39, 52, 684, DateTimeKind.Local).AddTicks(8913));
        }
    }
}
