using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManager.Infrastructure.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Classes_ClassId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ClassId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Classes_ClassId",
                table: "AspNetUsers",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Classes_ClassId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ClassId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Classes_ClassId",
                table: "AspNetUsers",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
