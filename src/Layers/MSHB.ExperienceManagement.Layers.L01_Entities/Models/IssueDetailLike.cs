using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L01_Entities.Models
{
    [Table("IssueDetailLike_T")]
    public class IssueDetailLike:BaseEntity
    {
        public long IssueDetailId { get; set; }
        public bool IsLike { get; set; }
        public virtual IssueDetail IssueDetail { get; set; }
        public Guid UserId { get; set; }            
        public virtual User User { get; set; }
    }
}
