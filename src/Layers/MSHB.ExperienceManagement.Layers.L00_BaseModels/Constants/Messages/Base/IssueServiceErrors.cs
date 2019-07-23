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
        public static readonly ExperienceManagementErrorMessage NotExistFileAddressError =
          new ExperienceManagementErrorMessage("UFE-1003", "فایل  با این مقدار وجود ندارد.");
        public static readonly ExperienceManagementErrorMessage ChangeToThumbnailError =
          new ExperienceManagementErrorMessage("UFE-1004", "خطا در تغییر سایز تصویر");
        public static readonly ExperienceManagementErrorMessage AddIssueDetailError =
          new ExperienceManagementErrorMessage("UFE-1005", "خطایی در درج جزییات مسئله رخ داده است.");
        public static readonly ExperienceManagementErrorMessage IssueNotFoundError =
          new ExperienceManagementErrorMessage("UFE-1006", "مسئله مورد نظر یافت نشد.");
        public static ExperienceManagementErrorMessage ChangeStateIssueError =
          new ExperienceManagementErrorMessage("UFE-1007", "در تغییر وضعیت مسئله خطایی رخ داده است.");
        public static ExperienceManagementErrorMessage EditIssueError =
          new ExperienceManagementErrorMessage("UFE-1008", "در تغییر دادن مسئله خطایی رخ داده است.");
          public static ExperienceManagementErrorMessage IssueDetailNotFoundError =
          new ExperienceManagementErrorMessage("UFE-1009", "جزییات مورد نظر در مسئله یافت نشد.");
          public static ExperienceManagementErrorMessage EditIssueDetailError =
          new ExperienceManagementErrorMessage("UFE-1010", "خطا در تغییر جزییات در مسئله رخ داده است.");
        public static readonly ExperienceManagementErrorMessage FileNotFoundError =
        new ExperienceManagementErrorMessage("UFE-1011", "فایل یافت نشد.");

        public static ExperienceManagementErrorMessage IssueDetailAttachmentNotFoundError =
          new ExperienceManagementErrorMessage("UFE-1011", "ضمیمه مورد نظر یافت نشده است");

        public static ExperienceManagementErrorMessage DeleteIssueDetailAttachmentsError =
          new ExperienceManagementErrorMessage("UFE-1012", "در حذف ضمیمه مورد نظر خطایی رخ داده است.");
        public static ExperienceManagementErrorMessage NotExistEquipmentsListError =
          new ExperienceManagementErrorMessage("UFE-1013", "برخی از تجهیزات انتخابی وجود ندارد.");

        public static ExperienceManagementErrorMessage AddIssueDetailCommentError =
          new ExperienceManagementErrorMessage("UFE-1014", "در اضافه کردن پیام به جزییات خاص خطایی رخ داده است.");
        public static ExperienceManagementErrorMessage GetIssuesError =
          new ExperienceManagementErrorMessage("UFE-1015", "خطا در دریافت مسئله های کاربر.");
        public static ExperienceManagementErrorMessage GetIssueDetailsError =
          new ExperienceManagementErrorMessage("UFE-1016", "خطا در دریافت جزییات مسئله.");
        public static ExperienceManagementErrorMessage SearchIssuesError =
          new ExperienceManagementErrorMessage("UFE-1017", "خطا در دریافت مسئله ها.");

        public static ExperienceManagementErrorMessage ChangeLikeIssueError =
          new ExperienceManagementErrorMessage("UFE-1018", "موقع تغییر میزان محبوبیت خطایی رخ داده است.");
    }
}
