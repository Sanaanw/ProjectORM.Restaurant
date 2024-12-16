using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 12, 43, 56, 430, DateTimeKind.Local).AddTicks(8804),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 15, 14, 50, 45, 303, DateTimeKind.Local).AddTicks(930));

            migrationBuilder.CreateIndex(
                name: "IX_menuItems_Name",
                table: "menuItems",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_menuItems_Name",
                table: "menuItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 15, 14, 50, 45, 303, DateTimeKind.Local).AddTicks(930),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 12, 43, 56, 430, DateTimeKind.Local).AddTicks(8804));
        }
    }
}
