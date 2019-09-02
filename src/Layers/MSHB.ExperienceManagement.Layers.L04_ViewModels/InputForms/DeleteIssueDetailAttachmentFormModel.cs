using System;
using System.ComponentModel.DataAnnotations;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms
{
    public class DeleteIssueDetailAttachmentFormModel
    {

        [Required(ErrorMessage = "شناسه جزییات مسئله وارد نشده است")]
        public long IssueDetailId { get; set; }

        [Required(ErrorMessage = "شناسه مسئله وارد نشده است")]
        public Guid FileId { get; set; }
    }
}