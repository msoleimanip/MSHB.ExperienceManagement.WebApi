using MSHB.ExperienceManagement.Layers.L01_Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L01_Entities.Models
{
    [Table("EquipmentAttachment_T")]
    public class EquipmentAttachment : BaseEntity
    {
        public long EquipmentId { get; set; }
        [DataType(DataType.Text), MaxLength(50)]
        public string EquipmentAttachmentName { get; set; }
        public EquipmentAttachmentType EquipmentAttachmentType { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
        [MaxLength(20)]
        public string FileType { get; set; }
        public long? FileSize { get; set; }
        public Guid? FileId { get; set; }
        [ForeignKey("EquipmentId")]
        public virtual Equipment Equipments { get; set; }

    }
}
