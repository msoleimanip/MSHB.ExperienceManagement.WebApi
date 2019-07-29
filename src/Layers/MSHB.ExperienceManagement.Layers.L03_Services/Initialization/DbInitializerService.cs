using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System.Transactions;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L02_DataLayer;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Layers.L01_Entities.Enums;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Initialization
{
    public interface IDbInitializerService
    {
        /// <summary>
        /// Applies any pending migrations for the context to the database.
        /// Will create the database if it does not already exist.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Adds some default values to the Db
        /// </summary>
        void SeedData();
    }

    public class DbInitializerService : IDbInitializerService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ISecurityService _securityService;
        private readonly ExperienceManagementDbContext _context;

        public DbInitializerService(
            IServiceScopeFactory scopeFactory,
            ISecurityService securityService, ExperienceManagementDbContext context)
        {
            _scopeFactory = scopeFactory;
            _scopeFactory.CheckArgumentIsNull(nameof(_scopeFactory));

            _securityService = securityService;
            _securityService.CheckArgumentIsNull(nameof(_securityService));
            _context = context;
            _context.CheckArgumentIsNull(nameof(_context));
        }

        public void Initialize()
        {

            _context.Database.Migrate();
        }

        public void SeedData()
        {





            // Add default roles
            var adminRole = CustomRoles.GetInitialRoles();

            if (!_context.Roles.Any())
            {
                _context.AddRange(adminRole);

                _context.SaveChanges();
            }

            // Add Admin user
            if (!_context.Users.Any())
            {
                var groupAuth = new GroupAuth()
                {
                    Name = "Administrator",
                    Description = "Administrator"
                };

                var org = new Organization()
                {
                    CreationDate = DateTime.Now,
                    OrganizationName = "کل رده ها",
                    Description = "",
                };
                var equipment = new Equipment()
                {
                    LastUpdateDate = DateTime.Now,
                    EquipmentName = "کل تجهیزات",
                    Description = "",
                };
                var adminUser = new User
                {
                    Username = "admin",
                    FirstName = "مدیر",
                    LastName = "سیستم",
                    IsActive = true,
                    IsPresident = PresidentType.Admin,
                    LastLoggedIn = null,
                    Password = _securityService.GetSha256Hash("1234"),
                    SerialNumber = Guid.NewGuid().ToString("N"),
                    GroupAuth = groupAuth,
                    Organization = org
                };

                _context.GroupAuths.Add(groupAuth);
                _context.Users.Add(adminUser);
                _context.Organizations.Add(org);
                _context.Equipments.Add(equipment);

                foreach (var role in _context.Roles.ToList())
                {
                    _context.Add(new UserRole { Role = role, User = adminUser });
                    if (groupAuth != null)
                    {
                        _context.GroupAuthRoles.Add(new GroupAuthRole { GroupAuthId = groupAuth.Id, RoleId = role.Id });
                    }
                }

                _context.SaveChanges();



            }

            if (!_context.ReportStructures.Any())
            {
                ReportStructure report_IssueOfUsers = new ReportStructure()
                {
                    ReportId = "IssueOfUsers",
                    Configuration = "",
                    LastUpdatedDateTime = DateTime.Now,
                    CreationDate = DateTime.Now,
                    ProtoType = string.Empty
                };

                ReportStructure report_IssueOfEquipments = new ReportStructure()
                {
                    ReportId = "IssueOfEquipments",
                    Configuration = "",
                    LastUpdatedDateTime = DateTime.Now,
                    CreationDate = DateTime.Now,
                    ProtoType = string.Empty
                };

                ReportStructure report_IssueOfUserLikes = new ReportStructure()
                {
                    ReportId = "IssueOfUserLikes",
                    Configuration = "",
                    LastUpdatedDateTime = DateTime.Now,
                    CreationDate = DateTime.Now,
                    ProtoType = string.Empty
                };

                ReportStructure report_TotalIssue = new ReportStructure()
                {
                    ReportId = "TotalIssue",
                    Configuration = "",
                    LastUpdatedDateTime = DateTime.Now,
                    CreationDate = DateTime.Now,
                    ProtoType = string.Empty
                };

                ReportStructure report_IssuesOfOrganization = new ReportStructure()
                {
                    ReportId = "IssuesOfOrganization",
                    Configuration = "",
                    LastUpdatedDateTime = DateTime.Now,
                    CreationDate = DateTime.Now,
                    ProtoType = string.Empty
                };


                ReportStructure report_UsersActivation = new ReportStructure()
                {
                    ReportId = "UsersActivation",
                    Configuration = "",
                    LastUpdatedDateTime = DateTime.Now,
                    CreationDate = DateTime.Now,
                    ProtoType = string.Empty
                };


                _context.Add(report_IssueOfUsers);
                _context.Add(report_IssueOfEquipments);
                _context.Add(report_IssueOfUserLikes);
                _context.Add(report_TotalIssue);
                _context.Add(report_IssuesOfOrganization);
                _context.Add(report_UsersActivation);

                _context.SaveChanges();
            }

        }
    }
}