using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSHB.ExperienceManagement.Layers.L02_DataLayer.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerUseful",
                table: "IssueDetail_T");

            migrationBuilder.CreateTable(
                name: "IssueDetailLike_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IssueDetailId = table.Column<long>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueDetailLike_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueDetailLike_T_IssueDetail_T_IssueDetailId",
                        column: x => x.IssueDetailId,
                        principalTable: "IssueDetail_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssueDetailLike_T_User_T_UserId",
                        column: x => x.UserId,
                        principalTable: "User_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentAttachment_T_EquipmentId_EquipmentAttachmentName_EquipmentAttachmentType",
                table: "EquipmentAttachment_T",
                columns: new[] { "EquipmentId", "EquipmentAttachmentName", "EquipmentAttachmentType" });

            migrationBuilder.CreateIndex(
                name: "IX_IssueDetailLike_T_IssueDetailId",
                table: "IssueDetailLike_T",
                column: "IssueDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueDetailLike_T_UserId",
                table: "IssueDetailLike_T",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueDetailLike_T");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentAttachment_T_EquipmentId_EquipmentAttachmentName_EquipmentAttachmentType",
                table: "EquipmentAttachment_T");

            migrationBuilder.AddColumn<int>(
                name: "AnswerUseful",
                table: "IssueDetail_T",
                nullable: false,
                defaultValue: 0);
        }
    }
}
