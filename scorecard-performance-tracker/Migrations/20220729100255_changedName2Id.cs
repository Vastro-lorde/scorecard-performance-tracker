using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scorecard_performance_tracker.Migrations
{
    public partial class changedName2Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DevName",
                table: "Scores",
                newName: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Scores",
                newName: "DevName");
        }
    }
}
