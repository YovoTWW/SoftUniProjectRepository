using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EuropeBJJ.Data.Migrations
{
    /// <inheritdoc />
    public partial class EventRefactoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_AccountId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_Seminar_AccountId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_Seminar_AccountId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Seminar_AccountId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Seminar_Description",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Seminar_IsRemoved",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Seminar_Location",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Seminar_MembersPrice",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Seminar_NonMembersPrice",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Seminar_Organiser",
                table: "Events");

            migrationBuilder.AlterColumn<bool>(
                name: "IsRemoved",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccountId", "Date", "Description", "IsRemoved", "Location", "MembersPrice", "NonMembersPrice", "Organiser", "Teacher" },
                values: new object[] { null, new DateTime(2024, 11, 18, 12, 39, 33, 952, DateTimeKind.Local).AddTicks(910), null, false, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccountId", "Date", "Description", "IsRemoved", "Location", "MembersPrice", "NonMembersPrice", "Organiser", "Teacher" },
                values: new object[] { null, new DateTime(2024, 11, 18, 12, 39, 33, 952, DateTimeKind.Local).AddTicks(954), null, false, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccountId", "Date", "Description", "IsRemoved", "Location", "MembersPrice", "NonMembersPrice", "Organiser", "Teacher" },
                values: new object[] { null, new DateTime(2024, 11, 18, 12, 39, 33, 952, DateTimeKind.Local).AddTicks(957), null, false, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AccountId", "Date", "Description", "IsRemoved", "Location", "MembersPrice", "NonMembersPrice", "Organiser", "Teacher" },
                values: new object[] { null, new DateTime(2024, 11, 18, 12, 39, 33, 952, DateTimeKind.Local).AddTicks(959), null, false, null, null, null, null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_AccountId",
                table: "Events",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_AccountId",
                table: "Events");

            migrationBuilder.AlterColumn<bool>(
                name: "IsRemoved",
                table: "Events",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "Seminar_AccountId",
                table: "Events",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Seminar_Description",
                table: "Events",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Seminar_IsRemoved",
                table: "Events",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Seminar_Location",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Seminar_MembersPrice",
                table: "Events",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Seminar_NonMembersPrice",
                table: "Events",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Seminar_Organiser",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 18, 12, 20, 54, 768, DateTimeKind.Local).AddTicks(1623));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 18, 12, 20, 54, 768, DateTimeKind.Local).AddTicks(1674));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 11, 18, 12, 20, 54, 768, DateTimeKind.Local).AddTicks(1678));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 11, 18, 12, 20, 54, 768, DateTimeKind.Local).AddTicks(1681));

            migrationBuilder.CreateIndex(
                name: "IX_Events_Seminar_AccountId",
                table: "Events",
                column: "Seminar_AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_AccountId",
                table: "Events",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_Seminar_AccountId",
                table: "Events",
                column: "Seminar_AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
