using MSHB.ExperienceManagement.Layers.L00_BaseModels.Search;
using MSHB.ExperienceManagement.Layers.L01_Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms
{
    public class SearchIssueFormModel:SearchModel
    {        
        public string Title { get; set; }
        public bool? IsActive { get; set; }
        public IssueType? IssueType { get; set; }
        [Required(ErrorMessage = "بایستی کاربر مشخص گردد.")]      
        public Guid? UserId { get; set; }
        public List<long> EquipmentIds { get; set; }
    }
}
