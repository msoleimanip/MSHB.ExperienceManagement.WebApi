using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels
{
    public class IssueOfUsersViewModel
    {
        public long TotalIssueCount { get; set; }
        public string TotalIssueEquipment { get; set; }
        public long TotalIssueUserDetails { get; set; }
        public string OrganizationName { get; set; }
        public string FullName { get; set; }
    }
}
