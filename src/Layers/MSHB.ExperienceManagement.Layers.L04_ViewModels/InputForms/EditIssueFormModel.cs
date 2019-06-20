using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms
{
    public class EditIssueFormModel:AddIssueFormModel
    {
        [Required(ErrorMessage ="بایستی مسئله مشخص گردد")]
        public long IssueId { get; set; }
    }
}
