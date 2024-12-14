using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 13, 23, 20, 36, 885, DateTimeKind.Local).AddTicks(7088),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 11, 22, 43, 1, 39, DateTimeKind.Local).AddTicks(3941));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 11, 22, 43, 1, 39, DateTimeKind.Local).AddTicks(3941),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 13, 23, 20, 36, 885, DateTimeKind.Local).AddTicks(7088));
        }
    }
}
