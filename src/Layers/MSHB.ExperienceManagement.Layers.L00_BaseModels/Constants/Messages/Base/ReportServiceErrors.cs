using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class ReportServiceErrors
    {
       
        public static readonly ExperienceManagementErrorMessage GetReportStructureError =
          new ExperienceManagementErrorMessage("GRD-1001", "خطا در دریافت ساختار گزارش");
        public static readonly ExperienceManagementErrorMessage ReportStructureNotFoundError =
         new ExperienceManagementErrorMessage("GRD-1002", "گزارشی که به دنبال آن هستید در سیستم وجود ندارد");

        public static ExperienceManagementErrorMessage UpdateReportStructureError =
         new ExperienceManagementErrorMessage("GRD-1003", "خطا در ثبت ساختار گزارشی که به دنبال تغییر آن هستید");

        public static ExperienceManagementErrorMessage IssueOfUsersReportError =
         new ExperienceManagementErrorMessage("GRD-1004", "خطا در ارائه گزارش مسائل کاربران");

        public static ExperienceManagementErrorMessage IssuesOfOrganizationReportError =
         new ExperienceManagementErrorMessage("GRD-1005", "خطا در ارائه گزارش مسائل رده های انتخابی");
    }
}
