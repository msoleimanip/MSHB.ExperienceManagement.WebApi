using MSHB.ExperienceManagement.Layers.L01_Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms
{
    public class TotalIssueFormModel
    {
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public IssueType IssueType { get; set; }
    }
}
