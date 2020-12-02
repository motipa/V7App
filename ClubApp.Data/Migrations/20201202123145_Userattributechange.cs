using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubApp.Data.Migrations
{
    public partial class Userattributechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActivationCode",
                table: "UserAttribute",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "TableBookingDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 2, 16, 31, 44, 812, DateTimeKind.Local).AddTicks(4817),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 11, 30, 15, 49, 6, 981, DateTimeKind.Local).AddTicks(3613));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivationCode",
                table: "UserAttribute");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "TableBookingDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 30, 15, 49, 6, 981, DateTimeKind.Local).AddTicks(3613),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 2, 16, 31, 44, 812, DateTimeKind.Local).AddTicks(4817));
        }
    }
}
