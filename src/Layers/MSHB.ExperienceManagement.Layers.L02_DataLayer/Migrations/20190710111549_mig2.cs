using Microsoft.EntityFrameworkCore.Migrations;

namespace MSHB.ExperienceManagement.Layers.L02_DataLayer.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "IssueDetail_T",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "IssueDetail_T",
                newName: "Caption");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "IssueDetail_T",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Caption",
                table: "IssueDetail_T",
                newName: "Description");
        }
    }
}
