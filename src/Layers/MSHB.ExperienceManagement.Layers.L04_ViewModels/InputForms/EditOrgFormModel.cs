using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms
{
    public class EditOrgFormModel : AddOrgFormModel
    {
        [Required(ErrorMessage = "شناسه رده وارد نشده است")]
        public long OrganizationId { get; set; }
    }
}
