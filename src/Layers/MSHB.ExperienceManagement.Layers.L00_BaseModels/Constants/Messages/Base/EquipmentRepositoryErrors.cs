using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class EquipmentRepositoryErrors
    {
        public static readonly ExperienceManagementErrorMessage DbAddEquipmentError =
          new ExperienceManagementErrorMessage("DAEE-1000", "هنگام اضافه کردن تجهیزات خطایی رخ داده  است.");
        public static readonly ExperienceManagementErrorMessage DbEditEquipmentError =
          new ExperienceManagementErrorMessage("DAEE-1001", "هنگام تغییر دادن تجهیزات خطایی رخ داده  است.");
        public static readonly ExperienceManagementErrorMessage DbDeleteEquipmentError =
          new ExperienceManagementErrorMessage("DAEE-1002", "هنگام حذف تجهیزات خطایی رخ داده  است.");
        public static readonly ExperienceManagementErrorMessage DbAddDuplicateEquipmentError =
          new ExperienceManagementErrorMessage("DAEE-1003", "امکان اضافه کردن تجهیزات با نام تکراری مهیا نیست.");
        public static readonly ExperienceManagementErrorMessage DbEditDuplicateEquipmentError =
          new ExperienceManagementErrorMessage("DAEE-1004", "امکان تغییر به تجهیزات با نام تکراری مهیا نیست.");
        public static readonly ExperienceManagementErrorMessage UserInEquipmentExistError =
          new ExperienceManagementErrorMessage("DAEE-1005", "کاربری در رده انتخابی برای پاک کردن وجود دارد ابتدا تجهیزات آن تغییر کند.");
        public static readonly ExperienceManagementErrorMessage DeleteEquipmentNotselectedError =
          new ExperienceManagementErrorMessage("DAEE-1006", "درخواست شما منجر به حذف تجهیزات  می شود که در لیست انتخابی نیست.");
        public static readonly ExperienceManagementErrorMessage DbEditEquipmentNotExistError =
          new ExperienceManagementErrorMessage("DAEE-1007", "تجهیزات مورد نظر وجود ندارد.");
        public static readonly ExperienceManagementErrorMessage DbGetEquipmentError =
         new ExperienceManagementErrorMessage("DAEE-1008", "در گرفتن تجهیز مورد نظر خطایی رخ داده است.");


    }
}
