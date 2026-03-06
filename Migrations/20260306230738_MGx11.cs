using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC_CRUD.Migrations
{
    /// <inheritdoc />
    public partial class MGx11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateOnly(2026, 3, 7));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateOnly(2026, 3, 7));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateOnly(2026, 3, 7));

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Artist", "CreationDate", "Date", "ImagePath", "TicketsLeft", "Title", "TotalTickets", "VenueId" },
                values: new object[,]
                {
                    { 4, "Miles Davis Tribute", new DateOnly(2026, 3, 7), new DateOnly(2026, 3, 15), "jazznight.jpg", 380, "Jazz Night", 400, 1 },
                    { 5, "The Rolling Stones Covers", new DateOnly(2026, 3, 7), new DateOnly(2026, 4, 10), "rockconcert.jpg", 650, "Rock Concert", 800, 2 },
                    { 6, "Industry Leaders Panel", new DateOnly(2026, 3, 7), new DateOnly(2026, 5, 22), "techconf.jpg", 120, "Tech Conference 2026", 250, 3 },
                    { 7, "Stand-up Comics Showcase", new DateOnly(2026, 3, 7), new DateOnly(2026, 6, 5), "comedy.jpg", 200, "Comedy Night", 350, 1 },
                    { 8, "Philharmonic Orchestra", new DateOnly(2026, 3, 7), new DateOnly(2026, 7, 12), "symphony.jpg", 900, "Classical Symphony", 900, 2 },
                    { 9, "International Cinema", new DateOnly(2026, 3, 7), new DateOnly(2026, 8, 1), "filmfest.jpg", 180, "Film Festival Opening", 280, 3 },
                    { 10, "Contemporary Dance Ensemble", new DateOnly(2026, 3, 7), new DateOnly(2026, 9, 18), "dance.jpg", 350, "Dance Spectacular", 450, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateOnly(2025, 10, 25));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateOnly(2025, 10, 25));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateOnly(2025, 10, 25));
        }
    }
}
