using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSHB.ExperienceManagement.Layers.L02_DataLayer.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentAttachmentIssueDetailSubscription_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EquipmentAttachmentId = table.Column<long>(nullable: false),
                    IssueDetailId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentAttachmentIssueDetailSubscription_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentAttachmentIssueDetailSubscription_T_EquipmentAttachment_T_EquipmentAttachmentId",
                        column: x => x.EquipmentAttachmentId,
                        principalTable: "EquipmentAttachment_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentAttachmentIssueDetailSubscription_T_IssueDetail_T_IssueDetailId",
                        column: x => x.IssueDetailId,
                        principalTable: "IssueDetail_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentAttachmentIssueDetailSubscription_T_EquipmentAttachmentId",
                table: "EquipmentAttachmentIssueDetailSubscription_T",
                column: "EquipmentAttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentAttachmentIssueDetailSubscription_T_IssueDetailId",
                table: "EquipmentAttachmentIssueDetailSubscription_T",
                column: "IssueDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentAttachmentIssueDetailSubscription_T");
        }
    }
}
