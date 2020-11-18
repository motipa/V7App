using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubApp.Data.Migrations
{
    public partial class AddBookingTableDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TableBookingDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingDateTimeFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingDateTimeTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfBookedTable = table.Column<int>(type: "int", nullable: false),
                    TableNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableBookingDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableBookingDetails");
        }
    }
}
