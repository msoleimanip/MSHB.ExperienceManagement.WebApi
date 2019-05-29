using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L01_Entities.Models
{
    [Table("IssueDetail_T")]
    public class IssueDetail:BaseEntity
    {
        public long IssueId { get; set; }  
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
        public int AnswerUseful { get; set; } = 0;
        public bool IsCorrectAnswer { get; set; } 
        public int? Likes { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("IssueId")]
        public virtual Issue Issues { get; set; }
        public virtual ICollection<IssueDetailAttachment> IssueDetailAttachments { get; set; }
        public virtual ICollection<IssueDetailComment> IssueDetailComments { get; set; }



    }
}
