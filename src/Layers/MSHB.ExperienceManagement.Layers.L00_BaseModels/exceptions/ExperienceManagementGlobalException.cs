using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages;


namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.exceptions
{
    public class ExperienceManagementGlobalException : Exception
    {
        public ExperienceManagementGlobalException(ExperienceManagementErrorMessage error)
        {
            UserMessage = error.Message;
            ErrorCode = error.Code;
            ExceptionList = null;
        }

        public ExperienceManagementGlobalException(ExperienceManagementErrorMessage error, Exception e)
        {
            UserMessage = error.Message;
            ErrorCode = error.Code;
            ExceptionList = new List<Exception>{e};
        }
        public ExperienceManagementGlobalException(ExperienceManagementErrorMessage error, params Exception[] exceptions)
        {
            UserMessage = error.Message;
            ErrorCode = error.Code;
            ExceptionList = new List<Exception>();
            ExceptionList.AddRange(exceptions);
        }

    

        public string UserMessage { get; set; }
        public string ErrorCode { get; set; }
        public List<Exception> ExceptionList { get; set; }
    }
}