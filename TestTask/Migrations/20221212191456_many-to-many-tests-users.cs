using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTask.Migrations
{
    public partial class manytomanytestsusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Users_UserId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_UserId",
                table: "Tests");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tests",
                newName: "CreatorId");

            migrationBuilder.CreateTable(
                name: "TestUser",
                columns: table => new
                {
                    TestsIdTest = table.Column<int>(type: "int", nullable: false),
                    UsersIdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestUser", x => new { x.TestsIdTest, x.UsersIdUser });
                    table.ForeignKey(
                        name: "FK_TestUser_Tests_TestsIdTest",
                        column: x => x.TestsIdTest,
                        principalTable: "Tests",
                        principalColumn: "IdTest",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestUser_Users_UsersIdUser",
                        column: x => x.UsersIdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TestUser_UsersIdUser",
                table: "TestUser",
                column: "UsersIdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestUser");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "Tests",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_UserId",
                table: "Tests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Users_UserId",
                table: "Tests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
