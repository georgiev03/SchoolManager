using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManager.Infrastructure.Migrations
{
    public partial class PrincipalAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrincipalId",
                table: "Schools",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Principals",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SchoolId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Principals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Principals_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schools_PrincipalId",
                table: "Schools",
                column: "PrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_Principals_SchoolId",
                table: "Principals",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_Principals_PrincipalId",
                table: "Schools",
                column: "PrincipalId",
                principalTable: "Principals",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schools_Principals_PrincipalId",
                table: "Schools");

            migrationBuilder.DropTable(
                name: "Principals");

            migrationBuilder.DropIndex(
                name: "IX_Schools_PrincipalId",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "PrincipalId",
                table: "Schools");
        }
    }
}
