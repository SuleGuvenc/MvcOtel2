using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Otel.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RoomIsActiveAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Hotels_HotelId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_Mail",
                table: "Employee",
                newName: "IX_Employee_Mail");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_HotelId",
                table: "Employee",
                newName: "IX_Employee_HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_Gsm",
                table: "Employee",
                newName: "IX_Employee_Gsm");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 30, 14, 19, 4, 25, DateTimeKind.Local).AddTicks(1146),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 30, 10, 15, 13, 22, DateTimeKind.Local).AddTicks(1402));

            migrationBuilder.AddColumn<bool>(
                name: "IsEmpty",
                table: "Rooms",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 30, 14, 19, 4, 25, DateTimeKind.Local).AddTicks(6072),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 30, 10, 15, 13, 22, DateTimeKind.Local).AddTicks(3621));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 30, 14, 19, 4, 18, DateTimeKind.Local).AddTicks(8443),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 30, 10, 15, 13, 21, DateTimeKind.Local).AddTicks(2121));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Booking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 30, 14, 19, 4, 18, DateTimeKind.Local).AddTicks(2662),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 30, 10, 15, 13, 20, DateTimeKind.Local).AddTicks(8992));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 30, 14, 19, 4, 25, DateTimeKind.Local).AddTicks(4398),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 30, 10, 15, 13, 22, DateTimeKind.Local).AddTicks(2733));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Hotels_HotelId",
                table: "Employee",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Hotels_HotelId",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "IsEmpty",
                table: "Rooms");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_Mail",
                table: "Employees",
                newName: "IX_Employees_Mail");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_HotelId",
                table: "Employees",
                newName: "IX_Employees_HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_Gsm",
                table: "Employees",
                newName: "IX_Employees_Gsm");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 30, 10, 15, 13, 22, DateTimeKind.Local).AddTicks(1402),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 30, 14, 19, 4, 25, DateTimeKind.Local).AddTicks(1146));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 30, 10, 15, 13, 22, DateTimeKind.Local).AddTicks(3621),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 30, 14, 19, 4, 25, DateTimeKind.Local).AddTicks(6072));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 30, 10, 15, 13, 21, DateTimeKind.Local).AddTicks(2121),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 30, 14, 19, 4, 18, DateTimeKind.Local).AddTicks(8443));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Booking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 30, 10, 15, 13, 20, DateTimeKind.Local).AddTicks(8992),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 30, 14, 19, 4, 18, DateTimeKind.Local).AddTicks(2662));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 30, 10, 15, 13, 22, DateTimeKind.Local).AddTicks(2733),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 30, 14, 19, 4, 25, DateTimeKind.Local).AddTicks(4398));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Hotels_HotelId",
                table: "Employees",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
