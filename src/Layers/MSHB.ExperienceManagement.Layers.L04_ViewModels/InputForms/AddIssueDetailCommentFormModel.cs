using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms
{
    public class AddIssueDetailCommentFormModel
    {
        [Required(ErrorMessage = "بایستی متن پیام مشخص گردد."), MinLength(1)]
        public string Comment { get; set; }
        [Required(ErrorMessage = "بایستی حتما شناسه بخش جزییات مسئله ارائه گردد.")]
        public long IssueDetailId { get; set; }      
   
    }
}
