using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TM_TodoManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpgradingSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "DueDate", "StatusId" },
                values: new object[] { new DateTime(2024, 11, 5, 20, 15, 52, 553, DateTimeKind.Utc).AddTicks(6735), 2 });

            migrationBuilder.InsertData(
                table: "UserTasks",
                columns: new[] { "Id", "DueDate", "Name", "StatusId" },
                values: new object[] { 5, new DateTime(2024, 11, 4, 20, 15, 52, 553, DateTimeKind.Utc).AddTicks(6737), "Task5", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DueDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DueDate", "StatusId" },
                values: new object[] { null, 3 });
        }
    }
}
