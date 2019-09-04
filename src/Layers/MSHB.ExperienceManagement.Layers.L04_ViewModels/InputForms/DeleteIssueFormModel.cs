using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms
{
    public class DeleteIssueFormModel
    {
        public long IssueId { get; set; }
        public Guid UserId { get; set; }
    }
}
