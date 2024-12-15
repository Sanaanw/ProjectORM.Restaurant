using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 10, 10, 27, 53, 996, DateTimeKind.Local).AddTicks(533),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 8, 19, 30, 24, 298, DateTimeKind.Local).AddTicks(7177));

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "menuItems",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 8, 19, 30, 24, 298, DateTimeKind.Local).AddTicks(7177),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 10, 10, 27, 53, 996, DateTimeKind.Local).AddTicks(533));

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "menuItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
