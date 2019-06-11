using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class GroupRepositoryErrors
    {
        public static readonly ExperienceManagementErrorMessage DbAddGroupError =
          new ExperienceManagementErrorMessage("DAGE-1000", "هنگام اضافه کردن Group خطایی رخ داده  است.");
        public static readonly ExperienceManagementErrorMessage DbEditGroupError =
          new ExperienceManagementErrorMessage("DAGE-1001", "هنگام تغییر دادن Group خطایی رخ داده  است.");
        public static readonly ExperienceManagementErrorMessage DbDeleteGroupError =
          new ExperienceManagementErrorMessage("DAGE-1002", "هنگام حذف Group خطایی رخ داده  است.");

        public static readonly ExperienceManagementErrorMessage DbEditDuplicateGroupError =
          new ExperienceManagementErrorMessage("DAGE-1003", "امکان تغییر به Group با نام تکراری مهیا نیست.");
        public static readonly ExperienceManagementErrorMessage UserInGroupExistError =
          new ExperienceManagementErrorMessage("DAGE-1004", "گروه انتخابی دارای کاربر می باشد ابتدا آن کاربر را به گروه دیگر تخصیص دهید.");
        public static readonly ExperienceManagementErrorMessage DeleteGroupNotselectedError =
          new ExperienceManagementErrorMessage("DAGE-1005", "درخواست شما منجر به حذف Group می شود که در لیست انتخابی نیست.");      
        public static readonly ExperienceManagementErrorMessage DbGetGroupError =
          new ExperienceManagementErrorMessage("DAGE-1007", "در گرفتن Group مورد نظر خطایی رخ داده است.");
        public static readonly ExperienceManagementErrorMessage DbRoleExistError =
          new ExperienceManagementErrorMessage("DAGE-1007", "بخشی یا کل رول ها در لیست انتخابی وجود ندارد");
        public static readonly ExperienceManagementErrorMessage DbEditGroupNotExistError =
          new ExperienceManagementErrorMessage("DAGE-1006", "گروهی که می خواهید  تغییر دهید وجود ندارد");
        public static readonly ExperienceManagementErrorMessage DbGetRolesError =
          new ExperienceManagementErrorMessage("DAGE-1008", "در دریافت Role ها خطایی رخ داده است.");




    }
}
