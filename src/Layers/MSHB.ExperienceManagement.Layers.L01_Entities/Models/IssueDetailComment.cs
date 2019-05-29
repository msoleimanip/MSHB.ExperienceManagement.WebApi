using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L01_Entities.Models
{
    [Table("IssueDetailComment_T")]
    public class IssueDetailComment:BaseEntity
    {
        public string Comment { get; set; }
        public long IssueDetailId { get; set; }
        public DateTime? CreationDate { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("IssueDetailId")]
        public virtual IssueDetail IssueDetails { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
}
