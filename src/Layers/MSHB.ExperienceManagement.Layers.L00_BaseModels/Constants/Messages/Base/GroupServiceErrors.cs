using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class GroupServiceErrors
    {
        public static readonly ExperienceManagementErrorMessage GetRolesError =
           new ExperienceManagementErrorMessage("GRE-1000", "خطا در دریافت Role");
        public static readonly ExperienceManagementErrorMessage AddGroupError =
           new ExperienceManagementErrorMessage("GRE-1001", "مشکل در ساخت گروه جدید");
        public static readonly ExperienceManagementErrorMessage SameGroupExistError =
          new ExperienceManagementErrorMessage("GRE-1002", "گروه با نام مشابه وجود دارد");

        public static readonly ExperienceManagementErrorMessage DeleteGroupError =
          new ExperienceManagementErrorMessage("GRE-1003", "خطا در حذف گروه درخواست شده");
        public static readonly ExperienceManagementErrorMessage EditGroupError =
          new ExperienceManagementErrorMessage("GRE-1004", "خطا در ویرایش گروه درخواست شده");




    }
    
}
