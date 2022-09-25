using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Urls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FullUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfCreate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urls", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Urls",
                columns: new[] { "Id", "Code", "Count", "DateOfCreate", "FullUrl", "ShortUrl" },
                values: new object[] { new Guid("0d2d5454-c5d5-4ebe-8c35-e620df7cbb88"), "cautct", 1, new DateTime(2022, 9, 26, 1, 16, 25, 933, DateTimeKind.Local).AddTicks(5951), "https://github.com/shikayo", "localhost:45367/cautct" });

            migrationBuilder.InsertData(
                table: "Urls",
                columns: new[] { "Id", "Code", "Count", "DateOfCreate", "FullUrl", "ShortUrl" },
                values: new object[] { new Guid("c1d3d8b4-e24c-4310-ba6f-e4d9054db15b"), "8mbCpl", 0, new DateTime(2022, 9, 26, 1, 16, 25, 933, DateTimeKind.Local).AddTicks(5961), "https://www.google.ru", "localhost:45367/8mbCpl" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Urls");
        }
    }
}
