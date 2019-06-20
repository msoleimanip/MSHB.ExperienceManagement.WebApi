using System.ComponentModel.DataAnnotations;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms
{
    public class EditIssueDetailFormModel:AddIssueDetailFormModel
    {
        [Required(ErrorMessage = "شناسه جزییات مسئله وارد نشده است")]
        public long IssueDetailId { get; set; }
    }
}