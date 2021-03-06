﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Presentation.WebCore;
using MSHB.ExperienceManagement.Presentation.WebUI.filters;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;

namespace MSHB.ExperienceManagement.Presentation.WebUI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [Authorize(Roles = "Organization")]
    public class OrganizationController : BaseController
    {
        private IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
            _organizationService.CheckArgumentIsNull(nameof(_organizationService));
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "Organization-Get")]
        public async Task<IActionResult> Get([FromQuery] long Id)
        {
            return Ok(GetRequestResult(await _organizationService.GetAsync(HttpContext.GetUser(),Id)));
        }


        [HttpGet("[action]"), HttpPost("[action]")]
        [Authorize(Roles = "Organization-GetOrganizationByUser")]
        public async Task<IActionResult> GetOrganizationByUser()
        {           
            var organizations =await _organizationService.GetOrganizationByUserAsync(HttpContext.GetUser());
            return Ok(GetRequestResult(organizations));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [Authorize(Roles = "Organization-GetUserOrganizationForUser")]
        
        [ValidateModelAttribute]
        public async Task<IActionResult> GetUserOrgazinationForUser([FromQuery] Guid userId)
        {
            var organizations = await _organizationService.GetUserOrgazinationForUserAsync(HttpContext.GetUser(), userId);
            return Ok(GetRequestResult(organizations));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [Authorize(Roles = "Organization-AddOrganization")]
        [ValidateModelAttribute]
        public async Task<IActionResult> AddOrganization([FromBody] AddOrgFormModel orgForm)
        {            
            var organizations = await _organizationService.AddOrganizationAsync(HttpContext.GetUser(), orgForm);
            return Ok(GetRequestResult(organizations));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [Authorize(Roles = "Organization-EditOrganization")]
        [ValidateModelAttribute]
        public async Task<IActionResult> EditOrganization([FromBody] EditOrgFormModel orgForm)
        {
            var organizations = await _organizationService.EditOrganizationAsync(HttpContext.GetUser(),orgForm);
            return Ok(GetRequestResult(organizations));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [Authorize(Roles = "Organization-DeleteOrganization")]
        [ValidateModelAttribute]
        public async Task<IActionResult> DeleteOrganization([FromBody]
        [Required(ErrorMessage = "لیست رده های ارسال شده برای حذف نامعتبر است")]List<long> orgIds)
        {
            var organizations = await _organizationService.DeleteOrganizationAsync(HttpContext.GetUser(),orgIds);
            return Ok(GetRequestResult(organizations));
        }
    }
}