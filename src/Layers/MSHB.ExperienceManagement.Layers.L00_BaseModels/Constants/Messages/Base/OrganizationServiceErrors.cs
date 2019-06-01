using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class OrganizationServiceErrors
    {
        public static readonly ExperienceManagementErrorMessage AddOrganizationError =
          new ExperienceManagementErrorMessage("AOE-1000", "هنگام اضافه کردن رده خطایی رخ داده  است.");
        public static readonly ExperienceManagementErrorMessage EditOrganizationError =
          new ExperienceManagementErrorMessage("AOE-1001", "هنگام تغییر دادن رده خطایی رخ داده  است.");
        public static readonly ExperienceManagementErrorMessage DeleteOrganizationError =
          new ExperienceManagementErrorMessage("AOE-1002", "هنگام حذف رده خطایی رخ داده  است.");

    }
}
