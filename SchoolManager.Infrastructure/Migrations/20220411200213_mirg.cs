using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManager.Infrastructure.Migrations
{
    public partial class mirg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Principals_Schools_SchoolId",
                table: "Principals");

            migrationBuilder.AlterColumn<string>(
                name: "PrincipalId",
                table: "Schools",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(36)",
                oldMaxLength: 36,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SchoolId",
                table: "Principals",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Principals_Schools_SchoolId",
                table: "Principals",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Principals_Schools_SchoolId",
                table: "Principals");

            migrationBuilder.AlterColumn<string>(
                name: "PrincipalId",
                table: "Schools",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SchoolId",
                table: "Principals",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Principals_Schools_SchoolId",
                table: "Principals",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
