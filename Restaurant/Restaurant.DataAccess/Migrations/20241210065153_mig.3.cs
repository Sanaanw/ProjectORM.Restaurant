using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TotalAmount",
                table: "orders",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 10, 10, 51, 52, 522, DateTimeKind.Local).AddTicks(5742),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 10, 10, 27, 53, 996, DateTimeKind.Local).AddTicks(533));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TotalAmount",
                table: "orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 10, 10, 27, 53, 996, DateTimeKind.Local).AddTicks(533),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 10, 10, 51, 52, 522, DateTimeKind.Local).AddTicks(5742));
        }
    }
}
