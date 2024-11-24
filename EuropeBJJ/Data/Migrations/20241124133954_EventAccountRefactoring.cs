using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EuropeBJJ.Data.Migrations
{
    /// <inheritdoc />
    public partial class EventAccountRefactoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizedEventsAccounts");

            migrationBuilder.CreateTable(
                name: "EventsAccounts",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsAccounts", x => new { x.EventId, x.AccountId });
                    table.ForeignKey(
                        name: "FK_EventsAccounts_AspNetUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventsAccounts_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_EventsAccounts_AccountId",
                table: "EventsAccounts",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventsAccounts");

            migrationBuilder.CreateTable(
                name: "OrganizedEventsAccounts",
                columns: table => new
                {
                    OrganizedEventId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizedEventsAccounts", x => new { x.OrganizedEventId, x.AccountId });
                    table.ForeignKey(
                        name: "FK_OrganizedEventsAccounts_AspNetUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizedEventsAccounts_Events_OrganizedEventId",
                        column: x => x.OrganizedEventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 18, 12, 39, 33, 952, DateTimeKind.Local).AddTicks(910));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 18, 12, 39, 33, 952, DateTimeKind.Local).AddTicks(954));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 11, 18, 12, 39, 33, 952, DateTimeKind.Local).AddTicks(957));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 11, 18, 12, 39, 33, 952, DateTimeKind.Local).AddTicks(959));

            migrationBuilder.CreateIndex(
                name: "IX_OrganizedEventsAccounts_AccountId",
                table: "OrganizedEventsAccounts",
                column: "AccountId");
        }
    }
}
