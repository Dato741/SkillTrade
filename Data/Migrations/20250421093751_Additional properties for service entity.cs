using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillTrade.Data.Migrations
{
    /// <inheritdoc />
    public partial class Additionalpropertiesforserviceentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ServiceListings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PayOffered",
                table: "ServiceListings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ServiceListings");

            migrationBuilder.DropColumn(
                name: "PayOffered",
                table: "ServiceListings");
        }
    }
}
