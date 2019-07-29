using System;
using System.Collections.Generic;
using System.Linq;

using MSHB.ExperienceManagement.Layers.L01_Entities.Models;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Initialization
{ 
    public static class CustomRoles
    {
        public static List<Role> GetInitialRoles()
        {
            var initRoles = new List<Role>();
            initRoles.AddRange(DefineInitRole());


            return initRoles;
        }

        private static List<Role> DefineInitRole()
        {
            var initRoles = new List<Role>
            {
                DefineIntRole("File", "File"),
                DefineIntRole("File-UploadFile", "File-UploadFile"),
                DefineIntRole("File-DownloadFile", "File-DownloadFile"),           

                DefineIntRole("GroupAuthentication", "GroupAuthentication"),
                DefineIntRole("GroupAuthentication-GetGroupAuthentication", "GroupAuthentication-GetGroupAuthentication"),
                DefineIntRole("GroupAuthentication-GetGroupRole", "GroupAuthentication-GetGroupRole"),
                DefineIntRole("GroupAuthentication-AddGroup", "GroupAuthentication-AddGroup"),
                DefineIntRole("GroupAuthentication-EditGroup", "GroupAuthentication-EditGroup"),
                DefineIntRole("GroupAuthentication-DeleteGroup", "GroupAuthentication-DeleteGroup"),
                DefineIntRole("GroupAuthentication-GetRoles", "GroupAuthentication-GetRoles"),
                DefineIntRole("GroupAuthentication-GetGroupAuthenticationById", "GroupAuthentication-GetGroupAuthenticationById"),

                DefineIntRole("Organization", "Organization"),
                DefineIntRole("Organization-Get", "Organization-Get"),
                DefineIntRole("Organization-GetOrganizationByUser", "Organization-GetOrganizationByUser"),
                DefineIntRole("Organization-GetUserOrganizationForUser", "Organization-GetUserOrganizationForUser"),
                DefineIntRole("Organization-AddOrganization", "Organization-AddOrganization"),
                DefineIntRole("Organization-EditOrganization", "Organization-EditOrganization"),               
                DefineIntRole("Organization-DeleteOrganization", "Organization-DeleteOrganization"),

                DefineIntRole("Equipment", "Equipment"),
                DefineIntRole("Equipment-Get", "Equipment-Get"),
                DefineIntRole("Equipment-GetEquipmentByUser", "Equipment-GetEquipmentByUser"),
                DefineIntRole("Equipment-GetUserEquipmentForUser", "Equipment-GetUserEquipmentForUser"),
                DefineIntRole("Equipment-AddEquipment", "Equipment-AddEquipment"),
                DefineIntRole("Equipment-EditEquipment", "Equipment-EditEquipment"),
                DefineIntRole("Equipment-DeleteEquipment", "Equipment-DeleteEquipment"),
                DefineIntRole("Equipment-AddEquipmentAttachment", "Equipment-AddEquipmentAttachment"),
                DefineIntRole("Equipment-EditEquipmentAttachment", "Equipment-EditEquipmentAttachment"),
                DefineIntRole("Equipment-GetEquipmentAttachment", "Equipment-GetEquipmentAttachment"),
                DefineIntRole("Equipment-GetEquipmentAttachmentForUser", "Equipment-GetEquipmentAttachmentForUser"),
                DefineIntRole("Equipment-GetEquipmentAttachmentByEquipmentId", "Equipment-GetEquipmentAttachmentByEquipmentId"),

                DefineIntRole("Account", "Account"),
                DefineIntRole("Account-RefreshToken", "Account-RefreshToken"),
                DefineIntRole("Account-AddUser", "Account-AddUser"),
                DefineIntRole("Account-EditUser", "Account-EditUser"),
                DefineIntRole("Account-ChangeActivateUser", "Account-ChangeActivateUser"),
                DefineIntRole("Account-ChangePassword", "Account-ChangePassword"),
                DefineIntRole("Account-GetUsers", "Account-GetUsers"),
                DefineIntRole("Account-UserCityAssign", "Account-UserCityAssign"),
                DefineIntRole("Account-GetUserById", "Account-GetUserById"),
                DefineIntRole("Account-GetOrganizationUsers", "Account-GetOrganizationUsers"),
                DefineIntRole("Account-UserOrganizationAssign", "Account-UserOrganizationAssign"),
                DefineIntRole("Account-UserEquipmentAssign", "Account-UserEquipmentAssign"),
                
                

                 DefineIntRole("Issue", "Issue"),

                DefineIntRole("Report", "Report"),
                DefineIntRole("Report-GetReportStructure", "Report-GetReportStructure"),
                DefineIntRole("Report-AddOrUpdateReportStructure", "Report-AddOrUpdateReportStructure"),
                DefineIntRole("Report-IssueOfUsersReport", "Report-IssueOfUsersReport"),
                DefineIntRole("Report-IssueOfEquipmentsReport", "Report-IssueOfEquipmentsReport"),
                DefineIntRole("Report-IssueOfUserLikesReport", "Report-IssueOfUserLikesReport"),
                DefineIntRole("Report-IssuesOfOrganizationReport", "Report-IssuesOfOrganizationReport"),
                DefineIntRole("Report-UsersActivationReport", "Report-UsersActivationReport"),
                DefineIntRole("Report-TotalIssueReport", "Report-TotalIssueReport"),               

                DefineIntRole("Dashboard", "Dashboard"),
                

            };

            return initRoles;

        }
        private static Role DefineIntRole(string name, string title)
        {
            var role = new Role()
            {
                Name = name,
                Title = title,
                Discriminator = "Role"
            };

            return role;

        }
    }
}
