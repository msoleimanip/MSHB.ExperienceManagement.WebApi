using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels
{
    public class IssueDetailViewModel
    {
        public long IssueDetailId { get; set; }
        public long IssueId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }   
        public string Caption { get; set; }
        public string Text { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }      
        public bool IsCorrectAnswer { get; set; }
        public long Likes { get; set; }
        public List<IssueDetailAttachmentViewModel> IssueDetailAttachments { get; set; }
        public List<IssueDetailCommentViewModel> IssueDetailComments { get; set; }
        public List<EquipmentAttachmentViewModel> EquipmentAttachmentViewModels { get; set; }
    }
    public class IssueDetailAttachmentViewModel
    {
        public long Id { get; set; }
        public long IssueDetailId { get; set; }
        public string FileType { get; set; }
        public long? FileSize { get; set; }
        public string ContentType { get; set; }
        public Guid? FileId { get; set; }
    }
    public class IssueDetailCommentViewModel
    {
        public long Id { get; set; }
        public string Comment { get; set; }
        public long IssueDetailId { get; set; }
        public DateTime? CreationDate { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }

    }

}


