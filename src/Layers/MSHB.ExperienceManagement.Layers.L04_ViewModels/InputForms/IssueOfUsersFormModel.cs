using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms
{
    public class IssueOfUsersFormModel
    {
        //[Required(ErrorMessage = "بایستی حداقل یک کاربر انتخاب شود"), MinLength(1)]
        public List<Guid> Users { get; set; }
    }
}
