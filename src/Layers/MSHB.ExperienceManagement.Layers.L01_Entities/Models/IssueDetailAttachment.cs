using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L01_Entities.Models
{
    [Table("IssueDetailAttachment_T")]
    public class IssueDetailAttachment:BaseEntity
    {
        public long IssueDetailId { get; set; }

        [MaxLength(20)]
        public string FileType { get; set; }
        public long? FileSize { get; set; }
        public long? FilePath { get; set; }
        [ForeignKey("IssueDetailId")]
        public virtual IssueDetail IssueDetails { get; set; }
    }
}
