using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Presentation.WebCore;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;

namespace MSHB.ExperienceManagement.Presentation.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : BaseController
    {
        private IIssueService _issueService;

        public IssueController(IIssueService issueService)
        {
            _issueService = issueService;
            _issueService.CheckArgumentIsNull(nameof(_issueService));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        public async Task<IActionResult> AddIssue([FromBody] AddIssueFormModel issueForm)
        {
            var resp = await _issueService.AddIssueAsync(HttpContext.GetUser(), issueForm);
            return Ok(GetRequestResult(resp));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        public async Task<IActionResult> EditIssue([FromBody]  EditIssueFormModel issueForm)
        {
            var resp = await _issueService.EditIssueAsync(HttpContext.GetUser(), issueForm);
            return Ok(GetRequestResult(resp));
        }

     
    }
}