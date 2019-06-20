using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class IssueServiceErrors
    {
        public static readonly ExperienceManagementErrorMessage UploadFileError =
          new ExperienceManagementErrorMessage("UFE-1000", "هنگام آپلود فایل خطایی رخ داده است.");
        public static readonly ExperienceManagementErrorMessage UploadFileValidError =
          new ExperienceManagementErrorMessage("UFE-1001", "فایل ارسالی بایستی معتبر باشد.");
        public static readonly ExperienceManagementErrorMessage AddIssueError =
          new ExperienceManagementErrorMessage("UFE-1002", "هنگام ذخیره مسئله خطایی رخ داده است.");
        public static readonly ExperienceManagementErrorMessage UploadFileNotFound =
          new ExperienceManagementErrorMessage("UFE-1003", "فایل تصویری با این مقدار وجود ندارد.");
        public static readonly ExperienceManagementErrorMessage ChangeToThumbnailError =
          new ExperienceManagementErrorMessage("UFE-1004", "خطا در تغییر سایز تصویر");
        public static readonly ExperienceManagementErrorMessage AddIssueDetailError =
          new ExperienceManagementErrorMessage("UFE-1005", "خطایی در درج جزییات مسئله رخ داده است.");
        public static readonly ExperienceManagementErrorMessage IssueNotFoundError =
          new ExperienceManagementErrorMessage("UFE-1006", "مسئله مورد نظر یافت نشد.");

        






    }
}
