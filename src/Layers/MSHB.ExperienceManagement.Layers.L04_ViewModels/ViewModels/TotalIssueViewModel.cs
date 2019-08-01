using MSHB.ExperienceManagement.Layers.L01_Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels
{
    public class TotalIssueViewModel
    {
        public long TotalIssueDetails { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public long LikesCount { get; set; }
        public string CreationTime { get; set; }
        public string IssueType { get; set; }
    }
}
