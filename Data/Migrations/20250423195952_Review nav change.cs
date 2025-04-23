using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillTrade.Data.Migrations
{
    /// <inheritdoc />
    public partial class Reviewnavchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "ServiceListings");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "Reviews",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_BookingId",
                table: "Reviews",
                newName: "IX_Reviews_ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_ServiceListings_ServiceId",
                table: "Reviews",
                column: "ServiceId",
                principalTable: "ServiceListings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_ServiceListings_ServiceId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Reviews",
                newName: "BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ServiceId",
                table: "Reviews",
                newName: "IX_Reviews_BookingId");

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "ServiceListings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceListings_ReviewId",
                table: "ServiceListings",
                column: "ReviewId");

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
    }
}
