﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms
{
    public class AddIssueDetailFormModel
    {
        [Required(ErrorMessage = "باید مسئله مورد نظر انتخاب شود")]
        public long IssueId { get; set; }
        [Required(ErrorMessage = "بایستی کاربر مورد نظر انتخاب شود")]
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "بایستی برای جزییات مقدار وارد شود"), MinLength(1),MaxLength(250)]
        public string Caption { get; set; }
        public string Text { get; set; }         
        public List<Guid> UploadFiles { get; set; }

    }
}
