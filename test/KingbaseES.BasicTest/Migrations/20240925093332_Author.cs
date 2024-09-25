using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KingbaseES.BasicTest.Migrations
{
    /// <inheritdoc />
    public partial class Author : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "tests_id_seq2",
                minValue: 1L,
                maxValue: 9223372036854775807L);

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "blogs",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('tests_id_seq2'::regclass)"),
                    name = table.Column<string>(type: "text", nullable: true),
                    BirthTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_blogs_AuthorId",
                table: "blogs",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_Authors_AuthorId",
                table: "blogs",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogs_Authors_AuthorId",
                table: "blogs");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_blogs_AuthorId",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "blogs");

            migrationBuilder.DropSequence(
                name: "tests_id_seq2");
        }
    }
}
