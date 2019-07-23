using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms
{
    public class IssueDetailBestAnswerFormModel
    {
        [Required(ErrorMessage = "بایستی جزییات مسئله مشخص گردد")]
        public long IssueDetailId { get; set; }

        [Required(ErrorMessage = "بایستی وضعیت  تعیین شود.")]
        public bool IsAnswer { get; set; }
    }
}
