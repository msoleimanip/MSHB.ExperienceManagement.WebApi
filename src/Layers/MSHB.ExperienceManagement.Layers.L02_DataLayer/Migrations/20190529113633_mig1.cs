using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSHB.ExperienceManagement.Layers.L02_DataLayer.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    ParentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_T_City_T_ParentId",
                        column: x => x.ParentId,
                        principalTable: "City_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipment_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EquipmentName = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ParentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_T_Equipment_T_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Equipment_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupAuth_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupAuth_T", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log_T",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    LogLevel = table.Column<string>(nullable: true),
                    Logger = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    StateJson = table.Column<string>(nullable: true),
                    IsSoftDeleted = table.Column<bool>(nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log_T", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organization_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationName = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    ParentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_T_Organization_T_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Organization_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Role_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 450, nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_T", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_T",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(maxLength: 450, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 500, nullable: true),
                    LastName = table.Column<string>(maxLength: 500, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Location = table.Column<string>(maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    LastLockoutDate = table.Column<DateTime>(nullable: true),
                    LastPasswordChangedDate = table.Column<DateTime>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    LastVisit = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    LastLoggedIn = table.Column<DateTimeOffset>(nullable: true),
                    SerialNumber = table.Column<string>(maxLength: 450, nullable: true),
                    SajadUserName = table.Column<string>(maxLength: 200, nullable: true),
                    IsPresident = table.Column<int>(nullable: true),
                    GroupAuthId = table.Column<long>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    UserConfigurationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_T_GroupAuth_T_GroupAuthId",
                        column: x => x.GroupAuthId,
                        principalTable: "GroupAuth_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_T_Organization_T_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupAuthRole_T",
                columns: table => new
                {
                    GroupAuthId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupAuthRole_T", x => new { x.GroupAuthId, x.RoleId });
                    table.UniqueConstraint("AK_GroupAuthRole_T_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupAuthRole_T_GroupAuth_T_GroupAuthId",
                        column: x => x.GroupAuthId,
                        principalTable: "GroupAuth_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupAuthRole_T_Role_T_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentUserSubscription_T",
                columns: table => new
                {
                    EquipmentId = table.Column<long>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentUserSubscription_T", x => new { x.UserId, x.EquipmentId });
                    table.UniqueConstraint("AK_EquipmentUserSubscription_T_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentUserSubscription_T_Equipment_T_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentUserSubscription_T_User_T_UserId",
                        column: x => x.UserId,
                        principalTable: "User_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Issue_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    LastUpdateDate = table.Column<DateTime>(nullable: true),
                    ImageAddress = table.Column<string>(maxLength: 250, nullable: true),
                    AnswerCounts = table.Column<int>(nullable: true),
                    ViewCounts = table.Column<int>(nullable: true),
                    IssueType = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Issue_T_User_T_UserId",
                        column: x => x.UserId,
                        principalTable: "User_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserConfiguration_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    Configuration = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserConfiguration_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserConfiguration_T_User_T_UserId",
                        column: x => x.UserId,
                        principalTable: "User_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole_T",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole_T", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_T_Role_T_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_T_User_T_UserId",
                        column: x => x.UserId,
                        principalTable: "User_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessTokenHash = table.Column<string>(nullable: true),
                    AccessTokenExpiresDateTime = table.Column<DateTimeOffset>(nullable: false),
                    RefreshTokenIdHash = table.Column<string>(maxLength: 450, nullable: false),
                    RefreshTokenIdHashSource = table.Column<string>(maxLength: 450, nullable: true),
                    RefreshTokenExpiresDateTime = table.Column<DateTimeOffset>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToken_T_User_T_UserId",
                        column: x => x.UserId,
                        principalTable: "User_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentIssueSubscription_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EquipmentId = table.Column<long>(nullable: false),
                    IssueId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentIssueSubscription_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentIssueSubscription_T_Equipment_T_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentIssueSubscription_T_Issue_T_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issue_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IssueDetail_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IssueId = table.Column<long>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    AnswerUseful = table.Column<int>(nullable: false),
                    IsCorrectAnswer = table.Column<bool>(nullable: false),
                    Likes = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueDetail_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueDetail_T_Issue_T_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issue_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueDetail_T_User_T_UserId",
                        column: x => x.UserId,
                        principalTable: "User_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserIssueSubscription_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IssueId = table.Column<long>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIssueSubscription_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserIssueSubscription_T_Issue_T_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issue_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserIssueSubscription_T_User_T_UserId",
                        column: x => x.UserId,
                        principalTable: "User_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IssueDetailAttachment_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IssueDetailId = table.Column<long>(nullable: false),
                    FileType = table.Column<string>(maxLength: 20, nullable: true),
                    FileSize = table.Column<long>(nullable: true),
                    FilePath = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueDetailAttachment_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueDetailAttachment_T_IssueDetail_T_IssueDetailId",
                        column: x => x.IssueDetailId,
                        principalTable: "IssueDetail_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IssueDetailComment_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true),
                    IssueDetailId = table.Column<long>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueDetailComment_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueDetailComment_T_IssueDetail_T_IssueDetailId",
                        column: x => x.IssueDetailId,
                        principalTable: "IssueDetail_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueDetailComment_T_User_T_UserId",
                        column: x => x.UserId,
                        principalTable: "User_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_T_ParentId",
                table: "City_T",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_T_ParentId",
                table: "Equipment_T",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentIssueSubscription_T_EquipmentId",
                table: "EquipmentIssueSubscription_T",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentIssueSubscription_T_IssueId",
                table: "EquipmentIssueSubscription_T",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentUserSubscription_T_EquipmentId",
                table: "EquipmentUserSubscription_T",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentUserSubscription_T_UserId",
                table: "EquipmentUserSubscription_T",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupAuthRole_T_RoleId",
                table: "GroupAuthRole_T",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_T_UserId",
                table: "Issue_T",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueDetail_T_IssueId",
                table: "IssueDetail_T",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueDetail_T_UserId",
                table: "IssueDetail_T",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueDetailAttachment_T_IssueDetailId",
                table: "IssueDetailAttachment_T",
                column: "IssueDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueDetailComment_T_IssueDetailId",
                table: "IssueDetailComment_T",
                column: "IssueDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueDetailComment_T_UserId",
                table: "IssueDetailComment_T",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_T_ParentId",
                table: "Organization_T",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_T_Id",
                table: "Role_T",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Role_T_Name",
                table: "Role_T",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_T_GroupAuthId",
                table: "User_T",
                column: "GroupAuthId");

            migrationBuilder.CreateIndex(
                name: "IX_User_T_Id",
                table: "User_T",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_T_OrganizationId",
                table: "User_T",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_User_T_UserConfigurationId",
                table: "User_T",
                column: "UserConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_User_T_Username",
                table: "User_T",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserConfiguration_T_UserId",
                table: "UserConfiguration_T",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIssueSubscription_T_IssueId",
                table: "UserIssueSubscription_T",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIssueSubscription_T_UserId",
                table: "UserIssueSubscription_T",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_T_RoleId",
                table: "UserRole_T",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_T_UserId",
                table: "UserRole_T",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_T_UserId",
                table: "UserToken_T",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City_T");

            migrationBuilder.DropTable(
                name: "EquipmentIssueSubscription_T");

            migrationBuilder.DropTable(
                name: "EquipmentUserSubscription_T");

            migrationBuilder.DropTable(
                name: "GroupAuthRole_T");

            migrationBuilder.DropTable(
                name: "IssueDetailAttachment_T");

            migrationBuilder.DropTable(
                name: "IssueDetailComment_T");

            migrationBuilder.DropTable(
                name: "Log_T");

            migrationBuilder.DropTable(
                name: "UserConfiguration_T");

            migrationBuilder.DropTable(
                name: "UserIssueSubscription_T");

            migrationBuilder.DropTable(
                name: "UserRole_T");

            migrationBuilder.DropTable(
                name: "UserToken_T");

            migrationBuilder.DropTable(
                name: "Equipment_T");

            migrationBuilder.DropTable(
                name: "IssueDetail_T");

            migrationBuilder.DropTable(
                name: "Role_T");

            migrationBuilder.DropTable(
                name: "Issue_T");

            migrationBuilder.DropTable(
                name: "User_T");

            migrationBuilder.DropTable(
                name: "GroupAuth_T");

            migrationBuilder.DropTable(
                name: "Organization_T");
        }
    }
}
