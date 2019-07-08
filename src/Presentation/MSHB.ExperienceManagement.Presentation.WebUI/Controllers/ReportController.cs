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
    }
}
