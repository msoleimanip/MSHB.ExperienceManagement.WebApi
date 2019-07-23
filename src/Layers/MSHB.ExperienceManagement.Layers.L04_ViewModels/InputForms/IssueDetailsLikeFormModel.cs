using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms
{
    public class IssueDetailsLikeFormModel
    {
        [Required(ErrorMessage = "بایستی جزییات مسئله مشخص گردد")]
        public long IssueDetailId { get; set; }

        [Required(ErrorMessage = "بایستی وضعیت  تعیین شود.")]
        public bool IsLike { get; set; }
    }
}
