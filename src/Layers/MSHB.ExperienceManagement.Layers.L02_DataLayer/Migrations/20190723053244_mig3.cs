using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSHB.ExperienceManagement.Layers.L02_DataLayer.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentAttachment_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EquipmentId = table.Column<long>(nullable: false),
                    EquipmentAttachmentName = table.Column<string>(maxLength: 50, nullable: true),
                    EquipmentAttachmentType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    FileType = table.Column<string>(maxLength: 20, nullable: true),
                    FileSize = table.Column<long>(nullable: true),
                    FileId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentAttachment_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentAttachment_T_Equipment_T_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentAttachment_T_EquipmentId",
                table: "EquipmentAttachment_T",
                column: "EquipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentAttachment_T");
        }
    }
}
