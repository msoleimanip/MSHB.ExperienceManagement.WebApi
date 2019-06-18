using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class UsersServiceErrors
    {
        public static readonly ExperienceManagementErrorMessage AddUserError =
           new ExperienceManagementErrorMessage("AUE-1000", "خطا در افزودن کاربر اتفاق افتاده است");
        public static readonly ExperienceManagementErrorMessage GroupNotFoundError =
           new ExperienceManagementErrorMessage("AUE-1001", "گروه ای که انتخاب کرده اید وجود ندارد ");
        public static readonly ExperienceManagementErrorMessage OrganizationNotFoundError =
           new ExperienceManagementErrorMessage("AUE-1002", "رده ای که انتخاب کرده اید وجود ندارد ");
        public static readonly ExperienceManagementErrorMessage UserExistError =
           new ExperienceManagementErrorMessage("AUE-1003", "کاربری با این نام در سیستم وجود دارد امکان اضافه کردن وجود ندارد.");
        public static readonly ExperienceManagementErrorMessage UserNotFoundError =
           new ExperienceManagementErrorMessage("AUE-1004", "کاربری با این مشخصات در سیستم وجود ندارد.");
        public static readonly ExperienceManagementErrorMessage AssignmentError =
           new ExperienceManagementErrorMessage("AUE-1005", "تخصیص به درستی صورت نپذیرفت.");
        public static readonly ExperienceManagementErrorMessage OrgNotFoundError =
           new ExperienceManagementErrorMessage("AUE-1006", "ارگان انتخابی پیدا نشد.");
        public static readonly ExperienceManagementErrorMessage EquipmentNotFoundError =
           new ExperienceManagementErrorMessage("AUE-1006", "در تجهیزات انتخابی موردی است که یافت نشد.");


        







    }

}
