using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EuropeBJJ.Data.Migrations
{
    /// <inheritdoc />
    public partial class Refactoring2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "Events",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Events",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Events",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MembersPrice",
                table: "Events",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NonMembersPrice",
                table: "Events",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Organiser",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "Teacher",
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
                name: "IX_Events_AccountId",
                table: "Events",
                column: "AccountId");

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
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_Seminar_AccountId",
                table: "Events",
                column: "Seminar_AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_AccountId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_Seminar_AccountId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_AccountId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_Seminar_AccountId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "MembersPrice",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "NonMembersPrice",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Organiser",
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

            migrationBuilder.DropColumn(
                name: "Teacher",
                table: "Events");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 18, 12, 11, 49, 742, DateTimeKind.Local).AddTicks(8108));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 18, 12, 11, 49, 742, DateTimeKind.Local).AddTicks(8157));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 11, 18, 12, 11, 49, 742, DateTimeKind.Local).AddTicks(8162));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 11, 18, 12, 11, 49, 742, DateTimeKind.Local).AddTicks(8166));
        }
    }
}
