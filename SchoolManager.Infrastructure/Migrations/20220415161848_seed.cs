using System;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManager.Infrastructure.Migrations
{
    public partial class seed : Migration
    {
        private const string Admin_User_GuidId = "123e6717-4a34-4888-a527-4ee5ff3e8a8d";
        private const string Admin_Role_GuidId = "1698461b-7dae-4030-82e6-5ddac6c480cb";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            var passHash = hasher.HashPassword(null, "admin123");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO AspNetUsers(Id, UserName, NormalizedUserName,Email,EmailConfirmed,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,AccessFailedCount,NormalizedEmail,PasswordHash,SecurityStamp)");
            sb.AppendLine("VALUES(");
            sb.AppendLine($"'{Admin_User_GuidId}'");
            sb.AppendLine(",'admin@admin.bg'");
            sb.AppendLine(",'ADMIN@ADMIN.BG'");
            sb.AppendLine(",'admin@admin.bg'");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(",'ADMIN@ADMIN.BG'");
            sb.AppendLine($", '{passHash}'");
            sb.AppendLine(", ''");
            sb.AppendLine(")");

            migrationBuilder.Sql(sb.ToString());
            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{Admin_Role_GuidId}','Administrator','ADMINISTRATOR')");

            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('{Admin_User_GuidId}','{Admin_Role_GuidId}')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "SalesProducts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.Sql($"DELETE FROM AspNetUserRoles WHERE UserId = '{Admin_User_GuidId}' AND RoleId = '{Admin_Role_GuidId}'");
            migrationBuilder.Sql($"DELETE FROM AspNetUsers WHERE Id = '{Admin_User_GuidId}'");
            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id = '{Admin_Role_GuidId}'");

        }
    }
}
