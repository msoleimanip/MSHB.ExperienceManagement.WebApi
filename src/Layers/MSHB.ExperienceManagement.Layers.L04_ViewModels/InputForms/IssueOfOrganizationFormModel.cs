using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms
{
    public class IssueOfOrganizationFormModel
    {
        public List<long> OrgIds { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
