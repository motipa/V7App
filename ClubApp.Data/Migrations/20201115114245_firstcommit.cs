using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubApp.Data.Migrations
{
    public partial class firstcommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiClient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Secret = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IsSecured = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    AccessTokenLifeTimeMin = table.Column<int>(type: "int", nullable: false),
                    RefreshTokenLifeTimeMin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiClient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Email = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAttribute",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    FirstName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAttribute_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInvitation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Value = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInvitation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInvitation_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPasswordReset",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    RequestedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPasswordReset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPasswordReset_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTenantApplicationRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTenantApplicationRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTenantApplicationRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApiRefreshToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    IssuedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ApiClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserTenantApplicationRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiRefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiRefreshToken_ApiClient_ApiClientId",
                        column: x => x.ApiClientId,
                        principalTable: "ApiClient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApiRefreshToken_UserTenantApplicationRole_UserTenantApplicationRoleId",
                        column: x => x.UserTenantApplicationRoleId,
                        principalTable: "UserTenantApplicationRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApiClient_Name",
                table: "ApiClient",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiClient_Secret",
                table: "ApiClient",
                column: "Secret",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiRefreshToken_ApiClientId_UserTenantApplicationRoleId",
                table: "ApiRefreshToken",
                columns: new[] { "ApiClientId", "UserTenantApplicationRoleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiRefreshToken_UserTenantApplicationRoleId",
                table: "ApiRefreshToken",
                column: "UserTenantApplicationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiRefreshToken_Value",
                table: "ApiRefreshToken",
                column: "Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAttribute_UserId",
                table: "UserAttribute",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInvitation_UserId",
                table: "UserInvitation",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInvitation_Value",
                table: "UserInvitation",
                column: "Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPasswordReset_UserId",
                table: "UserPasswordReset",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPasswordReset_Value",
                table: "UserPasswordReset",
                column: "Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTenantApplicationRole_UserId_TenantId_ApplicationId",
                table: "UserTenantApplicationRole",
                columns: new[] { "UserId", "TenantId", "ApplicationId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiRefreshToken");

            migrationBuilder.DropTable(
                name: "UserAttribute");

            migrationBuilder.DropTable(
                name: "UserInvitation");

            migrationBuilder.DropTable(
                name: "UserPasswordReset");

            migrationBuilder.DropTable(
                name: "ApiClient");

            migrationBuilder.DropTable(
                name: "UserTenantApplicationRole");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
