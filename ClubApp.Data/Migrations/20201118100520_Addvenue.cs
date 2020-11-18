using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubApp.Data.Migrations
{
    public partial class Addvenue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VenueDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    VenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VenueName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    VenueAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VenuePhone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    VenueLocation = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    VenueLongitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VenueLatitude = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VenueDetails");
        }
    }
}
