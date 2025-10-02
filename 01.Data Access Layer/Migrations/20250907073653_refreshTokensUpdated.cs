using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_Book_Circle.Migrations
{
    /// <inheritdoc />
    public partial class refreshTokensUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "RefreshToken",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "RefreshToken");
        }
    }
}
