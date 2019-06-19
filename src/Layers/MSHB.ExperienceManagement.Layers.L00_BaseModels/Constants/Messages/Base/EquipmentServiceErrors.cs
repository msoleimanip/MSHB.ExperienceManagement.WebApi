using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class EquipmentServiceErrors
    {
        public static readonly ExperienceManagementErrorMessage AddEquipmentError =
          new ExperienceManagementErrorMessage("AEE-1000", "هنگام اضافه کردن تجهیزات خطایی رخ داده  است.");
        public static readonly ExperienceManagementErrorMessage EditEquipmentError =
          new ExperienceManagementErrorMessage("AEE-1001", "هنگام تغییر دادن تجهیزات خطایی رخ داده  است.");
        public static readonly ExperienceManagementErrorMessage DeleteEquipmentError =
          new ExperienceManagementErrorMessage("AEE-1002", "هنگام حذف تجهیزات خطایی رخ داده  است.");
        public static readonly ExperienceManagementErrorMessage EquipmentNotFoundError =
          new ExperienceManagementErrorMessage("AEE-1003", "تجهیزات مورد نظر یافت نشده است");       
        public static readonly ExperienceManagementErrorMessage EditDuplicateEquipmentError =
          new ExperienceManagementErrorMessage("AEE-1004", "امکان تغییر به تجهیزات با نام تکراری مهیا نیست.");
        public static readonly ExperienceManagementErrorMessage UserInEquipmentExistError =
          new ExperienceManagementErrorMessage("AEE-1005", "کاربری در رده انتخابی برای پاک کردن وجود دارد ابتدا تجهیزات آن تغییر کند.");
        public static readonly ExperienceManagementErrorMessage DeleteEquipmentNotselectedError =
          new ExperienceManagementErrorMessage("AEE-1006", "درخواست شما منجر به حذف تجهیزات  می شود که در لیست انتخابی نیست.");
        public static readonly ExperienceManagementErrorMessage EditEquipmentNotExistError =
          new ExperienceManagementErrorMessage("AEE-1007", "تجهیزات مورد نظر وجود ندارد.");
        public static readonly ExperienceManagementErrorMessage GetEquipmentError =
         new ExperienceManagementErrorMessage("AEE-1008", "در گرفتن تجهیز مورد نظر خطایی رخ داده است.");
        public static readonly ExperienceManagementErrorMessage AddDuplicateEquipmentError =
          new ExperienceManagementErrorMessage("AEE-1009", "امکان اضافه کردن تجهیزات با نام تکراری مهیا نیست.");


    }
}
