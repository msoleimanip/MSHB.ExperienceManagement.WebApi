using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L01_Entities.Models
{
    [Table("EquipmentUserSubscription_T")]
    public class EquipmentUserSubscription : BaseEntity
    {
        public long EquipmentId { get; set; }
        public Guid UserId { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual User User { get; set; }
    }
}
