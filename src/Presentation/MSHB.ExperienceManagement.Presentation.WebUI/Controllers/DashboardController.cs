using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Presentation.WebCore;
using MSHB.ExperienceManagement.Presentation.WebUI.filters;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;

namespace MSHB.ExperienceManagement.Presentation.WebUI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [Authorize(Roles = "Dashboard")]
    public class DashboardController : BaseController
    {
        private IIssueService _issueService;
        public DashboardController(IIssueService issueService)
        {
            _issueService = issueService;
            _issueService.CheckArgumentIsNull(nameof(_issueService));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [ValidateModelAttribute]
        public async Task<IActionResult> GetUserIssueDashboard()
        {
            return Ok(GetRequestResult(await _issueService.GetUserIssueDashboardAsync(HttpContext.GetUser())));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [ValidateModelAttribute]
        public async Task<IActionResult> GetUserLikesDashboard()
        {
            return Ok(GetRequestResult(await _issueService.GetUserLikesDashboardAsync(HttpContext.GetUser())));
        }
    }
}