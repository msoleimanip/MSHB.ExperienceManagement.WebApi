using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms
{
    public class IssueOfUsersFormModel
    {
        public List<Guid> Users { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
