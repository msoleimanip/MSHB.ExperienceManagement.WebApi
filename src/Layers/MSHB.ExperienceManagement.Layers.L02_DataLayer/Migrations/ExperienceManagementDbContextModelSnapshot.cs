﻿// <auto-generated />
using System;
using MSHB.ExperienceManagement.Layers.L02_DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MSHB.ExperienceManagement.Layers.L02_DataLayer.Migrations
{
    [DbContext(typeof(ExperienceManagementDbContext))]
    partial class ExperienceManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.AppLogItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedDateTime");

                    b.Property<int>("EventId");

                    b.Property<bool>("IsSoftDeleted");

                    b.Property<string>("LogLevel");

                    b.Property<string>("Logger");

                    b.Property<string>("Message");

                    b.Property<string>("StateJson");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Log_T");
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.City", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<long?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("City_T");
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.Equipment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("EquipmentName")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("LastUpdateDate");

                    b.Property<long?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Equipment_T");
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.EquipmentIssueSubscription", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("EquipmentId");

                    b.Property<long>("IssueId");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("IssueId");

                    b.ToTable("EquipmentIssueSubscription_T");
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.EquipmentUserSubscription", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<long>("EquipmentId");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("UserId", "EquipmentId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("UserId");

                    b.ToTable("EquipmentUserSubscription_T");
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.GroupAuth", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("GroupAuth_T");
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.GroupAuthRole", b =>
                {
                    b.Property<long?>("GroupAuthId");

                    b.Property<long>("RoleId");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("GroupAuthId", "RoleId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("GroupAuthRole_T");
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.Issue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AnswerCounts");

                    b.Property<DateTime?>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description");

                    b.Property<string>("ImageAddress")
                        .HasMaxLength(250);

                    b.Property<int>("IssueType");

                    b.Property<DateTime?>("LastUpdateDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid>("UserId");

                    b.Property<int?>("ViewCounts");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Issue_T");
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.IssueDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnswerUseful");

                    b.Property<DateTime?>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description");

                    b.Property<bool>("IsCorrectAnswer");

                    b.Property<long>("IssueId");

                    b.Property<int?>("Likes");

                    b.Property<string>("Title");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("IssueId");

                    b.HasIndex("UserId");

                    b.ToTable("IssueDetail_T");
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.IssueDetailAttachment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("FilePath");

                    b.Property<long?>("FileSize");

                    b.Property<string>("FileType")
                        .HasMaxLength(20);

                    b.Property<long>("IssueDetailId");

                    b.HasKey("Id");

                    b.HasIndex("IssueDetailId");

                    b.ToTable("IssueDetailAttachment_T");
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.IssueDetailComment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<DateTime?>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<long>("IssueDetailId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("IssueDetailId");

                    b.HasIndex("UserId");

                    b.ToTable("IssueDetailComment_T");
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.Organization", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("LastUpdateDate");

                    b.Property<string>("OrganizationName")
                        .HasMaxLength(100);

                    b.Property<long?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationName");

                    b.HasIndex("ParentId");

                    b.ToTable("Organization_T");
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Role_T");
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreationDate");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("FirstName")
                        .HasMaxLength(500);

                    b.Property<long?>("GroupAuthId");

                    b.Property<bool>("IsActive");

                    b.Property<int?>("IsPresident");

                    b.Property<DateTime?>("LastLockoutDate");

                    b.Property<DateTimeOffset?>("LastLoggedIn");

                    b.Property<string>("LastName")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("LastPasswordChangedDate");

                    b.Property<DateTime?>("LastVisit");

                    b.Property<string>("Location")
                        .HasMaxLength(100);

                    b.Property<long?>("OrganizationId");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20);

                    b.Property<string>("SajadUserName")
                        .HasMaxLength(200);

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(450);

                    b.Property<long?>("UserConfigurationId");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.HasIndex("GroupAuthId");

                    b.HasIndex("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("UserConfigurationId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("User_T");
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.UserConfiguration", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Configuration");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserConfiguration_T");
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.UserIssueSubscription", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<long>("IssueId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("IssueId");

                    b.HasIndex("UserId");

                    b.ToTable("UserIssueSubscription_T");
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.UserRole", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<long>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole_T");
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.UserToken", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("AccessTokenExpiresDateTime");

                    b.Property<string>("AccessTokenHash");

                    b.Property<DateTimeOffset>("RefreshTokenExpiresDateTime");

                    b.Property<string>("RefreshTokenIdHash")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("RefreshTokenIdHashSource")
                        .HasMaxLength(450);

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserToken_T");
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.City", b =>
                {
                    b.HasOne("MSHB.ExperienceManagement.Layers.L01_Entities.Models.City", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.Equipment", b =>
                {
                    b.HasOne("MSHB.ExperienceManagement.Layers.L01_Entities.Models.Equipment", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.EquipmentIssueSubscription", b =>
                {
                    b.HasOne("MSHB.ExperienceManagement.Layers.L01_Entities.Models.Equipment", "Equipment")
                        .WithMany("EquipmentIssueSubscriptions")
                        .HasForeignKey("EquipmentId");

                    b.HasOne("MSHB.ExperienceManagement.Layers.L01_Entities.Models.Issue", "Issue")
                        .WithMany("EquipmentIssueSubscriptions")
                        .HasForeignKey("IssueId");
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.EquipmentUserSubscription", b =>
                {
                    b.HasOne("MSHB.ExperienceManagement.Layers.L01_Entities.Models.Equipment", "Equipment")
                        .WithMany("EquipmentUserSubscriptions")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MSHB.ExperienceManagement.Layers.L01_Entities.Models.User", "User")
                        .WithMany("EquipmentUserSubscriptions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.GroupAuthRole", b =>
                {
                    b.HasOne("MSHB.ExperienceManagement.Layers.L01_Entities.Models.GroupAuth", "GroupAuth")
                        .WithMany("GroupRoles")
                        .HasForeignKey("GroupAuthId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MSHB.ExperienceManagement.Layers.L01_Entities.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.Issue", b =>
                {
                    b.HasOne("MSHB.ExperienceManagement.Layers.L01_Entities.Models.User", "User")
                        .WithMany("Issues")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.IssueDetail", b =>
                {
                    b.HasOne("MSHB.ExperienceManagement.Layers.L01_Entities.Models.Issue", "Issues")
                        .WithMany("IssueDetails")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MSHB.ExperienceManagement.Layers.L01_Entities.Models.User", "User")
                        .WithMany("IssueDetails")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.IssueDetailAttachment", b =>
                {
                    b.HasOne("MSHB.ExperienceManagement.Layers.L01_Entities.Models.IssueDetail", "IssueDetails")
                        .WithMany("IssueDetailAttachments")
                        .HasForeignKey("IssueDetailId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.IssueDetailComment", b =>
                {
                    b.HasOne("MSHB.ExperienceManagement.Layers.L01_Entities.Models.IssueDetail", "IssueDetails")
                        .WithMany("IssueDetailComments")
                        .HasForeignKey("IssueDetailId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MSHB.ExperienceManagement.Layers.L01_Entities.Models.User", "User")
                        .WithMany("IssueDetailComments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.Organization", b =>
                {
                    b.HasOne("MSHB.ExperienceManagement.Layers.L01_Entities.Models.Organization", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.User", b =>
                {
                    b.HasOne("MSHB.ExperienceManagement.Layers.L01_Entities.Models.GroupAuth", "GroupAuth")
                        .WithMany("Users")
                        .HasForeignKey("GroupAuthId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MSHB.ExperienceManagement.Layers.L01_Entities.Models.Organization", "Organization")
                        .WithMany("Users")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.UserConfiguration", b =>
                {
                    b.HasOne("MSHB.ExperienceManagement.Layers.L01_Entities.Models.User", "User")
                        .WithMany("UserConfigurations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.UserIssueSubscription", b =>
                {
                    b.HasOne("MSHB.ExperienceManagement.Layers.L01_Entities.Models.Issue", "Issues")
                        .WithMany()
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MSHB.ExperienceManagement.Layers.L01_Entities.Models.User", "User")
                        .WithMany("UserIssueSubscriptions")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.UserRole", b =>
                {
                    b.HasOne("MSHB.ExperienceManagement.Layers.L01_Entities.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MSHB.ExperienceManagement.Layers.L01_Entities.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MSHB.ExperienceManagement.Layers.L01_Entities.Models.UserToken", b =>
                {
                    b.HasOne("MSHB.ExperienceManagement.Layers.L01_Entities.Models.User", "User")
                        .WithMany("UserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
