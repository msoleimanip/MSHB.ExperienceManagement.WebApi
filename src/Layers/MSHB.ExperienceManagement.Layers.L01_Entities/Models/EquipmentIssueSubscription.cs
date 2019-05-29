using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L01_Entities.Models
{

    [Table("EquipmentIssueSubscription_T")]
    public class EquipmentIssueSubscription:BaseEntity
    {
        public long EquipmentId { get; set; }
        public long IssueId { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual Issue Issue { get; set; }
    }
}
