using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestCases.Migrations
{
    /// <inheritdoc />
    public partial class AddIsAutomatedAndCounterActivities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Automated",
                table: "TestCases",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StepsCounter",
                table: "TestCases",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Automated",
                table: "TestCases");

            migrationBuilder.DropColumn(
                name: "StepsCounter",
                table: "TestCases");
        }
    }
}
