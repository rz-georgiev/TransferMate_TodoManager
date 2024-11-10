using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TM_TodoManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedCreationDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "UserTasks",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDateTime", "DueDate" },
                values: new object[] { new DateTime(2024, 11, 8, 17, 23, 10, 332, DateTimeKind.Utc).AddTicks(7356), new DateTime(2024, 11, 11, 17, 23, 10, 332, DateTimeKind.Utc).AddTicks(7347) });

            migrationBuilder.UpdateData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDateTime", "DueDate" },
                values: new object[] { new DateTime(2024, 11, 7, 17, 23, 10, 332, DateTimeKind.Utc).AddTicks(7361), new DateTime(2024, 11, 12, 17, 23, 10, 332, DateTimeKind.Utc).AddTicks(7360) });

            migrationBuilder.UpdateData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDateTime", "DueDate" },
                values: new object[] { new DateTime(2024, 11, 6, 17, 23, 10, 332, DateTimeKind.Utc).AddTicks(7363), new DateTime(2024, 11, 9, 17, 23, 10, 332, DateTimeKind.Utc).AddTicks(7362) });

            migrationBuilder.UpdateData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDateTime", "DueDate" },
                values: new object[] { new DateTime(2024, 11, 15, 17, 23, 10, 332, DateTimeKind.Utc).AddTicks(7366), new DateTime(2024, 11, 8, 17, 23, 10, 332, DateTimeKind.Utc).AddTicks(7365) });

            migrationBuilder.UpdateData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDateTime", "DueDate" },
                values: new object[] { new DateTime(2024, 11, 16, 17, 23, 10, 332, DateTimeKind.Utc).AddTicks(7368), new DateTime(2024, 11, 7, 17, 23, 10, 332, DateTimeKind.Utc).AddTicks(7367) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "UserTasks");

            migrationBuilder.UpdateData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2024, 11, 8, 20, 15, 52, 553, DateTimeKind.Utc).AddTicks(6719));

            migrationBuilder.UpdateData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2024, 11, 9, 20, 15, 52, 553, DateTimeKind.Utc).AddTicks(6732));

            migrationBuilder.UpdateData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2024, 11, 6, 20, 15, 52, 553, DateTimeKind.Utc).AddTicks(6734));

            migrationBuilder.UpdateData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "DueDate",
                value: new DateTime(2024, 11, 5, 20, 15, 52, 553, DateTimeKind.Utc).AddTicks(6735));

            migrationBuilder.UpdateData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "DueDate",
                value: new DateTime(2024, 11, 4, 20, 15, 52, 553, DateTimeKind.Utc).AddTicks(6737));
        }
    }
}
