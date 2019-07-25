using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms
{
    public class UpdateReportStructureFormModel
    {
        public long ReportStructureModelId { get; set; } = 0;
        [Required]

        public string ReportId { get; set; }
        [Required]
        public string Configuration { get; set; }
        public string CreationDateTime { get; set; }
        public string LastUpdatedDateTime { get; set; }
    }
}
