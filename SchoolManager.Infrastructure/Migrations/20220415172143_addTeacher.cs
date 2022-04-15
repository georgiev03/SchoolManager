using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManager.Infrastructure.Migrations
{
    public partial class addTeacher : Migration
    {
        private const string Teacher_User_GuidId = "21c77fa5-9200-4867-b966-b843a6d41abb";
        private const string Teacher_Role_GuidId = "e08bfa41-332e-4b3c-96ec-19dc3c64f53e";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            var passHash = hasher.HashPassword(null, "teacher123");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO AspNetUsers(Id, UserName, NormalizedUserName,Email,EmailConfirmed,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,AccessFailedCount,NormalizedEmail,PasswordHash,SecurityStamp)");
            sb.AppendLine("VALUES(");
            sb.AppendLine($"'{Teacher_User_GuidId}'");
            sb.AppendLine(",'teacher@teacher.bg'");
            sb.AppendLine(",'TEACHER@TEACHER.BG'");
            sb.AppendLine(",'teacher@teacher.bg'");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(",'TEACHER@TEACHER.BG'");
            sb.AppendLine($", '{passHash}'");
            sb.AppendLine(", ''");
            sb.AppendLine(")");

            migrationBuilder.Sql(sb.ToString());
            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{Teacher_Role_GuidId}','Teacher','TEACHER')");

            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('{Teacher_User_GuidId}','{Teacher_Role_GuidId}')");

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

            migrationBuilder.Sql($"DELETE FROM AspNetUserRoles WHERE UserId = '{Teacher_User_GuidId}' AND RoleId = '{Teacher_Role_GuidId}'");
            migrationBuilder.Sql($"DELETE FROM AspNetUsers WHERE Id = '{Teacher_User_GuidId}'");
            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id = '{Teacher_Role_GuidId}'");
        }
    }
}
