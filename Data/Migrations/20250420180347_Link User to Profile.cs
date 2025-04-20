using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillTrade.Data.Migrations
{
    /// <inheritdoc />
    public partial class LinkUsertoProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Profiles");
        }
    }
}
