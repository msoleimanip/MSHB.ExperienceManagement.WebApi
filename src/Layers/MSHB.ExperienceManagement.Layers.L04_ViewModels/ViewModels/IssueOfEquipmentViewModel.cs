using MSHB.ExperienceManagement.Layers.L01_Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels
{
    public class IssueOfEquipmentViewModel
    {
        public long TotalIssueCount { get; set; }
        public long TotalIssueDetails { get; set; }
        public long TotalUserDetails { get; set; }
        public string EquipmentName { get; set; }
        public string IssueType { get; set; }
    }
}
