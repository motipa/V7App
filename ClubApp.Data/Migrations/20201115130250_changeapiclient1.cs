using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubApp.Data.Migrations
{
    public partial class changeapiclient1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApiRefreshToken_UserTenantApplicationRole_UserTenantApplicationRoleId",
                table: "ApiRefreshToken");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserTenantApplicationRoleId",
                table: "ApiRefreshToken",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ApiRefreshToken_UserTenantApplicationRole_UserTenantApplicationRoleId",
                table: "ApiRefreshToken",
                column: "UserTenantApplicationRoleId",
                principalTable: "UserTenantApplicationRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApiRefreshToken_UserTenantApplicationRole_UserTenantApplicationRoleId",
                table: "ApiRefreshToken");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserTenantApplicationRoleId",
                table: "ApiRefreshToken",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApiRefreshToken_UserTenantApplicationRole_UserTenantApplicationRoleId",
                table: "ApiRefreshToken",
                column: "UserTenantApplicationRoleId",
                principalTable: "UserTenantApplicationRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
