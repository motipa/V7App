using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubApp.Data.Migrations
{
    public partial class bookingTChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TableBookingDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "TableBookingDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 26, 11, 3, 10, 16, DateTimeKind.Local).AddTicks(4526));
        }
    }
}
