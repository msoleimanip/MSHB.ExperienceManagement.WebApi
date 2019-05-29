using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;

namespace MSHB.ExperienceManagement.Presentation.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupAuthenticationController : BaseController
    {
        private readonly IGroupAuthenticationService _groupAuthenticationService;

        public GroupAuthenticationController(
            IGroupAuthenticationService groupAuthenticationService
            )
        {
            _groupAuthenticationService = groupAuthenticationService;
            _groupAuthenticationService.CheckArgumentIsNull(nameof(_groupAuthenticationService));
        }
        [HttpGet("[action]"), HttpPost("[action]")]
        public async Task<IActionResult> GetGroupAuthentication()
        {
            return Ok(GetRequestResult(await _groupAuthenticationService.GetGroupAuthenticationAsync()));
          
        }
    }
}