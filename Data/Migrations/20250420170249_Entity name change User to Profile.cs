using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillTrade.Data.Migrations
{
    /// <inheritdoc />
    public partial class EntitynamechangeUsertoProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_UsersSkillTrade_UserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_UsersSkillTrade_UserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceListings_UsersSkillTrade_UserId",
                table: "ServiceListings");

            migrationBuilder.DropTable(
                name: "UsersSkillTrade");

            migrationBuilder.AddColumn<string>(
                name: "ServicePostedBy",
                table: "ServiceListings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropColumn(
                name: "ServicePostedBy",
                table: "ServiceListings");

            migrationBuilder.CreateTable(
                name: "UsersSkillTrade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersSkillTrade", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_UsersSkillTrade_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "UsersSkillTrade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_UsersSkillTrade_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "UsersSkillTrade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceListings_UsersSkillTrade_UserId",
                table: "ServiceListings",
                column: "UserId",
                principalTable: "UsersSkillTrade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
