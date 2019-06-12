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
        public static readonly ExperienceManagementErrorMessage EditDuplicateGroupError =
          new ExperienceManagementErrorMessage("GRE-1005", "امکان تغییر به Group با نام تکراری مهیا نیست.");
        public static readonly ExperienceManagementErrorMessage UserInGroupExistError =
          new ExperienceManagementErrorMessage("GRE-1006", "گروه انتخابی دارای کاربر می باشد ابتدا آن کاربر را به گروه دیگر تخصیص دهید.");
        public static readonly ExperienceManagementErrorMessage DeleteGroupNotselectedError =
          new ExperienceManagementErrorMessage("GRE-1007", "درخواست شما منجر به حذف Group می شود که در لیست انتخابی نیست.");
        public static readonly ExperienceManagementErrorMessage GetGroupError =
          new ExperienceManagementErrorMessage("GRE-1008", "در گرفتن Group مورد نظر خطایی رخ داده است.");
        public static readonly ExperienceManagementErrorMessage RoleExistError =
          new ExperienceManagementErrorMessage("GRE-1009", "بخشی یا کل رول ها در لیست انتخابی وجود ندارد");
        public static readonly ExperienceManagementErrorMessage EditGroupNotExistError =
          new ExperienceManagementErrorMessage("GRE-1010", "گروهی که می خواهید  تغییر دهید وجود ندارد");
     

    }
    
}
