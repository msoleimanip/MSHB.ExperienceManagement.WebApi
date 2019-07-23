using MSHB.ExperienceManagement.Layers.L01_Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms
{
    public class AddEquipmentAttachmentFormModel
    {
        [Required(ErrorMessage = "باید تجهیز مورد نظر انتخاب شود")]
        public long EquipmentId { get; set; }
        [Required(ErrorMessage = "بایستی نام افزونه مشخص گردد."), MinLength(1)]
        public string EquipmentAttachmentName { get; set; }
        public EquipmentAttachmentType EquipmentAttachmentType { get; set; }
        public string Description { get; set; }
        public Guid? UploadFileId { get; set; }

    }
}
