using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class GroupServiceErrors
    {
        public static readonly ExperienceManagementErrorMessage GetRolesError =
           new ExperienceManagementErrorMessage("GRE-1000", "خطا در دریافت Role");
    }
}
