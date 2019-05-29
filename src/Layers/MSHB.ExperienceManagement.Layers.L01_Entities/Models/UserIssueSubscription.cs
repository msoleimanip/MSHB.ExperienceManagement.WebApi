using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L01_Entities.Models
{
    [Table("UserIssueSubscription_T")]
    public class UserIssueSubscription:BaseEntity
    {
        public long IssueId { get; set; }
        public DateTime? CreationDate { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("IssueId")]
        public virtual Issue Issues { get; set; }
    }
}
