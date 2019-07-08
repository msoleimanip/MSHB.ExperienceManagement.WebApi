using MSHB.ExperienceManagement.Layers.L01_Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels
{
    public class IssueViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }     
        public Guid?  FileId { get; set; }
        public int? AnswerCounts { get; set; } = 0;
        public bool? IsActive { get; set; } = false;
        public IssueType IssueType { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public List<long> EquipmentIds { get; set; }
    }
}
