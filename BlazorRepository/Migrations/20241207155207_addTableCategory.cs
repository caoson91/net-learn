using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorRepository.Migrations
{
    /// <inheritdoc />
    public partial class addTableCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Level", "Name", "ParentId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2024, 12, 7, 15, 52, 7, 267, DateTimeKind.Utc).AddTicks(3601), 0, "Food & Beverage", null, null, new DateTime(2024, 12, 7, 15, 52, 7, 267, DateTimeKind.Utc).AddTicks(3602) },
                    { 2, 0, new DateTime(2024, 12, 7, 15, 52, 7, 267, DateTimeKind.Utc).AddTicks(3607), 0, "Agriculture", null, null, new DateTime(2024, 12, 7, 15, 52, 7, 267, DateTimeKind.Utc).AddTicks(3608) },
                    { 3, 0, new DateTime(2024, 12, 7, 15, 52, 7, 267, DateTimeKind.Utc).AddTicks(3609), 0, "Apparel & Accessories", null, null, new DateTime(2024, 12, 7, 15, 52, 7, 267, DateTimeKind.Utc).AddTicks(3609) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
