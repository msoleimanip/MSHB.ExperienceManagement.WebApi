using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Contracts
{
    public interface IIssueService
    {
        Task<bool> AddIssueAsync(User user, AddIssueFormModel issueForm);
        Task<bool> EditIssueAsync(User user, EditIssueFormModel issueForm);       
        Task<Guid> UploadFileAsync(User user, IFormFile file);
        Task<bool> AddIssueDetailAsync(User user, AddIssueDetailFormModel issueDetailForm);
    }
}
