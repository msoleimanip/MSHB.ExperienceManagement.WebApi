using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class RolesServiceErrors
    {
        public static readonly ExperienceManagementErrorMessage GetRolesError =
           new ExperienceManagementErrorMessage("GRE-1000", "خطا در دریافت Role");
        public static readonly ExperienceManagementErrorMessage FindUserRolesError =
          new ExperienceManagementErrorMessage("GRE-1001", "خطا در پیدا کردن Role");
        public static readonly ExperienceManagementErrorMessage GetIsUserInRoleError =
          new ExperienceManagementErrorMessage("GRE-1002", "خطا در تشخیص رول مشخصی از کاربر");
        public static readonly ExperienceManagementErrorMessage GetFindUsersInRoleError =
          new ExperienceManagementErrorMessage("GRE-1003", "خطا در پیدا کردن کاربران رول مشخص");

        
            
            

    }
    
}
