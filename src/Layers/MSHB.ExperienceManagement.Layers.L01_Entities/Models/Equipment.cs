using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L01_Entities.Models
{
   
    [Table("Equipment_T")]
    public class Equipment : BaseEntity
    {
        [DataType(DataType.Text), MaxLength(100)]
        public string EquipmentName { get; set; }

        public string Description { get; set; }

        public long? ParentId { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [ForeignKey("ParentId")]
        public virtual Equipment Parent { get; set; }

        public virtual ICollection<Equipment> Children { get; set; }

        public virtual ICollection<EquipmentUserSubscription> EquipmentUserSubscriptions { get; set; }

        public virtual ICollection<EquipmentIssueSubscription> EquipmentIssueSubscriptions { get; set; }



    }
}
