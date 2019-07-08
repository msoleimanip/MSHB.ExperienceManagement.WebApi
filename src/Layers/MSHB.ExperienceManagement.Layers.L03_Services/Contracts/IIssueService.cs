using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Contracts
{
    public interface IIssueService
    {
        Task<bool> AddIssueAsync(User user, AddIssueFormModel issueForm);
        Task<bool> EditIssueAsync(User user, EditIssueFormModel issueForm);       
        Task<bool> AddIssueDetailAsync(User user, AddIssueDetailFormModel issueDetailForm);
        Task<bool> ActivateIssueAsync(User user, ActivateIssueFormModel issueActivate);
        Task<bool> EditIssueDetailAsync(User user, EditIssueDetailFormModel issueDetailForm);
        Task<bool> DeleteIssueDetailAttachmentsAsync(User user, DeleteIssueDetailFormModel issueDetailAttachmentForm);
        Task<bool> AddIssueDetailCommentAsync(User user, AddIssueDetailCommentFormModel issueForm);
        Task<SearchIssueViewModel> GetIssuesForUserAsync(SearchIssueFormModel searchIssueForm);
        Task<List<IssueDetailViewModel>> GetIssueDetailsAsync(SearchIssueDetailFormModel searchIssueDetailForm);
    }
}
