using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class ReportServiceErrors
    {
       
        public static readonly ExperienceManagementErrorMessage GetReportStructure =
          new ExperienceManagementErrorMessage("GRD-1001", "خطا در دریافت ساختار گزارش");
        public static readonly ExperienceManagementErrorMessage ReportStructureNotFound =
         new ExperienceManagementErrorMessage("GRD-1002", "گزارشی که به دنبال آن هستید در سیستم وجود ندارد");



    }
}
