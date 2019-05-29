using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Presentation.WebCore;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;

namespace MSHB.ExperienceManagement.Presentation.WebUI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class OrganizationController : BaseController
    {
        private IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
            _organizationService.CheckArgumentIsNull(nameof(_organizationService));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrganizationByUser()
        {           
            var organizations =await _organizationService.GetOrganizationByUserAsync(HttpContext.GetUser());
            return Ok(GetRequestResult(organizations));
        }
    }
}