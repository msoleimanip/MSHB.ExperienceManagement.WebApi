using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class OrganizationRepositoryErrors
    {
        public static readonly ExperienceManagementErrorMessage DbAddOrganizationError =
          new ExperienceManagementErrorMessage("DAOE-1000", "هنگام اضافه کردن رده خطایی رخ داده  است.");
        public static readonly ExperienceManagementErrorMessage DbEditOrganizationError =
          new ExperienceManagementErrorMessage("DAOE-1001", "هنگام تغییر دادن رده خطایی رخ داده  است.");
        public static readonly ExperienceManagementErrorMessage DbDeleteOrganizationError =
          new ExperienceManagementErrorMessage("DAOE-1002", "هنگام حذف رده خطایی رخ داده  است.");
        public static readonly ExperienceManagementErrorMessage DbAddDuplicateOrganizationError =
          new ExperienceManagementErrorMessage("DAOE-1003", "امکان اضافه کردن رده با نام تکراری مهیا نیست.");
        public static readonly ExperienceManagementErrorMessage DbEditDuplicateOrganizationError =
          new ExperienceManagementErrorMessage("DAOE-1004", "امکان تغییر به رده با نام تکراری مهیا نیست.");
        public static readonly ExperienceManagementErrorMessage UserInOrganizationExistError =
          new ExperienceManagementErrorMessage("DAOE-1005", "کاربری در رده انتخابی برای پاک کردن وجود دارد ابتدا رده آن تغییر کند.");
        public static readonly ExperienceManagementErrorMessage DeleteOrgNotselectedError =
          new ExperienceManagementErrorMessage("DAOE-1006", "درخواست شما منجر به حذف رده ای می شود که در لیست انتخابی نیست.");
        public static readonly ExperienceManagementErrorMessage DbEditOrganizationNotExistError =
          new ExperienceManagementErrorMessage("DAOE-1007", "رده مورد نظر وجود ندارد.");

        
    }
}
