using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L01_Entities.Models
{
    [Table("EquipmentAttachmentIssueDetailSubscription_T")]
    public class EquipmentAttachmentIssueDetailSubscription:BaseEntity
    {
        public long EquipmentAttachmentId { get; set; }
        public long IssueDetailId { get; set; }
        public virtual EquipmentAttachment EquipmentAttachment { get; set; }
        public virtual IssueDetail IssueDetail { get; set; }
    }
}
