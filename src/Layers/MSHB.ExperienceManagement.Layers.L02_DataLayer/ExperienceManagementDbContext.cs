

using Microsoft.EntityFrameworkCore;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;

namespace MSHB.ExperienceManagement.Layers.L02_DataLayer

{
    public class ExperienceManagementDbContext : DbContext
    {
        public ExperienceManagementDbContext()
        {
        }
        public ExperienceManagementDbContext(DbContextOptions options)
: base(options)
        {
        }
        public virtual DbSet<User> Users { set; get; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserToken> UserTokens { get; set; }
        public virtual DbSet<GroupAuth> GroupAuths { get; set; }
        public virtual DbSet<GroupAuthRole> GroupAuthRoles { get; set; }
        public virtual DbSet<AppLogItem> Logs { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<UserConfiguration> UserConfigurations { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<EquipmentAttachment> EquipmentAttachments { get; set; }  
        public virtual DbSet<EquipmentUserSubscription> EquipmentUserSubscriptions { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<IssueDetail> IssueDetails { get; set; }
        public virtual DbSet<IssueDetailComment> IssueDetailComments { get; set; }
        public virtual DbSet<IssueDetailAttachment> IssueDetailAttachments { get; set; }
        public virtual DbSet<UserIssueSubscription> UserIssueSubscriptions { get; set; } /* User Popular user issues */
        public virtual DbSet<FileAddress> FileAddresses { get; set; }
        public virtual DbSet<EquipmentIssueSubscription> EquipmentIssueSubscriptions { get; set; }
        public virtual DbSet<EquipmentAttachmentIssueDetailSubscription> EquipmentAttachmentIssueDetailSubscriptions { get; set; }       
        public virtual DbSet<ReportStructure> ReportStructures { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(
            @"Data Source=.;Initial Catalog=ExperienceManagement;Persist Security Info=True;User ID=sa;Password=Aa123456;");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Username).HasMaxLength(450).IsRequired();
                entity.HasIndex(e => e.Username).IsUnique();
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.SerialNumber).HasMaxLength(450);
                entity.HasIndex(b => b.Username);
                entity.HasIndex(b => b.Id);
                entity.HasIndex(b => b.GroupAuthId);
                entity.HasIndex(b => b.UserConfigurationId);

            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(450).IsRequired();
                entity.HasIndex(e => e.Name).IsUnique();
                entity.HasIndex(b => b.Id);

            });

            modelBuilder.Entity<EquipmentUserSubscription>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.EquipmentId });
                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => e.EquipmentId);
                entity.Property(e => e.UserId);
                entity.Property(e => e.EquipmentId);
                entity.HasOne(d => d.Equipment).WithMany(p => p.EquipmentUserSubscriptions).HasForeignKey(d => d.EquipmentId);
                entity.HasOne(d => d.User).WithMany(p => p.EquipmentUserSubscriptions).HasForeignKey(d => d.UserId);

            });
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => e.RoleId);
                entity.Property(e => e.UserId);
                entity.Property(e => e.RoleId);
                entity.HasOne(d => d.Role).WithMany(p => p.UserRoles).HasForeignKey(d => d.RoleId);
                entity.HasOne(d => d.User).WithMany(p => p.UserRoles).HasForeignKey(d => d.UserId);

            });

            modelBuilder.Entity<UserToken>(entity =>
            {
                entity.HasOne(ut => ut.User)
                      .WithMany(u => u.UserTokens)
                      .HasForeignKey(ut => ut.UserId);
                entity.HasIndex(ut => ut.UserId);
                entity.Property(ut => ut.RefreshTokenIdHash).HasMaxLength(450).IsRequired();
                entity.Property(ut => ut.RefreshTokenIdHashSource).HasMaxLength(450);
            });

           
            modelBuilder.Entity<User>()
                         .HasOne(d => d.GroupAuth)
                         .WithMany(t => t.Users)
                         .HasForeignKey(d => d.GroupAuthId)
                         .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<User>()
                         .HasOne(d => d.Organization)
                         .WithMany(t => t.Users)
                         .HasForeignKey(d => d.OrganizationId)
                         .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<User>()
                  .HasMany(d => d.UserConfigurations).WithOne(d => d.User);


            modelBuilder.Entity<Organization>()                       
                            .HasOne(d => d.Parent)
                            .WithMany(t => t.Children)
                            .HasForeignKey(t => t.ParentId)                            
                            .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Organization>()
                           .HasIndex(d => d.OrganizationName);

            modelBuilder.Entity<IssueDetail>()
                            .HasOne(d => d.User)
                            .WithMany(t => t.IssueDetails)
                            .HasForeignKey(t => t.UserId)
                            .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<UserIssueSubscription>()
                           .HasOne(d => d.User)
                           .WithMany(t => t.UserIssueSubscriptions)
                           .HasForeignKey(t => t.UserId)
                           .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EquipmentIssueSubscription>()
                           .HasOne(d => d.Issue)
                           .WithMany(t => t.EquipmentIssueSubscriptions)
                           .HasForeignKey(t => t.IssueId)
                           .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EquipmentIssueSubscription>()
                           .HasOne(d => d.Equipment)
                           .WithMany(t => t.EquipmentIssueSubscriptions)
                           .HasForeignKey(t => t.EquipmentId)
                           .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EquipmentAttachmentIssueDetailSubscription>()
                           .HasOne(d => d.IssueDetail)
                           .WithMany(t => t.EquipmentAttachmentIssueDetailSubscriptions)
                           .HasForeignKey(t => t.IssueDetailId)
                           .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EquipmentAttachmentIssueDetailSubscription>()
                           .HasOne(d => d.EquipmentAttachment)
                           .WithMany(t => t.EquipmentAttachmentIssueDetailSubscriptions)
                           .HasForeignKey(t => t.EquipmentAttachmentId)
                           .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<IssueDetailComment>()
                           .HasOne(d => d.User)
                           .WithMany(t => t.IssueDetailComments)
                           .HasForeignKey(t => t.UserId)
                           .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<GroupAuthRole>()
                     .HasKey(t => new { t.GroupAuthId, t.RoleId });

            modelBuilder.Entity<GroupAuthRole>()
                     .HasOne(pt => pt.GroupAuth)
                     .WithMany(p => p.GroupRoles)
                     .HasForeignKey(pt => pt.GroupAuthId);

            modelBuilder.Entity<GroupAuthRole>()
                    .HasOne(pt => pt.Role)
                    .WithMany()
                    .HasForeignKey(pt => pt.RoleId);


            modelBuilder.Entity<AppLogItem>()
                    .HasKey(t => new { t.Id });

            modelBuilder.Entity<Issue>()
                    .Property(c => c.CreationDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<IssueDetail>()
                    .Property(c => c.CreationDate).HasDefaultValueSql("getdate()");

            modelBuilder.Entity<UserIssueSubscription>()
                    .Property(c => c.CreationDate).HasDefaultValueSql("getdate()");

            modelBuilder.Entity<IssueDetailComment>()
                    .Property(c => c.CreationDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<EquipmentAttachment>()
                    .Property(c => c.CreationDate).HasDefaultValueSql("getdate()");

            
            modelBuilder.Entity<Organization>()
                    .Property(c => c.CreationDate).HasDefaultValueSql("getdate()");

            modelBuilder.Entity<FileAddress>().HasKey(x => x.FileId);
           modelBuilder.Entity<FileAddress>().Property(x => x.FileId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<FileAddress>().HasIndex(x => x.FileId);


            modelBuilder.Entity<ReportStructure>().HasIndex(x => x.ReportId);
            modelBuilder.Entity<ReportStructure>()
                    .Property(c => c.CreationDate).HasDefaultValueSql("getdate()");



        }

    }


}

