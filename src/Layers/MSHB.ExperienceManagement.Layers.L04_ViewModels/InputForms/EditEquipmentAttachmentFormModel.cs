using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms
{
    public class EditEquipmentAttachmentFormModel: AddEquipmentAttachmentFormModel
    {
        [Required(ErrorMessage = "شناسه افزونه وارد نشده است")]
        public long EquipmentAttachmentId { get; set; }
    }
}
