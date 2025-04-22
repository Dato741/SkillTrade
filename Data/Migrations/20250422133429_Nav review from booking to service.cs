using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillTrade.Data.Migrations
{
    /// <inheritdoc />
    public partial class Navreviewfrombookingtoservice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Reviews_ReviewId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ReviewId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "ServiceListings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceListings_ReviewId",
                table: "ServiceListings",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookingId",
                table: "Reviews",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Bookings_BookingId",
                table: "Reviews",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceListings_Reviews_ReviewId",
                table: "ServiceListings",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Bookings_BookingId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceListings_Reviews_ReviewId",
                table: "ServiceListings");

            migrationBuilder.DropIndex(
                name: "IX_ServiceListings_ReviewId",
                table: "ServiceListings");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_BookingId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "ServiceListings");

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ReviewId",
                table: "Bookings",
                column: "ReviewId",
                unique: true,
                filter: "[ReviewId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Reviews_ReviewId",
                table: "Bookings",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
