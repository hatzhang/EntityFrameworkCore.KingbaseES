using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KingbaseES.BasicTest.Migrations
{
    /// <inheritdoc />
    public partial class BlogType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogType",
                table: "blogs",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogType",
                table: "blogs");
        }
    }
}
