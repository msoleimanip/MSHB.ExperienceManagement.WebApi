using System.ComponentModel.DataAnnotations;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms
{
    public class DeleteIssueDetailFormModel
    {   

        [Required(ErrorMessage = "شناسه جزییات مسئله وارد نشده است")]
        public long IssueDetailAttachId { get; set; }


    }
}