using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubApp.Data.Migrations
{
    public partial class VenueinBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "TableBookingDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 30, 15, 49, 6, 981, DateTimeKind.Local).AddTicks(3613),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Venue",
                table: "TableBookingDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Venue",
                table: "TableBookingDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "TableBookingDetails",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 11, 30, 15, 49, 6, 981, DateTimeKind.Local).AddTicks(3613));
        }
    }
}
