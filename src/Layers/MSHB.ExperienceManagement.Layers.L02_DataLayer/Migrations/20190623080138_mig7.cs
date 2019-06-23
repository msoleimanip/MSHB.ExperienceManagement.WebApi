using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSHB.ExperienceManagement.Layers.L02_DataLayer.Migrations
{
    public partial class mig7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCounts",
                table: "Issue_T");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "IssueDetail_T",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "IssueDetail_T");

            migrationBuilder.AddColumn<int>(
                name: "ViewCounts",
                table: "Issue_T",
                nullable: true);
        }
    }
}
