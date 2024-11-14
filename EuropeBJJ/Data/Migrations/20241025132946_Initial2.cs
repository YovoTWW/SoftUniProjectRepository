using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EuropeBJJ.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Organiser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MembersPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NonMembersPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_AspNetUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OrganizedEventsAccounts_Events_OrganizedEventId",
                        column: x => x.OrganizedEventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "City", "Country", "Date", "Discriminator", "Image", "Link", "Name" },
                values: new object[,]
                {
                    { 1, "Sofia", "Bulgaria", new DateTime(2024, 10, 25, 16, 29, 45, 286, DateTimeKind.Local).AddTicks(8114), "Tournament", "https://smoothcomp.com/pictures/t/4582681-vxth/adcc-balkan-open-championships-2024.png", "https://smoothcomp.com/en/event/17862", "ADCC Balkans Open" },
                    { 2, "Sofia", "Bulgaria", new DateTime(2024, 10, 25, 16, 29, 45, 286, DateTimeKind.Local).AddTicks(8191), "Tournament", "https://smoothcomp.com/pictures/t/4794848-q7z/2024-bulgarian-jiu-jitsu-championship.jpg", "https://agf.smoothcomp.com/en/event/19393", "AGF 2024 BULGARIAN JIU JITSU CHAMPIONSHIPS" },
                    { 3, "Sofia", "Bulgaria", new DateTime(2024, 10, 25, 16, 29, 45, 286, DateTimeKind.Local).AddTicks(8194), "Tournament", "https://ajptour.com/build/webpack/img/ajp/fallback.a01f59147724b9274315365bd75f5b21.jpg", "https://ajptour.com/en/event/1104", "AJP TOUR BULGARIA NATIONAL JIU-JITSU CHAMPIONSHIP 2024 - GI & NO-GI" },
                    { 4, "Lisbon", "Portugal", new DateTime(2024, 10, 25, 16, 29, 45, 286, DateTimeKind.Local).AddTicks(8197), "Tournament", "https://ibjjf.com/rails/active_storage/blobs/eyJfcmFpbHMiOnsibWVzc2FnZSI6IkJBaHBBam9hIiwiZXhwIjpudWxsLCJwdXIiOiJibG9iX2lkIn19--17bf4a00266e5788a79c44d985d0b399c0ab0bec/lisbon-2024-logo-website-white%20(1).png", "https://ibjjf.com/events/lisbon-international-open-ibjjf-jiu-jitsu-championship-2024", "Lisbon International Open IBJJF Jiu-Jitsu Championship 2024" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_AccountId",
                table: "Events",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizedEventsAccounts_AccountId",
                table: "OrganizedEventsAccounts",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizedEventsAccounts");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
