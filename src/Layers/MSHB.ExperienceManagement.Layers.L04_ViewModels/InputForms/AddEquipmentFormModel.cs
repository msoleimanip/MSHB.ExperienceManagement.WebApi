using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms
{
    public class AddEquipmentFormModel
    {
        
        [Required(ErrorMessage = "باید برای تجهیزات جدید، نام انتخاب کنید")]
        public string EquipmentName { get; set; }
        public string Description { get; set; }       
        public long? ParentId { get; set; }
    }
}
