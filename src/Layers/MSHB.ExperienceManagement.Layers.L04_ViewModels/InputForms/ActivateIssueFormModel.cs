using System.ComponentModel.DataAnnotations;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms
{
    public class ActivateIssueFormModel
    {
         [Required(ErrorMessage ="بایستی مسئله مشخص گردد")]
        public long IssueId { get; set; }
        
         [Required(ErrorMessage ="بایستی وضعیت فعال بودن تعیین شود.")]
        public bool IsActive { get; set; }

    }
}