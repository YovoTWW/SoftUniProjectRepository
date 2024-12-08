using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EuropeBJJ.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSponsors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sponsors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsors", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 8, 15, 46, 41, 457, DateTimeKind.Local).AddTicks(7169));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 12, 8, 15, 46, 41, 457, DateTimeKind.Local).AddTicks(7208));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 12, 8, 15, 46, 41, 457, DateTimeKind.Local).AddTicks(7212));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 12, 8, 15, 46, 41, 457, DateTimeKind.Local).AddTicks(7216));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 14,
                column: "Date",
                value: new DateTime(2024, 12, 8, 15, 46, 41, 457, DateTimeKind.Local).AddTicks(7220));

            migrationBuilder.InsertData(
                table: "Sponsors",
                columns: new[] { "Id", "Image", "IsRemoved", "Link", "Name" },
                values: new object[,]
                {
                    { 1, "/img/BornWinner.jpg", false, "https://www.bornwinner.bg", "Born Winner" },
                    { 2, "/img/groundgame.jpg", false, "https://groundgame.com/", "Ground Game" },
                    { 3, "/img/FUJI_Mats.jpg", false, "https://fujimats.com/", "FUJI Mats" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sponsors");

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

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 14,
                column: "Date",
                value: new DateTime(2024, 12, 6, 17, 39, 22, 521, DateTimeKind.Local).AddTicks(6488));
        }
    }
}
