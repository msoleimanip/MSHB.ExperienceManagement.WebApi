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
          new ExperienceManagementErrorMessage("DEO-1002", "هنگام حذف رده خطایی رخ داده  است.");
        public static readonly ExperienceManagementErrorMessage OrganizationNotFoundError =
          new ExperienceManagementErrorMessage("ONE-1003", "رده مورد نظر یافت نشده است");
        public static readonly ExperienceManagementErrorMessage AddDuplicateOrganizationError =
          new ExperienceManagementErrorMessage("ONE-1004", "اضافه کردن رده تکراری ممکن نیست");
        public static readonly ExperienceManagementErrorMessage EditDuplicateOrganizationError =
          new ExperienceManagementErrorMessage("ONE-1005", "تغییر در رده منجر به رده تکراری می شود");
        public static readonly ExperienceManagementErrorMessage EditOrganizationNotExistError =
          new ExperienceManagementErrorMessage("ONE-1006", "رده ای که به دنبال تغییر هستید وجود ندارد");
        public static readonly ExperienceManagementErrorMessage UserInOrganizationExistError =
          new ExperienceManagementErrorMessage("ONE-1007", "در رده و سلسله مراتب آن کاربر وجود دارد");
        public static readonly ExperienceManagementErrorMessage DeleteOrgNotselectedError =
          new ExperienceManagementErrorMessage("ONE-1008", "رده که برای حذف انتخاب شده منجر به حذف رده های انتخاب نشده می شود لطفا همه موارد انتخاب شود.");
        public static readonly ExperienceManagementErrorMessage GetOrganizationError =
          new ExperienceManagementErrorMessage("ONE-1009", "در دریافت اطلاعات رده خطا رخ داده است");


    }
}
