using MSHB.ExperienceManagement.Layers.L01_Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels
{
    public class EquipmentAttachmentViewModel
    {
        public long EquipmentAttachmentId { get; set; }
        public long EquipmentId { get; set; }      
        public string EquipmentAttachmentName { get; set; }
        public EquipmentAttachmentType EquipmentAttachmentType { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }    
        public string FileType { get; set; }
        public long? FileSize { get; set; }
        public Guid? FileId { get; set; }
    }
}
