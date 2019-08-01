using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L01_Entities.Enums
{
    public enum IssueType
    {
        [Display(Name = "طرح سوال")]
        Question=1,
        [Display(Name = "کمک رسانی")]
        Help,
        [Display(Name = "نگهداری")]
        Maintanence,
        [Display(Name = "سـایر موارد")]
        Other
    }
}
