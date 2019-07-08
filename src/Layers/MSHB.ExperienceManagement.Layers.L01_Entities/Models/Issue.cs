using MSHB.ExperienceManagement.Layers.L01_Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L01_Entities.Models
{
    [Table("Issue_T")]
    public class Issue:BaseEntity
    {
            
        [DataType(DataType.Text), MaxLength(100)]
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public Guid? FileId { get; set; }
        public int? AnswerCounts { get; set; } = 0;
        public bool? IsActive { get; set; } = false;       
        public IssueType IssueType { get; set; }
        public Guid UserId { get; set; }      
        public virtual ICollection<EquipmentIssueSubscription> EquipmentIssueSubscriptions { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual ICollection<IssueDetail> IssueDetails { get; set; }

    }
    


}
