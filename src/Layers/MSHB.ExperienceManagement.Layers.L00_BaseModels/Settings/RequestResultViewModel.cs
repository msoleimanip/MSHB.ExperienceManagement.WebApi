using System.Collections.Generic;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages;


namespace ExperienceManagement.WebUI.Layers.L00_BaseModels.Settings
{
    public class RequestResultViewModel
    {
        public object Data { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public List<ExperienceManagementErrorMessage> DetailErrorList { get; set; }=new List<ExperienceManagementErrorMessage>();
        public Dictionary<string, string> ValidationMessages { get; set; }

    }
}
