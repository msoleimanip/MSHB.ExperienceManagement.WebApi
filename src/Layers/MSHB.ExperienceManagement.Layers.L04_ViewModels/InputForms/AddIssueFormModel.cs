using MSHB.ExperienceManagement.Layers.L01_Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms
{
    public class AddIssueFormModel
    {
        [Required(ErrorMessage = "باید برای مسئله جدید، عنوان انتخاب کنید")]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required(ErrorMessage = "باید برای توضیحات مسئله جدید، عنوان انتخاب کنید")]
        [MaxLength(250)]
        public string Description { get; set; }              
        public Guid? ImageId { get; set; }
        public int IssueType { get; set; }
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "باید برای توضیحات مسئله جدید، عنوان انتخاب کنید"),MinLength(1)]
        public List<long> EquipmentIds { get; set; }
    }
}
