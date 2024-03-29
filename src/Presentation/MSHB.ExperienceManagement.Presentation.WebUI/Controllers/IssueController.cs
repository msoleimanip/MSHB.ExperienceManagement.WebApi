﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Presentation.WebCore;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Presentation.WebUI.filters;
using Microsoft.AspNetCore.Authorization;

namespace MSHB.ExperienceManagement.Presentation.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Issue")]
    public class IssueController : BaseController
    {
        private IIssueService _issueService;

        public IssueController(IIssueService issueService)
        {
            _issueService = issueService;
            _issueService.CheckArgumentIsNull(nameof(_issueService));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [ValidateModelAttribute]
        public async Task<IActionResult> AddIssue([FromBody] AddIssueFormModel issueForm)
        {
            var resp = await _issueService.AddIssueAsync(HttpContext.GetUser(), issueForm);
            return Ok(GetRequestResult(resp));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [ValidateModelAttribute]
        public async Task<IActionResult> AddIssueDetails([FromBody] AddIssueDetailFormModel issueDetailForm)
        {
            var resp = await _issueService.AddIssueDetailAsync(HttpContext.GetUser(), issueDetailForm);
            return Ok(GetRequestResult(resp));
        }

        
         [HttpGet("[action]"), HttpPost("[action]")]
        [ValidateModelAttribute]
        public async Task<IActionResult> ActivateIssue([FromBody] ActivateIssueFormModel issueActivate)
        {
            var resp = await _issueService.ActivateIssueAsync(HttpContext.GetUser(), issueActivate);
            return Ok(GetRequestResult(resp));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [ValidateModelAttribute]
        public async Task<IActionResult> EditIssue([FromBody]  EditIssueFormModel issueForm)
        {
            var resp = await _issueService.EditIssueAsync(HttpContext.GetUser(), issueForm);
            return Ok(GetRequestResult(resp));

        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [ValidateModelAttribute]
        public async Task<IActionResult> EditIssueDetails( [FromBody] EditIssueDetailFormModel issueDetailForm)
        {
            var resp = await _issueService.EditIssueDetailAsync(HttpContext.GetUser(), issueDetailForm);
            
            return Ok(GetRequestResult(resp));
        }
        
         [HttpGet("[action]"), HttpPost("[action]")]
        [ValidateModelAttribute]
        public async Task<IActionResult> DeleteIssueDetailAttachment( [FromBody] DeleteIssueDetailAttachmentFormModel issueDetailAttachmentForm)
        {
            var resp = await _issueService.DeleteIssueDetailAttachmentsAsync(HttpContext.GetUser(), issueDetailAttachmentForm);
            return Ok(GetRequestResult(resp));
            
        }


        [HttpGet("[action]"), HttpPost("[action]")]
        [ValidateModelAttribute]
        public async Task<IActionResult> DeleteIssue([FromBody] DeleteIssueFormModel deleteIssueFormModel)
        {
            var resp = await _issueService.DeleteIssueAsync(HttpContext.GetUser(), deleteIssueFormModel);
            return Ok(GetRequestResult(resp));

        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [ValidateModelAttribute]
        public async Task<IActionResult> AddIssueDetailComment([FromBody] AddIssueDetailCommentFormModel issueForm)
        {
            var resp = await _issueService.AddIssueDetailCommentAsync(HttpContext.GetUser(), issueForm);
            return Ok(GetRequestResult(resp));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [ValidateModelAttribute]
        public async Task<IActionResult> GetIssuesForUser([FromBody] SearchIssueFormModel searchIssueForm)
        {
            return Ok(GetRequestResult(await _issueService.GetIssuesForUserAsync(searchIssueForm)));
        }


        [HttpGet("[action]"), HttpPost("[action]")]
        [ValidateModelAttribute]
        public async Task<IActionResult> GetIssueDetails([FromBody] SearchIssueDetailFormModel searchIssueDetailForm)
        {
            return Ok(GetRequestResult(await _issueService.GetIssueDetailsAsync(HttpContext.GetUser(), searchIssueDetailForm)));

        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [ValidateModelAttribute]
        public async Task<IActionResult> SearchSmartIssue([FromBody] SearchSmartIssueFormModel searchIssueForm)
        {
            return Ok(GetRequestResult(await _issueService.SearchSmartIssueAsync(HttpContext.GetUser(), searchIssueForm)));
        }


        [HttpGet("[action]"), HttpPost("[action]")]
        [ValidateModelAttribute]
        public async Task<IActionResult> IssueDetailsLike([FromBody] IssueDetailsLikeFormModel issueDetailsLike)
        {
            var resp = await _issueService.IssueDetailsLikeAsync(HttpContext.GetUser(), issueDetailsLike);
            return Ok(GetRequestResult(resp));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [ValidateModelAttribute]
        public async Task<IActionResult> IssueDetailsBestAnswer([FromBody] IssueDetailBestAnswerFormModel issueDetailsAnswer)
        {
            var resp = await _issueService.IssueDetailsBestAnswerAsync(HttpContext.GetUser(), issueDetailsAnswer);
            return Ok(GetRequestResult(resp));
        }      
    }
}