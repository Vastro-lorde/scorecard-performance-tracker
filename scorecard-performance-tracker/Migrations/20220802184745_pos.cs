using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scorecard_performance_tracker.Migrations
{
    public partial class pos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    DevSquad = table.Column<string>(type: "text", nullable: false),
                    AgileScore = table.Column<double>(type: "double precision", nullable: false),
                    AlgorithmScore = table.Column<double>(type: "double precision", nullable: false),
                    AssesmentScore = table.Column<double>(type: "double precision", nullable: false),
                    WeeklyTaskScore = table.Column<double>(type: "double precision", nullable: false),
                    CumulativeScore = table.Column<double>(type: "double precision", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
