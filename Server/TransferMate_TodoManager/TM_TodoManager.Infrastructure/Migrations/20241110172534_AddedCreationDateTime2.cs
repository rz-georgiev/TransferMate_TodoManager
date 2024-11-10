using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TM_TodoManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedCreationDateTime2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDateTime", "DueDate" },
                values: new object[] { new DateTime(2024, 11, 12, 17, 25, 34, 408, DateTimeKind.Utc).AddTicks(7366), new DateTime(2024, 11, 11, 17, 25, 34, 408, DateTimeKind.Utc).AddTicks(7357) });

            migrationBuilder.UpdateData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDateTime", "DueDate" },
                values: new object[] { new DateTime(2024, 11, 13, 17, 25, 34, 408, DateTimeKind.Utc).AddTicks(7368), new DateTime(2024, 11, 12, 17, 25, 34, 408, DateTimeKind.Utc).AddTicks(7368) });

            migrationBuilder.UpdateData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDateTime", "DueDate" },
                values: new object[] { new DateTime(2024, 11, 14, 17, 25, 34, 408, DateTimeKind.Utc).AddTicks(7370), new DateTime(2024, 11, 9, 17, 25, 34, 408, DateTimeKind.Utc).AddTicks(7370) });

            migrationBuilder.UpdateData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDateTime", "DueDate" },
                values: new object[] { new DateTime(2024, 11, 5, 17, 25, 34, 408, DateTimeKind.Utc).AddTicks(7372), new DateTime(2024, 11, 8, 17, 25, 34, 408, DateTimeKind.Utc).AddTicks(7372) });

            migrationBuilder.UpdateData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDateTime", "DueDate" },
                values: new object[] { new DateTime(2024, 11, 4, 17, 25, 34, 408, DateTimeKind.Utc).AddTicks(7374), new DateTime(2024, 11, 7, 17, 25, 34, 408, DateTimeKind.Utc).AddTicks(7373) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
