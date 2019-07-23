using Microsoft.EntityFrameworkCore.Migrations;

namespace MSHB.ExperienceManagement.Layers.L02_DataLayer.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IssueDetailLike_T_UserId",
                table: "IssueDetailLike_T");

            migrationBuilder.AddColumn<bool>(
                name: "IsLike",
                table: "IssueDetailLike_T",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<long>(
                name: "Likes",
                table: "IssueDetail_T",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IssueDetailLike_T_UserId_IssueDetailId",
                table: "IssueDetailLike_T",
                columns: new[] { "UserId", "IssueDetailId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IssueDetailLike_T_UserId_IssueDetailId",
                table: "IssueDetailLike_T");

            migrationBuilder.DropColumn(
                name: "IsLike",
                table: "IssueDetailLike_T");

            migrationBuilder.AlterColumn<int>(
                name: "Likes",
                table: "IssueDetail_T",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateIndex(
                name: "IX_IssueDetailLike_T_UserId",
                table: "IssueDetailLike_T",
                column: "UserId");
        }
    }
}
