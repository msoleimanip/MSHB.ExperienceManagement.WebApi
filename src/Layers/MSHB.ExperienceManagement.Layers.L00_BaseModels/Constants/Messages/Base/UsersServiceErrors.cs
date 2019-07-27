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
        public static readonly ExperienceManagementErrorMessage ChangeStateError =
           new ExperienceManagementErrorMessage("AUE-1007", "خطا در تغییر وضعیت کاربر");
        public static readonly ExperienceManagementErrorMessage ChangePasswordError =
           new ExperienceManagementErrorMessage("AUE-1008", "در تغییر پسورد خطایی رخ داده است.");
        public static ExperienceManagementErrorMessage Unauthorized =
             new ExperienceManagementErrorMessage("AUE-1010", "نام کاربری و شناسه کاربری درست نمی باشد.");
        public static ExperienceManagementErrorMessage RefreshToken =
            new ExperienceManagementErrorMessage("AUE-1011", "مشکل در کد دریافت دوباره سطح دسترسی.");
        public static ExperienceManagementErrorMessage DeActive =
            new ExperienceManagementErrorMessage("AUE-1012", "کاربری شما توسط ادمین سیستم غیرفعال شده است");

        public static ExperienceManagementErrorMessage GetOrganizationUsers =
            new ExperienceManagementErrorMessage("AUE-1013", "در دریافت اطلاعات کاربران رده مشکل رخ داده است.");
    }

}
