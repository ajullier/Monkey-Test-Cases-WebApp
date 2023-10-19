using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestCases.Migrations
{
    /// <inheritdoc />
    public partial class Migración1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Views",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navigation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Views", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateID = table.Column<int>(type: "int", nullable: false),
                    DataSet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCases_States_StateID",
                        column: x => x.StateID,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestCaseID = table.Column<int>(type: "int", nullable: false)
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
                name: "TestCases_BusinessUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessUnitID = table.Column<int>(type: "int", nullable: false),
                    TestCaseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCases_BusinessUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCases_BusinessUnits_BusinessUnits_BusinessUnitID",
                        column: x => x.BusinessUnitID,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestCases_BusinessUnits_TestCases_TestCaseID",
                        column: x => x.TestCaseID,
                        principalTable: "TestCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestCases_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    TestCaseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCases_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCases_Roles_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestCases_Roles_TestCases_TestCaseID",
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
                name: "IX_TestCases_StateID",
                table: "TestCases",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_TestCases_BusinessUnits_BusinessUnitID",
                table: "TestCases_BusinessUnits",
                column: "BusinessUnitID");

            migrationBuilder.CreateIndex(
                name: "IX_TestCases_BusinessUnits_TestCaseID",
                table: "TestCases_BusinessUnits",
                column: "TestCaseID");

            migrationBuilder.CreateIndex(
                name: "IX_TestCases_Roles_RoleID",
                table: "TestCases_Roles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_TestCases_Roles_TestCaseID",
                table: "TestCases_Roles",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "TestCases_BusinessUnits");

            migrationBuilder.DropTable(
                name: "TestCases_Roles");

            migrationBuilder.DropTable(
                name: "TestCases_Views");

            migrationBuilder.DropTable(
                name: "BusinessUnits");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "TestCases");

            migrationBuilder.DropTable(
                name: "Views");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
