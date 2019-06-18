using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms
{
    public class UserOrgAssignFormModel
    {
        [Required(ErrorMessage = "باید حتما رده مورد نظر انتخاب شود")]
        public long OrganizationId { get; set; }
        [Required(ErrorMessage = "باید حتما کاربر انتخاب گردد")]
        public Guid UserId { get; set; }
    }
}
