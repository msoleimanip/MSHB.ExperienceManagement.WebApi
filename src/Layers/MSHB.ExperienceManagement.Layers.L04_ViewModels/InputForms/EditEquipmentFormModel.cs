using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms
{
    public class EditEquipmentFormModel : AddEquipmentFormModel
    {
        [Required(ErrorMessage = "شناسه تجهیزات وارد نشده است")]
        public long EquipmentId { get; set; }
    }
}
