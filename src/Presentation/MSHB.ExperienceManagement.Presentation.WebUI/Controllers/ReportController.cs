using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Presentation.WebCore;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;

namespace MSHB.ExperienceManagement.Presentation.WebUI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [Authorize(Roles = "Report")]
    public class ReportController : BaseController
    {
        private IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
            _reportService.CheckArgumentIsNull(nameof(_reportService));

        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [Authorize(Roles = "Report-GetReportStructure")]
        public async Task<IActionResult> GetReportStructure([FromBody] ReportStructureFormModel reportStructureFormModel)
        {
            return Ok(GetRequestResult(await _reportService.GetReportStructureAsync(reportStructureFormModel)));
        }
        [HttpGet("[action]"), HttpPost("[action]")]
        [Authorize(Roles = "Report-AddOrUpdateReportStructure")]
        public async Task<IActionResult> UpdateReportStructure([FromBody] UpdateReportStructureFormModel form)
        {
            var result =
                await _reportService.AddOrUpdateReportStructureAsync(HttpContext.GetUser(), form);
            return Ok(GetRequestResult(result));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [Authorize(Roles = "Report-IssueOfUsersReport")]
        public async Task<IActionResult> IssueOfUsersReport([FromBody]IssueOfUsersFormModel form)
        {
            var result =
                await _reportService.IssueOfUsersReportAsync(HttpContext.GetUser(), form);
            return Ok(GetRequestResult(result));
        }
        [HttpGet("[action]"), HttpPost("[action]")]
        [Authorize(Roles = "Report-IssueOfEquipmentsReport")]
        public async Task<IActionResult> IssueOfEquipmentsReport([FromBody]IssueOfEquipmentFormModel form)
        {
            var result =
                await _reportService.IssueOfEquipmentsReportAsync(HttpContext.GetUser(), form);
            return Ok(GetRequestResult(result));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [Authorize(Roles = "Report-IssueOfUserLikesReport")]
        public async Task<IActionResult> IssueOfUserLikesReport([FromBody]IssueOfUsersFormModel form)
        {
            var result =
                await _reportService.IssueOfUserLikesReportAsync(HttpContext.GetUser(), form);
            return Ok(GetRequestResult(result));
        }
        [HttpGet("[action]"), HttpPost("[action]")]
        [Authorize(Roles = "Report-TotalIssueReport")]
        public async Task<IActionResult> TotalIssueReport([FromBody]IssueOfEquipmentFormModel form)
        {
            var result =
                await _reportService.TotalIssueReportAsync(HttpContext.GetUser(), form);
            return Ok(GetRequestResult(result));
        }
        [HttpGet("[action]"), HttpPost("[action]")]
        [Authorize(Roles = "Report-UserIssuesReport")]
        public async Task<IActionResult> UserIssuesReport([FromBody]IssueOfEquipmentFormModel form)
        {
            var result =
                await _reportService.UserIssuesReportAsync(HttpContext.GetUser(), form);
            return Ok(GetRequestResult(result));
        }
        [HttpGet("[action]"), HttpPost("[action]")]
        [Authorize(Roles = "Report-IssuesOfOrganizationReport")]
        public async Task<IActionResult>IssuesOfOrganizationReport([FromBody]IssueOfOrganizationFormModel form)
        {
            var result =
                await _reportService.IssuesOfOrganizationReportAsync(HttpContext.GetUser(), form);
            return Ok(GetRequestResult(result));
        }

    }
}
