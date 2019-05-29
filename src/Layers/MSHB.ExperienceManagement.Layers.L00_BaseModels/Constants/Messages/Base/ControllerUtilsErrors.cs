using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class ControllerUtilsErrors
    {
        public static readonly ExperienceManagementErrorMessage UserRolesNotFound =
           new ExperienceManagementErrorMessage("URN-1000", "Role کاربر یافت نشده است");
        public static readonly ExperienceManagementErrorMessage GetUserRoles =
          new ExperienceManagementErrorMessage("GUR-1000", "در گرفتن Role کاربر خطایی رخ داده است.");
        public static readonly ExperienceManagementErrorMessage GetUserError =
          new ExperienceManagementErrorMessage("GUE-1000", "در بدست آوردن کاربر خطایی رخ داده است");
        public static readonly ExperienceManagementErrorMessage GetUserPresidentError =
         new ExperienceManagementErrorMessage("GUP-1000", "در بدست آوردن سطح کاربر خطایی رخ داده است");
    }
}
