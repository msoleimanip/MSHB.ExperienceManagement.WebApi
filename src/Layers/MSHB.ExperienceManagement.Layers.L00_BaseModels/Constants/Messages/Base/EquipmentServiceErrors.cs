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

    }
}
