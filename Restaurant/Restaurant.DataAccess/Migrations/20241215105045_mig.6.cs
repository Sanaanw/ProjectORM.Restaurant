using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 15, 14, 50, 45, 303, DateTimeKind.Local).AddTicks(930),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 13, 23, 20, 36, 885, DateTimeKind.Local).AddTicks(7088));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2024, 12, 15, 14, 50, 45, 303, DateTimeKind.Local).AddTicks(930));
        }
    }
}
