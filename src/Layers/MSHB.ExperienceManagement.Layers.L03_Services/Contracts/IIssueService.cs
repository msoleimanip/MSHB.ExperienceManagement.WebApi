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
        Task<long> AddIssueAsync(User user, AddIssueFormModel issueForm);
        Task<bool> EditIssueAsync(User user, EditIssueFormModel issueForm);       
        Task<IssueDetailViewModel> AddIssueDetailAsync(User user, AddIssueDetailFormModel issueDetailForm);
        Task<bool> ActivateIssueAsync(User user, ActivateIssueFormModel issueActivate);
        Task<bool> EditIssueDetailAsync(User user, EditIssueDetailFormModel issueDetailForm);
        Task<bool> DeleteIssueDetailAttachmentsAsync(User user, DeleteIssueDetailFormModel issueDetailAttachmentForm);
        Task<IssueDetailCommentViewModel> AddIssueDetailCommentAsync(User user, AddIssueDetailCommentFormModel issueForm);     
        Task<List<IssueViewModel>> GetUserIssueDashboardAsync(User user);
        Task<SearchIssueViewModel> GetIssuesForUserAsync(SearchIssueFormModel searchIssueForm);
        Task<SearchIssueDetailsViewModel> GetIssueDetailsAsync(SearchIssueDetailFormModel searchIssueDetailForm);
        Task<List<IssueViewModel>> GetUserLikesDashboardAsync(User user);
        Task<SearchIssueViewModel> SearchSmartIssueAsync(User user, SearchSmartIssueFormModel searchIssueForm);
        Task<long> IssueDetailsLikeAsync(User user, IssueDetailsLikeFormModel issueDetailsLike);
        Task<bool> IssueDetailsBestAnswerAsync(User user, IssueDetailBestAnswerFormModel issueDetailsAnswer);
    }
}
