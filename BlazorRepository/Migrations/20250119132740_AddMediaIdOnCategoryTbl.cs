using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorRepository.Migrations
{
    /// <inheritdoc />
    public partial class AddMediaIdOnCategoryTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MediaId",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "MediaId", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 1, 19, 13, 27, 39, 783, DateTimeKind.Utc).AddTicks(169), null, new DateTime(2025, 1, 19, 13, 27, 39, 783, DateTimeKind.Utc).AddTicks(170) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "MediaId", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 1, 19, 13, 27, 39, 783, DateTimeKind.Utc).AddTicks(174), null, new DateTime(2025, 1, 19, 13, 27, 39, 783, DateTimeKind.Utc).AddTicks(174) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "MediaId", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 1, 19, 13, 27, 39, 783, DateTimeKind.Utc).AddTicks(175), null, new DateTime(2025, 1, 19, 13, 27, 39, 783, DateTimeKind.Utc).AddTicks(175) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "Category");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 12, 7, 15, 52, 7, 267, DateTimeKind.Utc).AddTicks(3601), new DateTime(2024, 12, 7, 15, 52, 7, 267, DateTimeKind.Utc).AddTicks(3602) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 12, 7, 15, 52, 7, 267, DateTimeKind.Utc).AddTicks(3607), new DateTime(2024, 12, 7, 15, 52, 7, 267, DateTimeKind.Utc).AddTicks(3608) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 12, 7, 15, 52, 7, 267, DateTimeKind.Utc).AddTicks(3609), new DateTime(2024, 12, 7, 15, 52, 7, 267, DateTimeKind.Utc).AddTicks(3609) });
        }
    }
}
