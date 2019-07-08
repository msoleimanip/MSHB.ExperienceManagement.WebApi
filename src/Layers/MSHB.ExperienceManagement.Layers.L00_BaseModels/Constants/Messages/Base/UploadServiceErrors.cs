using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class UploadServiceErrors
    {
        public static readonly ExperienceManagementErrorMessage UploadFileError =
        new ExperienceManagementErrorMessage("UFE-1000", "هنگام آپلود فایل خطایی رخ داده است.");
        public static readonly ExperienceManagementErrorMessage UploadFileValidError =
          new ExperienceManagementErrorMessage("UFE-1001", "فایل ارسالی بایستی معتبر باشد.");

        public static ExperienceManagementErrorMessage FileNotFoundError =
              new ExperienceManagementErrorMessage("UFE-1002", "فایل وجود ندارد.");
        public static ExperienceManagementErrorMessage FileIdNotFoundError =
             new ExperienceManagementErrorMessage("UFE-1003", "شناسه فایل وجود ندارد.");
        public static ExperienceManagementErrorMessage FileDownloadError =
             new ExperienceManagementErrorMessage("UFE-1004", "خطا در دانلود فایل.");

    }
}
