using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scorecard_performance_tracker.Migrations
{
    public partial class performancetracker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DevName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DevSquad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgileScore = table.Column<short>(type: "smallint", nullable: false),
                    AlgorithmScore = table.Column<short>(type: "smallint", nullable: false),
                    AssesmentScore = table.Column<short>(type: "smallint", nullable: false),
                    WeeklyTaskScore = table.Column<short>(type: "smallint", nullable: false),
                    CumulativeScore = table.Column<short>(type: "smallint", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scores");
        }
    }
}
