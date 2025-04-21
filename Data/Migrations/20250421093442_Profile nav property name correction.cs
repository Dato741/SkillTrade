using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillTrade.Data.Migrations
{
    /// <inheritdoc />
    public partial class Profilenavpropertynamecorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Profiles_UserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Profiles_UserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceListings_Profiles_UserId",
                table: "ServiceListings");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ServiceListings",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceListings_UserId",
                table: "ServiceListings",
                newName: "IX_ServiceListings_ProfileId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reviews",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                newName: "IX_Reviews_ProfileId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Bookings",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                newName: "IX_Bookings_ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Profiles_ProfileId",
                table: "Bookings",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Profiles_ProfileId",
                table: "Reviews",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceListings_Profiles_ProfileId",
                table: "ServiceListings",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Profiles_ProfileId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Profiles_ProfileId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceListings_Profiles_ProfileId",
                table: "ServiceListings");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "ServiceListings",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceListings_ProfileId",
                table: "ServiceListings",
                newName: "IX_ServiceListings_UserId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Reviews",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ProfileId",
                table: "Reviews",
                newName: "IX_Reviews_UserId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Bookings",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_ProfileId",
                table: "Bookings",
                newName: "IX_Bookings_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Profiles_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Profiles_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceListings_Profiles_UserId",
                table: "ServiceListings",
                column: "UserId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
