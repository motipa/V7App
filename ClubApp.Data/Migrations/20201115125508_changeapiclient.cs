using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubApp.Data.Migrations
{
    public partial class changeapiclient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApiRefreshToken_UserTenantApplicationRole_UserTenantApplicationRoleId",
                table: "ApiRefreshToken");

            migrationBuilder.DropIndex(
                name: "IX_ApiRefreshToken_ApiClientId_UserTenantApplicationRoleId",
                table: "ApiRefreshToken");

            migrationBuilder.CreateIndex(
                name: "IX_ApiRefreshToken_ApiClientId",
                table: "ApiRefreshToken",
                column: "ApiClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApiRefreshToken_UserTenantApplicationRole_UserTenantApplicationRoleId",
                table: "ApiRefreshToken",
                column: "UserTenantApplicationRoleId",
                principalTable: "UserTenantApplicationRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApiRefreshToken_UserTenantApplicationRole_UserTenantApplicationRoleId",
                table: "ApiRefreshToken");

            migrationBuilder.DropIndex(
                name: "IX_ApiRefreshToken_ApiClientId",
                table: "ApiRefreshToken");

            migrationBuilder.CreateIndex(
                name: "IX_ApiRefreshToken_ApiClientId_UserTenantApplicationRoleId",
                table: "ApiRefreshToken",
                columns: new[] { "ApiClientId", "UserTenantApplicationRoleId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApiRefreshToken_UserTenantApplicationRole_UserTenantApplicationRoleId",
                table: "ApiRefreshToken",
                column: "UserTenantApplicationRoleId",
                principalTable: "UserTenantApplicationRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
