using MSHB.ExperienceManagement.Layers.L01_Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels
{
    public class IssueOfUserLikesViewModel
    {
        public long TotalIssueCount { get; set; }
        public long TotalUserDetails { get; set; }
        public long TotalUserLikes { get; set; }
        public string IssueType { get; set; }
        public string UserName { set; get; }

    }
}
