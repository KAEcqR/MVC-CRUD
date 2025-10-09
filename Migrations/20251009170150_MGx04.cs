using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_CRUD.Migrations
{
    /// <inheritdoc />
    public partial class MGx04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Venues",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Venues",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Capacity", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Capacity", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Capacity", "Description" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Events_VenueId",
                table: "Events",
                column: "VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Venues_VenueId",
                table: "Events",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Venues_VenueId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_VenueId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Venues");
        }
    }
}
