using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms
{
    public class AddOrgFormModel
    {
        
        [Required(ErrorMessage = "باید برای رده جدید، نام انتخاب کنید")]
        public string OrganizationName { get; set; }
        public string Description { get; set; }       
        public long? ParentId { get; set; }
    }
}
