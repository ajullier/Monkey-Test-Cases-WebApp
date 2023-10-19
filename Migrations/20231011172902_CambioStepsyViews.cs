using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestCases.Migrations
{
    /// <inheritdoc />
    public partial class CambioStepsyViews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "TestCases_Views");

            migrationBuilder.AddColumn<string>(
                name: "Steps",
                table: "TestCases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ViewID",
                table: "TestCases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TestCases_ViewID",
                table: "TestCases",
                column: "ViewID");

            migrationBuilder.AddForeignKey(
                name: "FK_TestCases_Views_ViewID",
                table: "TestCases",
                column: "ViewID",
                principalTable: "Views",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestCases_Views_ViewID",
                table: "TestCases");

            migrationBuilder.DropIndex(
                name: "IX_TestCases_ViewID",
                table: "TestCases");

            migrationBuilder.DropColumn(
                name: "Steps",
                table: "TestCases");

            migrationBuilder.DropColumn(
                name: "ViewID",
                table: "TestCases");

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestCaseID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steps_TestCases_TestCaseID",
                        column: x => x.TestCaseID,
                        principalTable: "TestCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestCases_Views",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ViewID = table.Column<int>(type: "int", nullable: false),
                    TestCaseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCases_Views", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCases_Views_TestCases_TestCaseID",
                        column: x => x.TestCaseID,
                        principalTable: "TestCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestCases_Views_Views_ViewID",
                        column: x => x.ViewID,
                        principalTable: "Views",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Steps_TestCaseID",
                table: "Steps",
                column: "TestCaseID");

            migrationBuilder.CreateIndex(
                name: "IX_TestCases_Views_TestCaseID",
                table: "TestCases_Views",
                column: "TestCaseID");

            migrationBuilder.CreateIndex(
                name: "IX_TestCases_Views_ViewID",
                table: "TestCases_Views",
                column: "ViewID");
        }
    }
}
